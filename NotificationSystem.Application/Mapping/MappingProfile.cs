using AutoMapper;
using NotificationSystem._Core.Entities;
using NotificationSystem.Application.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MegStore.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<NotificationDto, Notification>();
        }
    }
}
