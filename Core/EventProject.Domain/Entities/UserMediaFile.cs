
namespace EventProject.Domain.Entities;

public class UserMediaFile:File
{
    public Guid EventId { get; set; }
    public Event Event { get; set; } = null!;
}
