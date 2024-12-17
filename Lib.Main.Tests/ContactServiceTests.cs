

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

    //  Add Assert that this returns true
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
        _sut.AddContact(contactFormModel);

        //  Assert
        var contacts = _sut.GetAllContacts();
        Assert.Equal(contacts.First().FirstName, contactFormModel.FirstName);
        
    }

    //  This test has to be change, the funktion should return a bool so its easier to test.
    [Fact]
    public void AddContact_ShouldCatchExceptionBecauseOfFileService()
    {
        //  Arrange
        fileServiceMock.Setup(fs => fs.WriteContentToFile(It.IsAny<string>())).Returns(false);

        ContactFormModel contactFormModel = new ContactFormModel()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com",
        };


        //  Act & Assert
        Assert.ThrowsAny<Exception>(() => _sut.AddContact(contactFormModel));
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
