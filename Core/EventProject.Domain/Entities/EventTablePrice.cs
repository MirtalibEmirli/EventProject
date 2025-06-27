using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Domain.Entities
{
    public class EventTablePrice:BaseEntity
    {
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }

        public Guid TableId { get; set; }
        public virtual Table Table { get; set; }

        public float Price { get; set; }
        public bool IsSold { get; set; }
    }

}
