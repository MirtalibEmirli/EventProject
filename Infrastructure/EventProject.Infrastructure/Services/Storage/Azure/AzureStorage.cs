

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EventProject.Application.Abstractions.Storage.Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace EventProject.Infrastructure.Services.Storage.Azure;

public class AzureStorage : IAzureStorage
{
    private readonly BlobServiceClient _blobServiceClient;
    BlobContainerClient _blobContainerClient;

    public AzureStorage(IConfiguration configuration)
    {
        _blobServiceClient = new(configuration["Storage:Azure"]);
    }

    public async Task DeleteAsync(string containerName, string fileName)
    {

        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
        await blobClient.DeleteAsync();
    }

    public List<string> GetFiles(string containerName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        return _blobContainerClient.GetBlobs().Select(b => b.Name).ToList();
    }

    public bool HasFile(string containerName, string fileName)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
    }

    public async Task<List<(string fileName, string pathOrContainer)>> UploadAsync(string containerName, IFormFileCollection files)
    {
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        await _blobContainerClient.CreateIfNotExistsAsync();
        await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

        List<(string fileName, string pathOrContainerClient)> datas = new();
        foreach(var file in files)
        {
            BlobClient blobClient = _blobContainerClient.GetBlobClient(file.FileName);
            await blobClient.UploadAsync(file.OpenReadStream());
            datas.Add((file.FileName, $"{containerName}/{file.FileName}"));

        }
        return datas;



    }
}
