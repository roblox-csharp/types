using System.Text.Json;

namespace TypeGenerator;

internal static class Utility
{
    public static string? SafePropType(string? valueType) =>
        string.IsNullOrEmpty(valueType)
            ? null
            : Constants.PROP_TYPE_MAP.GetValueOrDefault(valueType, valueType);

    public static string? SafeRenamedInstance(string? name) =>
        name != null && Constants.RENAMABLE_AUTO_TYPES.TryGetValue(name, out var value)
            ? value
            : SafeName(name);

    public static string SafeValueType(APITypes.ValueType valueType)
    {
        if (valueType.Category == "Enum") return $"Enum.{valueType.Name}";

        var valueTypeName = SafeName(valueType.Name)!;

        if (string.IsNullOrEmpty(valueTypeName) || !valueTypeName.EndsWith('?')) return Constants.VALUE_TYPE_MAP.GetValueOrDefault(valueType.Name, valueTypeName);

        var nonOptionalType = valueTypeName[..^1];
        var mappedType = Constants.VALUE_TYPE_MAP.GetValueOrDefault(nonOptionalType, nonOptionalType);

        return $"{mappedType}?";
    }

    public static string? SafeReturnType(string? valueType) =>
        string.IsNullOrEmpty(valueType)
            ? null
            : Constants.RETURN_TYPE_MAP.GetValueOrDefault(valueType, valueType);

    public static string? SafeParamName(string? name) =>
        name != null && Constants.PARAM_NAME_MAP.TryGetValue(name, out var value)
            ? value
            : name;

    public static APITypes.Security GetSecurity(string className, APITypes.MemberBase member)
    {
        if (!Constants.SECURITY_OVERRIDES.TryGetValue(className, out var classSecurity))
            return member.MemberType switch
            {
                "Callback" => new APITypes.Security { Read = "NotAccessibleSecurity", Write = member.Security?.ToString()! },
                "Function" => new APITypes.Security { Read = member.Security?.ToString()!, Write = "NotAccessibleSecurity" },
                "Event" => new APITypes.Security { Read = member.Security?.ToString()!, Write = "NotAccessibleSecurity" },
                "Property" => JsonSerializer.Deserialize<APITypes.Security>(member.Security?.ToString()!)!,
                _ => throw new NotSupportedException($"Member type not supported: {member.MemberType}")
            };

        if (member.Name != null && classSecurity!.TryGetValue(member.Name, out var securityOverride)) return securityOverride;

        return member.MemberType switch
        {
            "Callback" => new APITypes.Security { Read = "NotAccessibleSecurity", Write = member.Security?.ToString()! },
            "Function" => new APITypes.Security { Read = member.Security?.ToString()!, Write = "NotAccessibleSecurity" },
            "Event" => new APITypes.Security { Read = member.Security?.ToString()!, Write = "NotAccessibleSecurity" },
            "Property" => JsonSerializer.Deserialize<APITypes.Security>(member.Security?.ToString()!)!,
            _ => throw new NotSupportedException($"Member type not supported: {member.MemberType}")
        };
    }

    public static bool HasTag(APITypes.MemberBase container, string tag) =>
        container.Tags != null && container.Tags.Select(t => t.ToString()).Contains(tag);

    public static bool HasTag(APITypes.Class container, string tag) =>
        container.Tags != null && container.Tags.Select(t => t.ToString()).Contains(tag);

    public static bool IsCreatable(APITypes.Class rbxClass) =>
        !Constants.CREATABLE_BLACKLIST.Contains(rbxClass.Name)
     && !HasTag(rbxClass, "NotCreatable")
     && !HasTag(rbxClass, "Service");

    public static string FormatComment(string s) => string.Join('\n', s.Trim().Split('\n').Select(d => $"# {d}"));
    
    public static string SafeName(string? name) =>
        name == null
            ? ""
            : ContainsBadChar(name)
                ? name.Replace("\"", "\\\"")
                : name;

    private static bool ContainsBadChar(string name) => Constants.BAD_NAME_CHARS.Any(name.Contains);

    // public static List<List<T>> Multifilter<T>(List<T> list, int resultArrAmount, Func<T, int> condition)
    // {
    //     var results = new List<List<T>>();
    //     for (var i = 0; i < resultArrAmount; i++)
    //         results.Add([]);
    //
    //     foreach (var element in list)
    //         results[condition(element)].Add(element);
    //
    //     return results;
    // }
}