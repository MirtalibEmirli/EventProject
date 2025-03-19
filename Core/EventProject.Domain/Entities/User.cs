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

    public Guid? ProfilePictureId { get; set; }
    public UserMediaFile? ProfilePicture { get; set; } = null!;

    public ICollection<Event> OrganizedEvents { get; set; } 
    public ICollection<Ticket> Tickets { get; set; } 
    public ICollection<Comment> Comments { get; set; } 
    public ICollection<Payment> Payments { get; set; }

}
