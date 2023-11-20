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
        var existingRestaurant = _restaurantData.GetByNameRestaurant(restaurant.Name_Rest);
        if (existingRestaurant == null)
        {
            return _restaurantData.create(restaurant);
        }
        return false;
    }

    public bool update(Restaurant restaurant, int id)
    {
        // Verificar si ya existe un restaurante con el mismo nombre (o el mismo nombre diferente al actual)
        var existingRestaurant = _restaurantData.GetByNameRestaurant(restaurant.Name_Rest);

        // Si no existe (es nulo o tiene un ID diferente), realizar la actualización y devolver true
        if (existingRestaurant == null || existingRestaurant.Id == id)
        {
            return _restaurantData.update(restaurant, id);
        }

        // Si ya existe un restaurante con el mismo nombre, devolver false
        return false;
    }

}