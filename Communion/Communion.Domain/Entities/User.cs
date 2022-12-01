namespace Communion.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = null!;
    public string Name { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Bio { get; set; } = "Not specified.";
    public string Gender { get; set; } = "Not specified";
    public bool IsAdmin { get; set; } = false;
    public List<string> comments { get; set; } = new List<string>(); // Change to list of Comments
    public List<string> Posts { get; set; } = new List<string>();  // Change to list of Posts
    public string? ProfilePicture { get; set; } // Change to ProfilePicture model
    public DateTime? DateOfBirth { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
}