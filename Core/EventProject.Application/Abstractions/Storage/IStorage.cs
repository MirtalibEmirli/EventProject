using Microsoft.AspNetCore.Http;

namespace EventProject.Application.Abstractions.Storage;

public interface IStorage
{
    Task<List<(string fileName, string pathOrContainer)>> UploadAsync(string pathOrContainer, IFormFileCollection files);
    Task DeleteAsync(string pathOrContainer,string fileName);
    List<string> GetFiles(string pathOrContainer);
    bool HasFile(string pathOrContainerName,string fileName);

}
