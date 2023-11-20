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
        
        
        /*
        // POST: api/Restaurant
        [HttpPost]
        public IActionResult Post()
        {
        }*/

        /*
        // PUT: api/Restaurant/5
        [HttpPut("{id}")]
        public bool Put(int id)
        {
        }
        */
        
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _restaurantData.Delete(id);
        }
    }
}
