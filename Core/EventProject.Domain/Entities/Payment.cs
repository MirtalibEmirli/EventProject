using EventProject.Domain.Entities;

public class Payment:BaseEntity
{

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid EventId { get; set; }
    public Event Event { get; set; } = null!;

    public decimal Amount { get; set; }

    public string PaymentStatus { get; set; } = "Pending"; // Pending, Completed, Failed

    public string TransactionId { get; set; } = string.Empty;

    public string PaymentMethod { get; set; } = string.Empty; // Card, PayPal, etc.
}
