using NotificationSystem._Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem._Core.Interfaces
{
    public interface IObserver
    {
        public long CustomerId { get; set; }

        public string Name { get; }
        void Update(Notification notification);
        void SendMessage(string message, ISubject subject);
    }
}
