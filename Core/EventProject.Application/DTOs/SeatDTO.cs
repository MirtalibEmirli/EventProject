namespace EventProject.Application.DTOs;

public class SeatDTO
{
    public Guid Id { get; set; }
    public string Section { get; set; } = string.Empty;
    public int Row { get; set; } 
    public int Number { get; set; }
    public bool IsBooked { get; set; }
    public float? Price { get; set; }
}
