

using Lib.Main.Interfaces;
using Lib.Main.Models;
using Lib.Main.Services;
using Moq;

namespace Lib.Main.Tests;

public class ContactServiceTests
{
    IContactService _sut;
    Mock<IFileService> fileServiceMock;

    public ContactServiceTests()
    {
        fileServiceMock = new Mock<IFileService>();
        _sut = new ContactService(fileServiceMock.Object);
    }

    [Fact]
    public void AddContact_ShouldAddContactToList()
    {
        //  Arrange
        fileServiceMock.Setup(fs => fs.WriteContentToFile(It.IsAny<string>())).Returns(true);

        ContactFormModel contactFormModel = new ContactFormModel()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com",
        };

        //  Act
        bool result = _sut.AddContact(contactFormModel);

        //  Assert
        var contacts = _sut.GetAllContacts();
        Assert.True(result);
        Assert.Equal(contacts.First().FirstName, contactFormModel.FirstName);
        
    }

    [Fact]
    public void AddContact_ShouldReturnFalseBecauseOfFileService()
    {
        //  Arrange
        fileServiceMock.Setup(fs => fs.WriteContentToFile(It.IsAny<string>())).Returns(false);

        ContactFormModel contactFormModel = new ContactFormModel()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com",
        };

        //  Act
        var result = _sut.AddContact(contactFormModel);

        //  Act & Assert
        Assert.False(result);
    }

    [Fact]
    public void GetAllContacts_SHouldReturnListOfTypeContactModel()
    {
        //  Arrange

        //  Act
        var result = _sut.GetAllContacts();

        //  Assert
        Assert.NotNull(result);
        Assert.IsType<List<ContactModel>>(result);
    }
}
