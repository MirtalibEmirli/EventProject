namespace EventProject.Domain.Entities;

public class Category:BaseEntity
{
    public string CategoryName { get; set; } = string.Empty;

    public string? Description { get; set; }
    
    //// Relations
    //public List<Event> Events { get; set; } = new();
}
