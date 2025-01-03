using Lib.Main.Factories;
using Lib.Main.Models;

namespace Lib.Main.Tests;

public class ContactFactoryTests
{
    [Fact]
    public void Create_ShouldReturnFormModel()
    {
        //  Arrange

        //  Act
        ContactFormModel contactFormModel = ContactFactory.Create();

        //  Assert
        Assert.NotNull(contactFormModel);
        Assert.IsType<ContactFormModel>(contactFormModel);
    }

    [Fact]
    public void Create_ShouldReturnEntity()
    {
        //  Arrange
        ContactFormModel formModel = new ContactFormModel()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com",
        };

        //  Act
        ContactEntity entity = ContactFactory.Create(formModel);

        //  Assert
        Assert.NotNull(entity);
        Assert.IsType<ContactEntity>(entity);
        Assert.Equal(entity.FirstName, formModel.FirstName);
    }

    [Fact]
    public void Create_ShouldReturnModel()
    {
        //  Arrange
        ContactEntity entity = new ContactEntity()
        {
            Id = Guid.NewGuid(),
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com"
        };

        //  Act
        ContactModel model = ContactFactory.Create(entity);

        //  Assert
        Assert.NotNull(model);
        Assert.IsType<ContactModel>(model);
        Assert.Equal(model.FirstName, entity.FirstName);
    }

    [Fact]
    public void Create_ShouldReturnFormModelWhenParamIsModel()
    {
        //  Arrange
        ContactModel model = new ContactModel()
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "test@domain.com",
            PhoneNumber = "1234567890"
        };

        //  Act
        ContactFormModel formModel = ContactFactory.Create(model);

        //  Assert
        Assert.NotNull(formModel);
        Assert.IsType<ContactFormModel>(formModel);
        Assert.Equal(model.FirstName, formModel.FirstName);
    }
}
