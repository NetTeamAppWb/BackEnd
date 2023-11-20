using Data.Model;

namespace Data;

public interface IRestaurantData
{
    public Restaurant GetById(int id);
    public List<Restaurant> GetAll();

    public Restaurant GetByNameRestaurant(string name);
    public bool GetByName(string name);
    
    
    public bool Delete(int id);
    bool create(Restaurant restaurant);
    
}