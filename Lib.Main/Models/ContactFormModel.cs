
using System.ComponentModel.DataAnnotations;

namespace Lib.Main.Models;

public class ContactFormModel
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
}
