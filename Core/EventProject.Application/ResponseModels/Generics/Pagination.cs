using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.ResponseModels.Generics;

public class Pagination<T>
{

    public List<T> Items { get; set; }

    public int TotalCount { get; set; }

    public Pagination()
    {
        Items = new List<T>();
        TotalCount = 0;
    }

}
