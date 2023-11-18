using AutoMapper;
using LoyalSips.Api.Security.Domain.Models;
using LoyalSips.Api.Security.Domain.Services.Communication;
using LoyalSips.Api.Security.Resources;

namespace LoyalSips.Api.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}