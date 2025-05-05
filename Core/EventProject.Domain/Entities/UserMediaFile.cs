
namespace EventProject.Domain.Entities;

public class UserMediaFile:File
{
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; } = null!;
}
