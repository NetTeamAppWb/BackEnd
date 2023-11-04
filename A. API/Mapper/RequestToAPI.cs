using A._API.Request;
using AutoMapper;
using Data.Model;

namespace A._API.Mapper;

public class RequestToAPI : Profile
{
    public RequestToAPI()
    {
        CreateMap<RestaurantRequest, Restaurant>();
    }
}