using Data.Model;

namespace Data;

public interface IRestaurantData
{
    public Restaurant GetById(int id);
    public List<Restaurant> GetFilteredData(Restaurant restaurant);
    public Task<List<Restaurant>> GetAll();
    public bool GetByName(string name);
    bool create(Restaurant restaurant);
    bool Update(Restaurant restaurant, int id);
    bool Delete( int id);
}