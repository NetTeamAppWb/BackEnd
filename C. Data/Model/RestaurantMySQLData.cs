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

    public bool create(Restaurant restaurant)
    {
        try
        {
            _emprendeChef.Restaurants.Add(restaurant);
            _emprendeChef.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool update(Restaurant restaurant, int id)
    {
        try
        {
            var restaurantUpdate = _emprendeChef.Restaurants.Where(r => r.Id == id).FirstOrDefault();

            restaurantUpdate.Name_Rest = restaurant.Name_Rest;
            restaurantUpdate.Schedule = restaurant.Schedule;
            restaurantUpdate.Location = restaurant.Location;

            _emprendeChef.Restaurants.Update(restaurantUpdate);

            _emprendeChef.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
