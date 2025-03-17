using EventProject.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Http;


namespace EventProject.Infrastructure.Services.Storage;

public class LocalStorage : ILocalStorage
{

   

    public Task DeleteAsync(string pathOrContainer, string fileName)
    {
        throw new NotImplementedException();
    }

    public List<string> GetFiles(string pathOrContainer)
    {
        throw new NotImplementedException();
    }

    public bool HasFile(string pathOrContainerName, string fileName)
    {
        throw new NotImplementedException();
    }

    public Task<List<(string fileName, string pathOrContainer)>> UploadAsync(string pathOrContainer, IFormFileCollection files)
    {
        throw new NotImplementedException();
    }

   
}

