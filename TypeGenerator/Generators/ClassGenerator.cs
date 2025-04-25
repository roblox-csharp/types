using static TypeGenerator.Constants;

namespace TypeGenerator.Generators;

internal sealed class ClassGenerator(
    string filePath,
    ReflectionMetadataReader metadata,
    HashSet<string> definedClassNames,
    string security,
    string? lowerSecurity = null)
    : Generator(filePath, metadata)
{
    private readonly Dictionary<string, APITypes.Class> _classRefs = [];
    private readonly Dictionary<string, HashSet<string>> _definedMemberNames = [];
    private readonly ReflectionMetadataReader _metadata = metadata;

    public void Generate(List<APITypes.Class> rbxClasses)
    {
        foreach (var rbxClass in rbxClasses)
        {
            var className = rbxClass.Name;
            rbxClass.Subclasses = [];
            _classRefs[className] = rbxClass;

            var superclass = rbxClass.Superclass != ROOT_CLASS_NAME
                ? _classRefs[rbxClass.Superclass]
                : null;

            superclass?.Subclasses.Add(className);
        }

        var classesToGenerate = rbxClasses.Where(ShouldGenerateClass).ToList();
        GenerateHeader();
        Write($"namespace Roblox{(security == "PluginSecurity" ? ".PluginClasses" : "")};");
        ;
        GenerateServices(rbxClasses.Where(rbxClass => !definedClassNames.Contains(rbxClass.Name)).ToList());
        GenerateClasses(classesToGenerate);
        WriteFile();
    }

    private bool CanRead(string className, APITypes.MemberBase member)
    {
        var readSecurity = Utility.GetSecurity(className, member).Read;

        return readSecurity == security
            || (PLUGIN_ONLY_CLASSES.Contains(className) && readSecurity == lowerSecurity);
    }

    private bool CanWrite(string className, APITypes.MemberBase member)
    {
        var security1 = Utility.GetSecurity(className, member);

        // dumb hack to fix PluginSecurity writable things being marked as readonly in None.cs
        if (security1 is { Read: "None", Write: "PluginSecurity" }) return true;

        return security1.Write == security || (PLUGIN_ONLY_CLASSES.Contains(className) && security1.Write == lowerSecurity);
    }

    private bool IsPluginOnlyClass(APITypes.Class rbxClass)
    {
        if (PLUGIN_ONLY_CLASSES.Contains(rbxClass.Name)) return true;

        var superClass = rbxClass.Superclass != ROOT_CLASS_NAME
            ? _classRefs[rbxClass.Superclass]
            : null;

        return superClass != null && IsPluginOnlyClass(superClass);
    }

    private bool ShouldGenerateClass(APITypes.Class rbxClass)
    {
        var superClass = rbxClass.Superclass != ROOT_CLASS_NAME ? _classRefs[rbxClass.Superclass] : null;

        if (superClass != null && !ShouldGenerateClass(superClass)) return false;

        if (CLASS_BLACKLIST.Contains(rbxClass.Name)) return false;

        return security == "PluginSecurity" || !PLUGIN_ONLY_CLASSES.Contains(rbxClass.Name);
    }

    private bool ShouldGenerateMember(APITypes.Class rbxClass, APITypes.MemberBase member)
    {
        if (member.Name == null) return false;

        var isBlacklisted = MEMBER_BLACKLIST.TryGetValue(rbxClass.Name, out var value) && value.Contains(member.Name);

        if (isBlacklisted) return false;

        if (!CanRead(rbxClass.Name, member)) return false;

        if (Utility.HasTag(member, "Deprecated"))
        {
            var firstChar = member.Name[0];
            if (char.IsLower(firstChar))
            {
                var pascalCaseName = char.ToUpper(firstChar) + member.Name[1..];
                var pascalCaseMember = rbxClass.Members.FirstOrDefault(v => v.Name == pascalCaseName);

                if (pascalCaseMember != null) return false;
            }
        }

        if (Utility.HasTag(member, "Hidden")) return false;

        if (Utility.HasTag(member, "NotScriptable")) return false;

        return !_definedMemberNames[rbxClass.Name].Contains(member.Name.Trim());
    }

    // for writing documentation
    private void WriteDescription(ClassInformation.Member member, string description)
    {
        // Implementation for writing description
    }

    // Returns the given className if it's in ClassRefs
    // Throws if not
    private string AssertClassName(string className)
    {
        if (_classRefs.ContainsKey(className)) return className;

        throw new Exception($"Undefined class name: {className}");
    }

    private void GenerateClass(APITypes.Class rbxClass)
    {
        definedClassNames.Add(rbxClass.Name);
        _definedMemberNames[rbxClass.Name] = [];

        var className = AssertClassName(rbxClass.Name);
        var members = rbxClass.Members;
        var noSecurity = security == "None" || IsPluginOnlyClass(rbxClass);
        switch (noSecurity)
        {
            case true:
            {
                var desc = rbxClass.Description;
                if (desc != null) Write(Utility.FormatComment(desc));

                break;
            }

            case false when members.Count == 0:
                return;
        }

        if (className == "Studio") return;

        var superclasses = new List<string>();
        if (Utility.IsCreatable(rbxClass))
        {
            if (rbxClass.Superclass != "Instance") superclasses.Add(rbxClass.Superclass);

            superclasses.Add("ICreatableInstance");
        }
        else if (Utility.HasTag(rbxClass, "Service"))
        {
            if (rbxClass.Superclass != "Instance") superclasses.Add(rbxClass.Superclass);

            superclasses.Add("IServiceInstance");
        }
        else
        {
            superclasses.Add(rbxClass.Superclass);
        }

        var isPartial = PARTIAL_INTERFACES.Contains(className);
        var membersToGenerate = members.Where(member => ShouldGenerateMember(rbxClass, member)).ToList();
        var isValidSuperclass = rbxClass.Superclass != ROOT_CLASS_NAME;
        var superclassText = isValidSuperclass ? $" : {string.Join(", ", superclasses)}" : "";
        var partialText = isPartial ? " partial" : "";
        Write($"public{partialText} interface {className}{superclassText}");
        Write("{");
        PushIndent();

        if (className != "Object")
            foreach (var memberText in PER_INSTANCE_MEMBERS)
                Write(memberText.Replace("<INSTANCE_TYPE>", rbxClass.Name));

        foreach (var member in membersToGenerate)
        {
            _definedMemberNames[rbxClass.Name].Add(member.Name!.Trim());
            switch (member.MemberType)
            {
                case "Callback":
                    GenerateCallback((APITypes.Callback)member, rbxClass);

                    break;
                case "Event":
                    GenerateEvent((APITypes.Event)member, rbxClass);

                    break;
                case "Function":
                    GenerateFunction((APITypes.Function)member, rbxClass);

                    break;
                case "Property":
                    GenerateProperty((APITypes.Property)member, rbxClass);

                    break;
                default:
                    throw new NotSupportedException($"Received unsupported member type: {member.MemberType}");
            }
        }

        PopIndent();
        Write("}");
        Write();
    }

    private static List<string> GetParamNames(List<APITypes.Parameter> parameters)
    {
        var paramNames = parameters.ConvertAll(param => param.Name);
        for (var i = 0; i < paramNames.Count; i++)
        {
            if (paramNames.IndexOf(paramNames[i]) != i + 1) continue;

            var n = 0;
            for (var j = i; j < parameters.Count; j++)
            {
                paramNames[j] = $"{paramNames[i]}{n}";
                n++;
            }
        }

        return paramNames;
    }

    private string GenerateParams(List<APITypes.Parameter> parameters)
    {
        var args = new List<string>();
        var paramNames = GetParamNames(parameters);
        var optional = false;

        foreach (var param in parameters)
        {
            var paramType = Utility.SafeValueType(param.Type);
            var argName = Utility.SafeParamName(paramNames[parameters.IndexOf(param)]);
            optional |= !string.IsNullOrEmpty(param.Default) || paramType == "any";

            if (!string.IsNullOrEmpty(argName) && paramType == "Instance")
            {
                var findings = _classRefs.Keys.Concat(["Character", "Input"])
                                         .Where(k => k != "Instance"
                                                  && argName.Contains(k, StringComparison.CurrentCultureIgnoreCase))
                                         .ToList();

                if (findings.Count != 0)
                {
                    var partPos = findings.IndexOf("Part");
                    var doSplice = !findings.Contains("Part")
                                && findings.Count != 0
                                && !argName.Contains("or", StringComparison.CurrentCultureIgnoreCase);

                    if (doSplice && partPos != -1)
                    {
                        findings.RemoveAt(partPos);
                    }

                    paramType = Utility.SafeRenamedInstance(findings.FirstOrDefault(found => string.Equals(found,
                                                                                                           argName,
                                                                                                           StringComparison
                                                                                                               .CurrentCultureIgnoreCase)))
                             ?? "Instance";
                }
            }

            var isOptional = optional || paramType.EndsWith('?');
            args.Add($"{(!string.IsNullOrEmpty(paramType) ? $"{paramType}{(optional && !paramType.EndsWith('?') ? "?" : "")}" : "object")} {argName ?? $"arg{parameters.IndexOf(param)}"}{(isOptional ? " = null" : "")}");
        }

        return string.Join(", ", args);
    }

    private void GenerateCallback(APITypes.Callback callback, APITypes.Class rbxClass)
    {
        var paramTypeList = callback.Parameters.Count > 0
            ? string.Join(", ",
                          callback.Parameters.ConvertAll(param => (Utility.SafeValueType(param.Type) ?? "null")
                                                                + " "
                                                                + Utility.SafeParamName(param.Name)))
            : "";

        var delegateName = $"{callback.Name}Delegate";
        var description = !string.IsNullOrWhiteSpace(callback.Description)
            ? callback.Description
            : _metadata.ReadCallbackDesc(rbxClass.Name, callback.Name!);

        Write($"public delegate void {delegateName}({paramTypeList});");
        Write($"public {delegateName} {callback.Name} {{ get; set; }}");
    }

    private void GenerateEvent(APITypes.Event @event, APITypes.Class rbxClass)
    {
        var paramTypeList = @event.Parameters.Count > 0
            ? string.Join(", ",
                          @event.Parameters.ConvertAll(param => (Utility.SafeValueType(param.Type) ?? "null")
                                                              + " "
                                                              + Utility.SafeParamName(param.Name)))
            : "";

        var delegateName = $"{@event.Name}Delegate";
        var description = !string.IsNullOrWhiteSpace(@event.Description)
            ? @event.Description
            : _metadata.ReadEventDesc(rbxClass.Name, @event.Name!);

        Write($"public delegate void {delegateName}({paramTypeList});");
        Write($"public event {delegateName} {@event.Name};");
    }

    private void GenerateFunction(APITypes.Function function, APITypes.Class rbxClass)
    {
        var args = GenerateParams(function.Parameters);
        string? returnType;
        if ((object)function.ReturnType is not string[] enumerable)
            returnType = Utility.SafeReturnType(Utility.SafeValueType(function.ReturnType));
        else
        {
            var typesList = enumerable.Select(t => string.Join(", ",
                                                               Utility
                                                                   .SafeReturnType(Utility.SafeValueType(function.ReturnType))));

            // returnType = $"LuaTuple<{typesList}>";
            returnType = "object"; // temporary
        }

        var description = !string.IsNullOrWhiteSpace(function.Description)
            ? function.Description
            : _metadata.ReadFunctionDesc(rbxClass.Name, function.Name!);

        Write($"public {returnType} {function.Name}({args});");
    }

    private void GenerateProperty(APITypes.Property property, APITypes.Class rbxClass)
    {
        var valueType = Utility.SafePropType(Utility.SafeValueType(property.ValueType))!;
        var description = !string.IsNullOrWhiteSpace(property.Description)
            ? property.Description
            : _metadata.ReadPropDesc(rbxClass.Name, property.Name!);

        var definitelyDefined = property.ValueType.Category != "Class";
        var extraPropertyData = CanWrite(rbxClass.Name, property) && !Utility.HasTag(property, "ReadOnly") ? " set;" : "";
        Write($"public {valueType}{(definitelyDefined || valueType.EndsWith('?') ? "" : "?")} {property.Name!.Replace(" ", "")} {{ get;{extraPropertyData} }}");
    }

    private void GenerateServices(List<APITypes.Class> rbxClasses)
    {
        var services = rbxClasses.Where(rbxClass =>
        {
            var isPluginOnly = PLUGIN_ONLY_CLASSES.Contains(rbxClass.Name);

            return Utility.HasTag(rbxClass, "Service")
                && !Utility.HasTag(rbxClass, "Hidden")
                && !CLASS_BLACKLIST.Contains(rbxClass.Name)
                && (isPluginOnly ? security == "PluginSecurity" : security == "None");
        });

        Write("public static class Services");
        Write("{");
        PushIndent();

        foreach (var service in services) Write($"public static extern {service.Name} {service.Name} {{ get; }}");

        PopIndent();
        Write("}");
        Write();
    }

    private void GenerateClasses(List<APITypes.Class> rbxClasses)
    {
        Write("// GENERATED ROBLOX INSTANCE CLASSES");
        Write();

        foreach (var rbxClass in rbxClasses)
        {
            GenerateClass(rbxClass);
        }
    }

    private void GenerateHeader()
    {
        Write("// THIS FILE IS AUTOMATICALLY GENERATED AND SHOULD NOT BE EDITED MANUALLY!");
        Write();
    }
}