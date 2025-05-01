
namespace EventProject.Domain.Entities;
public class Comment:BaseEntity
{
    public Guid UserId { get; set; }
   
    public User User { get; set; } = null!;

    public Guid EventId { get; set; }
    
    public Event Event { get; set; } = null!;

    public string Content { get; set; } = string.Empty;

    public int Rating { get; set; } // 1-5 ulduz

    
}
