

using Lib.Main.Helpers;
using Lib.Main.Models;

namespace Lib.Main.Tests;

public class ContactJsonSerializerTests
{
    [Fact]
    public void Deserialize_ShouldReturnListOfContactEntities()
    {
        //  Arrange
        string testString = "[]";

        //  Act
        List<ContactEntity> result = ContactJsonSerializer.Deserialize(testString);

        //  Assert
        Assert.NotNull(result);
        Assert.IsType<List<ContactEntity>>(result);
    }

    [Fact]
    public void Serialize_ShouldReturnJsonString()
    {
        //  Arrange
        List<ContactEntity> testList = new List<ContactEntity>();

        //  Act
        string result = ContactJsonSerializer.Serialize(testList);

        //  Assert
        Assert.NotNull(result);
        Assert.IsType<string>(result);
    }

    [Fact]
    public void Serialize_ShouldReturnNull()
    {
        //  Arrange
        List<ContactEntity> testList = null!;

        //  Act
        var result = ContactJsonSerializer.Serialize(testList);

        //  Assert
        //Assert.Null(result);

        Assert.Equal("null", result);
    }
}
