﻿namespace TypeGenerator.Generators
{
    internal sealed class EnumGenerator : Generator
    {
        public EnumGenerator(string filePath, ReflectionMetadataReader reflectionMetadata)
            : base(filePath, reflectionMetadata) { }

        public void Generate(APITypes.Enum[] rbxEnums)
        {
            Write("// THIS FILE IS AUTOMATICALLY GENERATED AND SHOULD NOT BE EDITED MANUALLY!");
            Write("// GENERATED ROBLOX ENUMS");
            Write();

            Write("namespace Roblox.Enum");
            Write("{");
            PushIndent();
            foreach (var rbxEnum in rbxEnums)
            {
                var enumTypeName = rbxEnum.Name;
                var enumItems = rbxEnum.Items;
                Write($"public struct {enumTypeName}");
                Write("{");
                PushIndent();
                Write("/// <summary>Returns an array of all <see cref=\"EnumItem\"/> options available for this enum.</summary>");
                Write("public EnumItem[] GetEnumItems()");
                Write("{");
                PushIndent();
                Write("return null!;");
                PopIndent();
                Write("}");
                Write();

                foreach (var item in enumItems)
                {
                    var itemLegacyNames = item.LegacyNames ?? [];
                    Write($"public struct {item.Name} : EnumItem");
                    Write("{");
                    PushIndent();

                    // no public modifier & direct access to avoid naming conflicts
                    Write("string EnumItem.Name => \"" + item.Name + "\";");
                    Write("uint EnumItem.Value => " + item.Value + ";");
                    Write("string EnumItem.EnumType => \"" + enumTypeName + "\";");

                    PopIndent();
                    Write("}");
                    if (item != enumItems.Last())
                    {
                        Write();
                    }
                }

                PopIndent();
                Write("}");

                if (rbxEnum != rbxEnums.Last())
                {
                    Write();
                }
            }

            PopIndent();
            Write("}");
            WriteFile();
        }
    }
}