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
var customer1 = new Customer(1, "Alice");
var customer2 = new Customer(2, "Bob");
var customer3 = new Customer(3, "Charlie");

// Subscribe customers to notifications
eCommerceBusiness.Subscribe(customer1);
Console.WriteLine();

eCommerceBusiness.Subscribe(customer2);
Console.WriteLine();

eCommerceBusiness.Subscribe(customer3);
Console.WriteLine();

// Add a new notification (this will notify all subscribers individually)
var notifications = new List<NotificationDto>
{
    new NotificationDto { CustomerId = 1, Message = $"Hello Alice, a new product is available!" },
    new NotificationDto { CustomerId = 2, Message = $"Hey Bob, check out our new product!" },
    new NotificationDto { CustomerId = 3, Message = $"Hi Charlie, we have a brand new product for you!" },
    
};
eCommerceBusiness.NotifyObservers(notifications);
Console.WriteLine();

// Unsubscribe a customer
eCommerceBusiness.Unsubscribe(customer1);
Console.WriteLine();

// Send another customized notification to remaining customers
notifications = new List<NotificationDto>
{
    new NotificationDto { CustomerId = 2, Message = $"Bob, we have a special discount just for you!" },
    new NotificationDto { CustomerId = 3, Message = $"Charlie, loyal customers like you deserve the best deals!" }
};
eCommerceBusiness.NotifyObservers(notifications);
Console.WriteLine();

// A customer sends a message back to the e-commerce business
eCommerceBusiness.MessageFromObserver(customer2, "Do you have a discount on the new product?");
Console.WriteLine();

// Create a big announcement to all customers
var bigAnnouncementDto = new NotificationDto { Message = "Big sale coming up this weekend! Don't miss out on discounts up to 50%!" };
eCommerceBusiness.SendAnnouncement(bigAnnouncementDto);
Console.WriteLine();
