

using Lib.Main.Services;

namespace Lib.Main.Tests;

public class ContactFileServiceTests
{
    [Fact]
    public void Constructor_CreatesDirectoryAndFileIfNotExists()
    {
        // Arrange
        string testBasePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        string testFileName = "DialHardTestFile.json";

        // Act
        var _sut = new ContactFileService(testBasePath, testFileName);

        // Assert
        Assert.True(Directory.Exists(testBasePath));
        Assert.True(File.Exists(Path.Combine(testBasePath, testFileName)));

        // Cleanup
        Directory.Delete(testBasePath, true);
    }

    [Fact]
    public void GetContentFromFile_ShouldReturnContentAsString()
    {
        //  Arrange
        string testBasePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        string testFileName = "DialHardTestFile.json";
        string expectedContent = "Test file content";

        var _sut = new ContactFileService(testBasePath, testFileName);

        File.WriteAllText(Path.Combine(testBasePath, testFileName), expectedContent);


        //  Act
        string accualContent = _sut.GetContentFromFile();

        //  Assert
        Assert.NotNull(accualContent);
        Assert.Equal(expectedContent, accualContent);

        //  Cleanup
        Directory.Delete(testBasePath, true);
    }

    [Fact]
    public void GetContentFromFile_ShouldReturnEmptyStringWhenInvalidPath()
    {
        // Arrange
        string testBasePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        string testFileName = "nonexistent.json";

        var _sut = new ContactFileService(testBasePath, testFileName);
        File.Delete(Path.Combine(testBasePath, testFileName));

        // Act
        string result = _sut.GetContentFromFile();

        // Assert
        Assert.Equal(string.Empty, result);

        // Cleanup
        Directory.Delete(testBasePath, true);
    }

    [Fact]
    public void WriteContentToFile_ShouldReturnTrueWhenValidContent()
    {
        //  Arrange
        string testBasePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        string testFileName = "DialHardTestFile.json";
        string testContent = "Test file content";

        var _sut = new ContactFileService(testBasePath, testFileName);

        // Act
        bool result = _sut.WriteContentToFile(testContent);

        // Assert
        Assert.True(result);

        string writtenContent = File.ReadAllText(Path.Combine(testBasePath, testFileName));
        Assert.Equal(testContent, writtenContent);

        // Cleanup
        Directory.Delete(testBasePath, true);
    }

    [Fact]
    public void WriteContentToFile_ShouldReturnFalseWhenContentEmpty()
    {
        //  Arrange
        string testBasePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        string testFileName = "DialHardTestFile.json";

        var _sut = new ContactFileService(testBasePath, testFileName);

        // Act
        bool result = _sut.WriteContentToFile("");

        // Assert
        Assert.False(result);

        // Cleanup
        Directory.Delete(testBasePath, true);
    }

    [Fact]
    public void WriteContentToFile_ShouldReturnFalseWhenInvalidPath()
    {
        // Arrange
        string testBasePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        string testFileName = "nonexistent.json";
        string testContent = "Test file content";

        var _sut = new ContactFileService(testBasePath, testFileName);
        Directory.Delete(testBasePath, true);

        // Act
        bool result = _sut.WriteContentToFile(testContent);

        // Assert
        Assert.False(result);

        //  Cleanup
        if (Directory.Exists(testBasePath))
            Directory.Delete(testBasePath, true);
    }
}
