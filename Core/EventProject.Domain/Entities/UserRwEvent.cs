namespace EventProject.Domain.Entities;
public class UserRwEvent : BaseEntity
{
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; } = null!;

    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
}
