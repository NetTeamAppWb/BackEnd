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
        return _emprendeChef.Restaurants.Where(t => t.Id == id && t.IsActive).FirstOrDefault();
    }
    
    public List<Restaurant> GetFilteredData(Restaurant restaurant)
        {
            return _emprendeChef.Restaurants.Where(t => restaurant.Foods.Contains(t.Foods)
                                                        && restaurant.Location.Contains(t.Location)
                                                        && t.IsActive).ToList();
            
        }

    public async Task<List<Restaurant>> GetAll()
    {
        return await _emprendeChef.Restaurants.Where(t=>t.IsActive).ToListAsync();
    }

    public bool GetByName(string name)
    {
        
        var count=_emprendeChef.Restaurants.Where(t => t.Name == name && t.IsActive).ToList().Count();
        return count > 0;
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
    public bool Update(Restaurant restaurant, int id)
    {
        try
        {
            var restaurantUpdate = _emprendeChef.Restaurants.Where(t => t.Id == id).FirstOrDefault();
            restaurantUpdate.Name = restaurant.Name;
            restaurantUpdate.Foods = restaurant.Foods;
            restaurantUpdate.Schedule = restaurant.Schedule;
            restaurantUpdate.Location = restaurant.Location;
            restaurantUpdate.Owner = restaurant.Owner;
            restaurantUpdate.Payment = restaurant.Payment;
            restaurantUpdate.Calls = restaurant.Calls;

            _emprendeChef.Restaurants.Update(restaurantUpdate);
            _emprendeChef.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var restaurantUpdate = _emprendeChef.Restaurants.Where(t => t.Id == id).FirstOrDefault();
            restaurantUpdate.IsActive = false;
           
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