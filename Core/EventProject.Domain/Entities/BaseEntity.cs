namespace EventProject.Domain.Entities;

public abstract class BaseEntity
{

    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime? CreatedDate { get; set; } = DateTime.Now;

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public bool? IsDeleted { get; set;}=false;


}
