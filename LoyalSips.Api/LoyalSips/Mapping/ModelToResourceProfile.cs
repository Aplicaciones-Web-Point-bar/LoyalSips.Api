using AutoMapper;
using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Resources;

namespace LoyalSips.Api.LoyalSips.Mapping;

public class ModelToResource : Profile
{
    public ModelToResource()
    {
        //aqui se definen las reglas que se utilizara al mapear estas 2 capas
        //mapear igual a convertir Category a categoryResource, mediante el automapper
        CreateMap<Bar, BarResource>();
    }
}