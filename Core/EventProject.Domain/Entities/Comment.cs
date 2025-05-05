
namespace EventProject.Domain.Entities;
public class Comment:BaseEntity
{

    public string Content { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid EventId { get; set; }
    public Event Event { get; set; } = null!;

    public Guid? ParentCommentId { get; set; }
    public Comment ParentComment { get; set; }

    public ICollection<Comment> Replies { get; set; } = new List<Comment>();




}
