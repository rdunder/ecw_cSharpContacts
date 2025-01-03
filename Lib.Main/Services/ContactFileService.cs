using Lib.Main.Interfaces;
using System.Diagnostics;

namespace Lib.Main.Services;

public class ContactFileService : IFileService
{
    private readonly string _basePath;
    private readonly string _filePath;

    public ContactFileService(string basePath, string fileName)
    {
        _basePath = basePath;
        _filePath = Path.Combine(basePath, fileName);

        if (!Directory.Exists(_basePath)) Directory.CreateDirectory(_basePath);
        if (!File.Exists(_filePath)) File.WriteAllText(_filePath, "[]");
    }

    public string GetContentFromFile()
    {
        try
        {
            return File.ReadAllText(_filePath);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("You got errors in FileService.GetContentFromFile: " + ex.Message);
            return String.Empty;
        }
    }

    public bool WriteContentToFile(string content)
    {
        if (string.IsNullOrWhiteSpace(content)) return false;

        try
        {
            File.WriteAllText(_filePath, content);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("You got errors in FileService.GetContentFromFile: " + ex.Message);
            return false;
        }
    }
}
