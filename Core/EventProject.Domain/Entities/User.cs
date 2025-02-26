using System.Net.Sockets;
using System.Xml.Linq;

namespace EventProject.Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Role { get; set; } = "User"; // Admin, User, EventManager

    public string? ProfilePicture { get; set; }



    public List<Event> OrganizedEvents { get; set; } = new();
    public List<Ticket> Tickets { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    public List<Payment> Payments { get; set; } = new();

}
