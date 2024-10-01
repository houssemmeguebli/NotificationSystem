using AutoMapper;
using NotificationSystem._Core.Entities;
using NotificationSystem._Core.Interfaces;
using NotificationSystem.Application.Dtos;
using System;
using System.Collections.Generic;

namespace NotificationSystem.Application.Services
{
    public class ECommerceBusiness : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        private readonly IMapper _mapper;

        public ECommerceBusiness(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper cannot be null.");
        }

        public void Subscribe(IObserver observer)
        {
            if (observer == null)
            {
                Console.WriteLine("Observer cannot be null.");
                return;
            }

            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                Console.WriteLine($"{observer.Name} has subscribed to notifications.");
            }
            else
            {
                Console.WriteLine($"{observer.Name} is already subscribed.");
            }
        }

        public void Unsubscribe(IObserver observer)
        {
            if (observer == null)
            {
                Console.WriteLine("Observer cannot be null.");
                return;
            }

            if (_observers.Remove(observer))
            {
                Console.WriteLine($"{observer.Name} has unsubscribed from notifications.");
            }
            else
            {
                Console.WriteLine($"{observer.Name} was not subscribed.");
            }
        }

        public void NotifyObservers(NotificationDto notificationDto)
        {
            if (notificationDto == null)
            {
                Console.WriteLine("NotificationDto cannot be null.");
                return;
            }

            Notification notification;
            try
            {
                // Map NotificationDto to Notification
                notification = _mapper.Map<Notification>(notificationDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mapping NotificationDto to Notification: {ex.Message}");
                return; // Exit if mapping fails
            }

            // Notify all observers
            foreach (var observer in _observers)
            {
                try
                {
                    observer.Update(notification);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error notifying observer {observer.Name}: {ex.Message}");
                }
            }
        }

        public void RespondToObserver(IObserver observer, string message)
        {
            if (observer == null)
            {
                Console.WriteLine("Observer cannot be null.");
                return;
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("Response message cannot be empty.");
                return;
            }

            Console.WriteLine($"Response to {observer.Name}: {message}");
        }

        public void NotifyObservers(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
