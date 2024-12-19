

using Lib.Main.Interfaces;
using Lib.Main.Models;
using Lib.Main.Services;
using Moq;

namespace Lib.Main.Tests;


//  The private funktions in this class is being tested as a side effect, thats why there is no specific tests for them.
//
//
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

    [Fact]
    public void GetContactById_ShouldReturnContactModel()
    {
        //  Arrange
        fileServiceMock.Setup(fs => fs.WriteContentToFile(It.IsAny<string>())).Returns(true);

        ContactFormModel contactFormModel = new ContactFormModel()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com",
        };

        _sut.AddContact(contactFormModel);

        var contacts = _sut.GetAllContacts();
        var existingId = contacts.First().Id;

        //  Act
        var result = _sut.GetContactById(existingId);

        //  Assert
        Assert.NotNull(result);
        Assert.IsType<ContactModel>(result);
        Assert.Equal(existingId, result.Id);
    }

    [Fact]
    public void GetContactById_ShouldReturnNull()
    {
        //  Arrange
        fileServiceMock.Setup(fs => fs.WriteContentToFile(It.IsAny<string>())).Returns(true);

        ContactFormModel contactFormModel = new ContactFormModel()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com",
        };

        _sut.AddContact(contactFormModel);

        var contacts = _sut.GetAllContacts();
        var existingId = contacts.First().Id;
        var notExistingId = Guid.NewGuid();

        //  Act
        var result = _sut.GetContactById(notExistingId);


        //  Assert
        Assert.Null(result);
    }

    [Fact]
    public void RemoveContact_ShouldReturnTrue()
    {
        //  Arrange
        fileServiceMock.Setup(fs => fs.WriteContentToFile(It.IsAny<string>())).Returns(true);

        ContactFormModel contactFormModel = new ContactFormModel()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com",
        };

        _sut.AddContact(contactFormModel);

        var contactsBeforeRemove = _sut.GetAllContacts();
        var existingId = contactsBeforeRemove.First().Id;

        //  Act
        var result = _sut.RemoveContact(existingId);
        var contactsAfterRemove = _sut.GetAllContacts();

        //  Assert
        Assert.True(result);
        Assert.True(contactsBeforeRemove.Count() > 0);
        Assert.True(contactsAfterRemove.Count() <= 0);
    }

    [Fact]
    public void RemoveContact_ShouldReturnFalseBecauseOfFileService()
    {
        //  Arrange
        fileServiceMock.Setup(fs => fs.WriteContentToFile(It.IsAny<string>())).Returns(false);

        ContactFormModel contactFormModel = new ContactFormModel()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com",
        };

        _sut.AddContact(contactFormModel);

        var contactsBeforeRemove = _sut.GetAllContacts();
        var existingId = contactsBeforeRemove.First().Id;


        //  Act
        var result = _sut.RemoveContact(existingId);
        var contactsAfterRemove = _sut.GetAllContacts();

        //  Assert
        Assert.True(!result);
    }

    [Fact]
    public void RemoveContact_ShouldReturnFalseBecauseOfNonExistingId()
    {
        //  Arrange
        fileServiceMock.Setup(fs => fs.WriteContentToFile(It.IsAny<string>())).Returns(true);

        ContactFormModel contactFormModel = new ContactFormModel()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com",
        };

        _sut.AddContact(contactFormModel);

        var contactsBeforeRemove = _sut.GetAllContacts();
        var existingId = contactsBeforeRemove.First().Id;
        var notExistingId = Guid.NewGuid();


        //  Act
        var result = _sut.RemoveContact(notExistingId);
        var contactsAfterRemove = _sut.GetAllContacts();

        //  Assert
        Assert.True(!result);
    }

    [Fact]
    public void UpdateContact_SHouldUpdateContactAndReturnTrue()
    {
        //  Arrange
        fileServiceMock.Setup(fs => fs.WriteContentToFile(It.IsAny<string>())).Returns(true);

        var contactFormBeforeUpdate = new ContactFormModel()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com",
        };

        var contactFormAfterUpdate = new ContactFormModel()
        {
            FirstName = "tseT",
            LastName = "Test",
            Email = "test@domain.com",
        };

        _sut.AddContact(contactFormBeforeUpdate);

        var contactsBeforeUpdate = _sut.GetAllContacts();

        //  Act
        var result = _sut.UpdateContact(contactsBeforeUpdate.First().Id, contactFormAfterUpdate);
        var contactsAfterUpdate = _sut.GetAllContacts();

        //  Assert
        Assert.True(result);
        Assert.Equal(contactFormBeforeUpdate.FirstName, contactsBeforeUpdate.First().FirstName);
        Assert.Equal(contactFormAfterUpdate.FirstName, contactsAfterUpdate.First().FirstName);
        Assert.NotEqual(contactsBeforeUpdate.First().FirstName, contactsAfterUpdate.First().FirstName);
        
    }

    [Fact]
    public void UpdateContact_SHouldReturnFalseBecauseOfNonExistingId()
    {
        //  Arrange
        fileServiceMock.Setup(fs => fs.WriteContentToFile(It.IsAny<string>())).Returns(true);

        var contactFormBeforeUpdate = new ContactFormModel()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com",
        };

        var contactFormAfterUpdate = new ContactFormModel()
        {
            FirstName = "tseT",
            LastName = "Test",
            Email = "test@domain.com",
        };

        _sut.AddContact(contactFormBeforeUpdate);

        var contactsBeforeUpdate = _sut.GetAllContacts();

        //  Act
        var result = _sut.UpdateContact(Guid.NewGuid(), contactFormAfterUpdate);
        var contactsAfterUpdate = _sut.GetAllContacts();

        //  Assert
        Assert.True(!result);

    }



}
