using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A._API.Request;
using A._API.Response;
using AutoMapper;
using Data;
using Data.Model;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace A._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        private IRestaurantDomain _restaurantDomain;
        private IRestaurantData _restaurantData;
        private IMapper _mapper;

        public RestaurantController(IRestaurantDomain restaurantDomain, IRestaurantData restaurantData, IMapper mapper)
        {
            _restaurantDomain = restaurantDomain;
            _restaurantData = restaurantData;
            _mapper = mapper;
        }
        
        // GET: api/Restaurant
        [HttpGet]
        public async Task<List<RestaurantResponse>> Get()
        {
            //RestaurantData restaurantData = new RestaurantData();
            //restaurantData.GetAll();
            //return new string[] { "value1", "value2" };
              var restaurants= await _restaurantData.GetAll();
              var response = _mapper.Map<List<Restaurant>, List<RestaurantResponse>>(restaurants);
              return response;
        }

        // GET: api/Restaurant/5
        [HttpGet("{id}", Name = "Get")]
        public Restaurant Get(int id)
        {
            //RestauranSQLtData restauranSqLtData = new RestauranSQLtData();
            //return restauranSqLtData.GetAll();
            return _restaurantData.GetById(id);
        }
        
        
        // GET: api/Restaurant/MATH
        [HttpGet("GetQuery")]
        public List<Restaurant> GetByName(string foods, string location)
        {
            //RestauranSQLtData restauranSqLtData = new RestauranSQLtData();
            //return restauranSqLtData.GetAll();
            Restaurant restaurant = new Restaurant()
            {
                Foods = foods,
                Location = location
            };
            return _restaurantData.GetFilteredData(restaurant);
        }

        // POST: api/Restaurant
        [HttpPost]
        public IActionResult Post([FromBody] RestaurantRequest restaurantRequest)
        {
            /*Restaurant restaurant = new Restaurant()
            {
                Name = restaurantRequest.Name,
                Foods = restaurantRequest.Foods,
                Schedule = restaurantRequest.Schedule,
                Location = restaurantRequest.Location,
                Owner = restaurantRequest.Owner,
                Payment = restaurantRequest.Payment,
                Calls = restaurantRequest.Calls
                
                
            };*/
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var restaurant = _mapper.Map<RestaurantRequest, Restaurant>(restaurantRequest);
                //RestaurantDomain restaurantDomain = new RestaurantDomain();
                return Ok(_restaurantDomain.create(restaurant));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            
           
        }

        // PUT: api/Restaurant/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] RestaurantRequest restaurantRequest)
        {
            Restaurant restaurant = new Restaurant()
            {
                Name = restaurantRequest.Name,
                Foods = restaurantRequest.Foods,
                Schedule = restaurantRequest.Schedule,
                Location = restaurantRequest.Location,
                Owner = restaurantRequest.Owner,
                Payment = restaurantRequest.Payment,
                Calls = restaurantRequest.Calls
                
                
            };
        
            return _restaurantDomain.update(restaurant,id);
            
        }

        // DELETE: api/Restaurant/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _restaurantDomain.delete(id);
        }
    }
}
