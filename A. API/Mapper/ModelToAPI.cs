using A._API.Request;
using A._API.Response;
using AutoMapper;
using Data.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.DiaSymReader;

namespace A._API.Mapper;

public class ModelToAPI : Profile
{
    public ModelToAPI()
    {
        CreateMap<Restaurant, RestaurantRequest>();
        CreateMap<Restaurant, RestaurantResponse>();
        CreateMap<User, UserRequest>();
        CreateMap<User, UserResponse>();
    }
}