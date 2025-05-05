namespace EventProject.Domain.Entities;

public class Category:BaseEntity
{
    public string CategoryName { get; set; } = string.Empty;

    public string? Description { get; set; }
    
   
    public virtual ICollection<Event> Events { get; set; }
}
