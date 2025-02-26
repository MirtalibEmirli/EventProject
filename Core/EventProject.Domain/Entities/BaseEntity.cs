namespace EventProject.Domain.Entities;

public abstract class BaseEntity
{

    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public DateTime DeletedDate { get; set; }

    public bool IsDeleted { get; set;}


}
