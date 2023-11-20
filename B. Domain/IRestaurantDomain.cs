using Data.Model;

namespace Domain;

public interface IRestaurantDomain
{
    bool create(Restaurant restaurant);

    bool update(Restaurant restaurant, int id);
}