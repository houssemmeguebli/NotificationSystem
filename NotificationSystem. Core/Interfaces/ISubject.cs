using NotificationSystem._Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem._Core.Interfaces
{
    public interface ISubject
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void NotifyObservers(Notification notification);
        void RespondToObserver(IObserver observer, string message);
    }
}
