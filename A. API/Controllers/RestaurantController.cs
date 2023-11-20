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
        public List<Restaurant> Get()
        {
            return _restaurantData.GetAll();
        }

        
        // GET: api/Restaurant/5
        [HttpGet("{id}", Name = "Get")]
        public Restaurant Get(int id)
        {
            return _restaurantData.GetById(id);
        }
        
        [HttpGet("{Name_Rest}", Name = "GetByNameRestaurant")]
        public Restaurant GetByNameRestaurant(string name)
        {
            return _restaurantData.GetByNameRestaurant(name);
        }
        
        // POST: api/Restaurant
        [HttpPost]
        public IActionResult Post([FromBody] RestaurantDto restaurantRequest)
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

                var restaurant = _mapper.Map<RestaurantDto, Restaurant>(restaurantRequest);
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
        public bool Put(int id, [FromBody] RestaurantDto restaurantDto)
        {
            Restaurant restaurant = new Restaurant()
            {
                Name_Rest = restaurantDto.Name_Rest,
                Schedule = restaurantDto.Schedule,
                Location = restaurantDto.Location
            };
            return _restaurantDomain.update(restaurant, id);
        }
        
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _restaurantData.Delete(id);
        }
    }
}
