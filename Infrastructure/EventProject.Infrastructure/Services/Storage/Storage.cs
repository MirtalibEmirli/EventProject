using EventProject.Infrastructure.Operations;
using System.Formats.Tar;

namespace EventProject.Infrastructure.Services.Storage;

public class Storage
{
    protected delegate bool HasFile(string pathOrContainerName, string fileName);

    protected async Task<string> FileRenameAsync(string pathOrContainerName, string fileName, HasFile hasFileMethod)
    {
        string extension = Path.GetExtension(fileName);
        string baseName = Path.GetFileNameWithoutExtension(fileName);
        baseName = NameOperation.CharacterRegulatory(baseName);  

        string newFileName = $"{baseName}{extension}";
        int counter = 1;

        while (hasFileMethod(pathOrContainerName, newFileName))
        {
            newFileName = $"{baseName}-{counter}{extension}";
            counter++;
        }

        return newFileName;
    }

}
