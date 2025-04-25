using System.Text;

namespace TypeGenerator.Generators;

internal abstract class Generator(string filePath, ReflectionMetadataReader? metadata = null)
{
    private readonly MemoryStream _stream = new();
    private string _indent = "";

    private ReflectionMetadataReader? _metadata = metadata;

    protected void WriteFile()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
        File.WriteAllText(filePath, GetStringFromMemoryStream());
    }

    protected void Write(string line = "") =>
        _stream.Write(Encoding.UTF8.GetBytes($"{_indent}{line}\n"));
        
    protected void PushIndent() => _indent += "\t";
    protected void PopIndent() => _indent = _indent[1..];
    private string GetStringFromMemoryStream() => Encoding.UTF8.GetString(_stream.ToArray());
}