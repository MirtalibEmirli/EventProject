
namespace EventProject.Domain.Entities
{
    public class Media
    {
        public int Id { get; set; }
        public required string FileName { get; set; }   
        public required string Url { get; set; }  
        public required string MediaType { get; set; }  

        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;
    }
}
