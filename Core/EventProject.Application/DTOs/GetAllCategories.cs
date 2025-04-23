namespace EventProject.Application.DTOs;

public class GetAllCategories
{
    public string Id { get; set; } = null!;
    public string CategoryName { get; set; }
    public string? Description { get; set; }
}
