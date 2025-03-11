using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.ResponseModels.Generics
{
    public class ResponseModelPagination<T>:BaseResponseModel
    {

     public   Pagination<T>? Data { get; set; }
        public ResponseModelPagination()
        {

        }
        public ResponseModelPagination(  List<string> messages ):base( messages ) 
        {
            
        }
    }
}
