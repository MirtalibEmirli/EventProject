

using EventProject.Application.Abstractions.Storage.Azure;
using Microsoft.AspNetCore.Http;

namespace EventProject.Infrastructure.Services.Storage.Azure;

public class AzureStorage : IAzureStorage
{
    public Task DeleteAsync(string container, string fileName)
    {
        throw new NotImplementedException();
    }

    public List<string> GetFiles(string container)
    {
        throw new NotImplementedException();
    }

    public bool HasFile(string containerName, string fileName)
    {
        throw new NotImplementedException();
    }

    public Task<List<(string fileName, string pathOrContainer)>> UploadAsync(string container, IFormFileCollection files)
    {
        throw new NotImplementedException();
    }
}
