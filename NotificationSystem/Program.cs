using AutoMapper;
using NotificationSystem._Core.Entities;
using NotificationSystem.Application.Dtos;
using NotificationSystem.Application.Services;


// Create an instance of the mapper configuration
var config = new MapperConfiguration(cfg =>
{
    // Add your mapping profiles here
    cfg.CreateMap<NotificationDto, Notification>();
});
var mapper = config.CreateMapper();

// Create the e-commerce business
var eCommerceBusiness = new ECommerceBusiness(mapper);

// Create customer instances (observers)
var customer1 = new Customer("Alice");
var customer2 = new Customer("Bob");
var customer3 = new Customer("Charlie");

// Subscribe customers to notifications
eCommerceBusiness.Subscribe(customer1);
eCommerceBusiness.Subscribe(customer2);
eCommerceBusiness.Subscribe(customer3);

// Add a new notification (this will notify all subscribers)
var notificationDto = new NotificationDto { Message = "New product available!" };
eCommerceBusiness.NotifyObservers(notificationDto);

// Unsubscribe a customer and add another notification
eCommerceBusiness.Unsubscribe(customer1);
notificationDto = new NotificationDto { Message = "Special discount for loyal customers!" };
eCommerceBusiness.NotifyObservers(notificationDto);

// A customer sends a message back to the e-commerce business
eCommerceBusiness.RespondToObserver(customer2, "Do you have a discount on the new product?");
