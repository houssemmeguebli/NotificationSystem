using AutoMapper;
using NotificationSystem._Core.Entities;
using NotificationSystem.Application.Dtos;
using NotificationSystem.Application.Services;

// Setup AutoMapper Configuration
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<NotificationDto, Notification>(); // Add mapping profile for Notification
});
var mapper = config.CreateMapper();

// Create the e-commerce business instance
var eCommerceBusiness = new ECommerceBusiness(mapper);

// Create customer instances (observers)
var customer1 = new Customer("Alice");
var customer2 = new Customer("Bob");
var customer3 = new Customer("Charlie");

// Subscribe customers to notifications
eCommerceBusiness.Subscribe(customer1);
Console.WriteLine();

eCommerceBusiness.Subscribe(customer2);
Console.WriteLine();

eCommerceBusiness.Subscribe(customer3);
Console.WriteLine();

// Add a new notification (this will notify all subscribers)
var notificationDto = new NotificationDto { Message = "New product available!" };
eCommerceBusiness.NotifyObservers(notificationDto);
Console.WriteLine();

// Unsubscribe a customer
eCommerceBusiness.Unsubscribe(customer1);
Console.WriteLine();

// Add another notification after unsubscribing a customer
notificationDto = new NotificationDto { Message = "Special discount for loyal customers!" };
eCommerceBusiness.NotifyObservers(notificationDto);
Console.WriteLine();

// A customer sends a message back to the e-commerce business
eCommerceBusiness.MessageFromObserver(customer2, "Do you have a discount on the new product?");
Console.WriteLine();

// Create a big announcement to all customers using NotificationDto

var bigAnnouncementDto = new NotificationDto { Message = "Big sale coming up this weekend! Don't miss out on discounts up to 50%!" };
eCommerceBusiness.SendAnnouncement(bigAnnouncementDto);
Console.WriteLine();
