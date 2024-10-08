﻿using AutoMapper;
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

        public void NotifyObservers(List<NotificationDto> notificationDtos)
        {
            if (notificationDtos == null || notificationDtos.Count == 0)
            {
                Console.WriteLine("Notification list cannot be null or empty.");
                return;
            }

            foreach (var notificationDto in notificationDtos)
            {
                try
                {
                    // Map NotificationDto to Notification
                    var notification = _mapper.Map<Notification>(notificationDto);

                    // Find the correct customer by CustomerId
                    var observer = _observers.FirstOrDefault(o => o.CustomerId == notification.CustomerId);
                    if (observer != null)
                    {
                        observer.Update(notification);
                    }
                    else
                    {
                        Console.WriteLine($"No observer found for CustomerId {notification.CustomerId}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error mapping or notifying: {ex.Message}");
                }
            }
        }


        public void MessageFromObserver(IObserver observer, string message)
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

            Console.WriteLine($"Message From {observer.Name}: {message}");
        }

        public void NotifyObservers(Notification notification)
        {
            throw new NotImplementedException();
        }

        public void SendAnnouncement(NotificationDto notificationDto)
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

            // Notify all observers with the same message
            foreach (var observer in _observers)
            {
                try
                {
                    observer.Update(notification);
                    Console.WriteLine($"Announcement sent to {observer.Name}: {notification.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error notifying observer {observer.Name}: {ex.Message}");
                }
            }
        }

        public void SendAnnouncement(Notification notificationDto)
        {
            throw new NotImplementedException();
        }
    }
}
