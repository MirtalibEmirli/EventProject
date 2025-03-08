namespace EventProject.Domain.Entities;

public abstract class BaseEntity
{

    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime? CreatedDate { get; set; } = DateTime.Now;

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; } = null;

    public bool? IsDeleted { get; set;}=false;


}
