using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.DTOs
{
    public class Token
    {
       public string AccessToken { get;set; }
        public DateTime ExpirationDate { get;set; }
    }
}
