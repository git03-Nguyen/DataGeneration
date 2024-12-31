namespace MDataGeneration.Models;

public class User
{
    public ulong Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public string Country { get; set; } = string.Empty;
    public string? Postcode { get; set; }
    public string? Phone { get; set; }
    public DateTime Dob { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? Password { get; set; } = "$2y$10$pvW9Ixi7okDIJC98Vte6e.iAMD6IZAxAR2V.SjW.m1.u5guoq1wxW";
    public string Role { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
    public int FailedLoginAttempts { get; set; } = 0;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}