using AutoMapper;
using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Resources;

namespace LoyalSips.Api.LoyalSips.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        //mapear igual a convertir categoryResource a Category, mediante el automapper
        CreateMap<SaveBarResource, Bar>();
        CreateMap<SaveUserResource, User>();
        CreateMap<SaveSupportResource, Support>();
        CreateMap<SavePointResource, Point>();
        CreateMap<SaveRegistroResource, RegistroPoint>();
    }
}