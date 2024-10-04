using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem._Core.Entities
{
    public class Notification : ICloneable
    {
   

        public string Message { get; set; }
        public long CustomerId { get; set; }
        public DateTime Date { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone(); 
        }
    }
}
