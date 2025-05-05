namespace EventProject.Domain.Entities;

public class EventMediaFile:File
{
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; } = null!;
     
}
