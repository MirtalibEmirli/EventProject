namespace EventProject.Application.DTOs;

public class GetTrendingEventsDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public DateTime StartDate { get; set; }
    public int MinPrice { get; set; }
    public int MaxPrice { get; set; }
    public List<string> MediaUrls { get; set; }


}
