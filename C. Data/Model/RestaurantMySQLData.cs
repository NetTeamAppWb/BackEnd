using Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Data.Model;


public class RestaurantMySQLData : IRestaurantData
{
    private EmprendeChefBDContext _emprendeChef;
    
    public RestaurantMySQLData(EmprendeChefBDContext emprendeChef)
    {
        _emprendeChef = emprendeChef;
    }
    
    public Restaurant GetById(int id)
    {
        return _emprendeChef.Restaurants.Where(r => r.Id == id).FirstOrDefault();
    }

    public List<Restaurant> GetAll()
    {
        return _emprendeChef.Restaurants.ToList();
    }

    public Restaurant GetByNameRestaurant(string name)
    {
        return _emprendeChef.Restaurants.Where(r => r.Name_Rest == name).FirstOrDefault();
    }

    public bool Delete(int id)
    {
        var restaurantToDelete = _emprendeChef.Restaurants.Find(id);

        if (restaurantToDelete == null)
        {
            return false; 
        }

        _emprendeChef.Restaurants.Remove(restaurantToDelete);
        _emprendeChef.SaveChanges();

        return true; 
    }
}
