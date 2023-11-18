using AutoMapper;
using LoyalSips.Api.Security.Domain.Models;
using LoyalSips.Api.Security.Domain.Services.Communication;

namespace LoyalSips.Api.Security.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, User>();
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                    return true;
                }
            ));
    }
}