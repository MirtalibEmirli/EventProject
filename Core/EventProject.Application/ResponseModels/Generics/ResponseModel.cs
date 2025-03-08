
namespace EventProject.Application.ResponseModels.Generics;

public class ResponseModel<T>:BaseResponseModel
{

  public  T? Data { get; set; }   
    public ResponseModel()
    {
            
    }

    public ResponseModel(List<string> messages):base(messages) 
    {
        
    }


}
