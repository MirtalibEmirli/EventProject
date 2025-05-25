
namespace EventProject.Domain.Entities;

public class UserMediaFile:File
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
}
