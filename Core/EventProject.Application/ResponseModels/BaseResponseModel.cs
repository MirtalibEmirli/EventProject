using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.ResponseModels;

public class BaseResponseModel
{

    public List<string> Errors { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public BaseResponseModel()
    {
        IsSuccess=true;
        Errors = null;
    }

    public BaseResponseModel(List<string> errors )
    {
        Errors = errors;
        IsSuccess = false;
    }
}
