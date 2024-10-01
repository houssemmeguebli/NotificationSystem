using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem._Core.Interfaces
{
    public interface INotificationService
    {
        void AddProductAndNotify(string productName);
        void SubscribeCustomer(IObserver observer);
        void UnsubscribeCustomer(IObserver observer);
    }
}
