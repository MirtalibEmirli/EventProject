namespace EventProject.Application.Exceptions;

public class UpdateFailedException:Exception
{
    public UpdateFailedException(string message):base(message)
    {
        
    }
}
