using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.DTOs
{
    public class SeatPriceDTO
    {
      

             
        public string Section { get; set; } = string.Empty;
   
        public float? Price { get; set; }
        public int Available { get; set; }
    }
}
