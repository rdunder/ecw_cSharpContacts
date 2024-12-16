﻿
namespace Lib.Main.Models;

public class ContactModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
}
