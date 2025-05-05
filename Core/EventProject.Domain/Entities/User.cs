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

    public virtual  Role Role { get; set; }  // Admin, User, EventManager

    public Guid? ProfilePictureId { get; set; }
    public virtual UserMediaFile? ProfilePicture { get; set; } = null!;

    public virtual ICollection<Event> OrganizedEvents { get; set; } 
    public virtual ICollection<Ticket> Tickets { get; set; } 
    public  virtual ICollection<Comment> Comments { get; set; } 
    public virtual ICollection<Payment> Payments { get; set; }
    public virtual ICollection<UserRwEvent> UserRwEvents { get; set; }

}
