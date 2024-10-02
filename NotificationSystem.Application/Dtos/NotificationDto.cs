using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Application.Dtos
{
    public class NotificationDto : ICloneable
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone(); 
        }
    }
    
}
