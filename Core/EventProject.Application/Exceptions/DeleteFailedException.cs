using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Exceptions;

public class DeleteFailedException:Exception
{
    public DeleteFailedException(string  message):base(message)
    {}
}
