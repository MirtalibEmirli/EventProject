using EventProject.Domain.Enums;
using System.Net.Sockets;
using System.Xml.Linq;

namespace EventProject.Domain.Entities;

public class User : BaseEntity
{
    public string Fistname { get; set; } = string.Empty;
    public string Lastname { get; set; }= string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public Role Role { get; set; }  // Admin, User, EventManager

    public string? ProfilePicture { get; set; }



    public List<Event> OrganizedEvents { get; set; } = new();
    public List<Ticket> Tickets { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    public List<Payment> Payments { get; set; } = new();

}
