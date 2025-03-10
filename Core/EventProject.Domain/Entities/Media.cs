
namespace EventProject.Domain.Entities
{
    public class Media
    {
        public required string FileName { get; set; }
        public required string Url { get; set; } //buna defaultda vermek olar birde birbasa sekili clouda yukleyecem localda qalmasin
        public int Id { get; set; }

    }
}
