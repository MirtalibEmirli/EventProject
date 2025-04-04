namespace EventProject.Application.Exceptions;

public class NotFoundException:Exception
{
    public NotFoundException(Type type ,int id):base($"{type} not found  with id : {id} in the database")
    {
            
    }
    public NotFoundException(string message):base(message) 
    {
        
    }
}
