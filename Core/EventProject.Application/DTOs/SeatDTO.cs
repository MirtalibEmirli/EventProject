namespace EventProject.Application.DTOs;

public class SeatDTO
{
    public Guid Id { get; set; }
    public string Section { get; set; } = null!;
    public int Row { get; set; }
    public int Number { get; set; }
    public int? Capacity { get; set; }
    public float? X { get; set; }
    public float? Y { get; set; }
    public float? Z { get; set; }
    public float? RotationY { get; set; }
}
