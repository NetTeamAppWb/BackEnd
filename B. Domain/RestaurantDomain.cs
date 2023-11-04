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
        var result=_restaurantData.GetByName(restaurant.Name);
        if (!result)
        {
            return _restaurantData.create(restaurant);
        }
        else
        {
            return false;
        }
        
    }

    public bool update(Restaurant restaurant, int id)
    {
        var result=_restaurantData.GetByName(restaurant.Name);
        if (!result)
        {
            return _restaurantData.Update(restaurant, id);
        }
        else
        {
            return false;
        }
    }

    public bool update(int id, string name)
    {
        throw new NotImplementedException();
    }

    
    
    public bool delete(int id)
    {
        
        return _restaurantData.Delete(id);
    }
}