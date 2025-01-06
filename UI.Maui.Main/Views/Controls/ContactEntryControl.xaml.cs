using Microsoft.Maui.Controls;

namespace UI.Maui.Main.Views.Controls;

public partial class ContactEntryControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;


    public string FirstName 
    {
        get => firstName.Text;
        
        set
        {
            firstName.Text = value;
        }
    }
    public string LastName
    {
        get => lastName.Text;

        set
        {
            lastName.Text = value;
        }
    }
    public string Email
    {
        get => email.Text;

        set
        {
            email.Text = value;
        }
    }
    public string PhoneNumber
    {
        get => phoneNumber.Text;

        set
        {
            phoneNumber.Text = value;
        }
    }
    public string Address
    {
        get => address.Text;

        set
        {
            address.Text = value;
        }
    }
    public string PostalCode
    {
        get => postalCode.Text;

        set
        {
            postalCode.Text = value;
        }
    }
    public string City
    {
        get => city.Text;

        set
        {
            city.Text = value;
        }
    }


    public ContactEntryControl()
	{
		InitializeComponent();
		
	}

	

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (firstNameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "First name need to be at least 2 characters long");
            return;
        }

        if (lastNameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Last name need to be at least 2 characters long");
            return;
        }

        if (emailValidator.IsNotValid)
        {
            string error = "";

            foreach (var err in emailValidator.Errors)
            {
                error += $"{err}\n";
            }

            OnError?.Invoke(sender, error);
            return;
        }

        OnSave?.Invoke(sender, e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}