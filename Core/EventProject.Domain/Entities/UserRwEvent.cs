namespace EventProject.Domain.Entities;
public class UserRwEvent : BaseEntity
{
    public Guid EventId { get; set; }
    public Event Event { get; set; } = null!;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}
