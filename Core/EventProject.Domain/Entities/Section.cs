namespace EventProject.Domain.Entities;

public class Section : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public virtual ICollection<SectionPrice> SectionPrices { get; set; }
  
    
}
