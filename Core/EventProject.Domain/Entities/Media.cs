 
namespace EventProject.Domain.Entities
{
    public class Media
    {
        public int Id { get; set; }//identity
        //public required string FileName { get; set; }   
        public   string? Url { get; set; }  
        public   string? MediaType { get; set; }  

        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;
    }
}
