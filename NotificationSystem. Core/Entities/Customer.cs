using NotificationSystem._Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem._Core.Entities
{
    public class Customer : IObserver
    {
        public string Name { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }

        public virtual void Update(Notification notification)
        {
            Console.WriteLine($"{Name} received notification: {notification.Message}");
        }

        public void SendMessage(string message, ISubject subject)
        {
            Console.WriteLine($"{Name} sends message to e-commerce business: {message}");
            subject.MessageFromObserver(this, "Thank you for your query. We will get back to you shortly.");
        }
    }

}
