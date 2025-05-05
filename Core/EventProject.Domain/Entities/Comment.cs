
namespace EventProject.Domain.Entities;
public class Comment:BaseEntity
{

    public string Content { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public Guid EventId { get; set; }
    public virtual Event Event { get; set; } = null!;

    public Guid? ParentCommentId { get; set; }
    public virtual Comment ParentComment { get; set; }

    public virtual ICollection<Comment> Replies { get; set; } = new List<Comment>();




}
