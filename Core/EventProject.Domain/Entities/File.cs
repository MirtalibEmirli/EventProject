using EventProject.Domain.Enums;

namespace EventProject.Domain.Entities;

public class File:BaseEntity
{
    public string FileName { get; set; } = null!;
    public string Path { get; set; } = null!;
    public StorageType StorageType { get; set; }
  
}
