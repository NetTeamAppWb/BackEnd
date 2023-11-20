using Data;
using Data.Model;

namespace Domain;

public class RestaurantDomain : IRestaurantDomain
{
    public IRestaurantData _restaurantData;

    public RestaurantDomain(IRestaurantData restaurantData)
    {
        _restaurantData = restaurantData;
    }

    public bool create(Restaurant restaurant)
    {
        var result=_restaurantData.GetByName(restaurant.Name_Rest);
        if (!result)
        {
            return _restaurantData.create(restaurant);
        }
        else
        {
            return false;
        }
    }
}