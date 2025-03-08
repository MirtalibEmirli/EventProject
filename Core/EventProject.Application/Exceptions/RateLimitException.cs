using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Exceptions;
 
    public class RateLimitException(string message):Exception(message)
    {
    }
 
