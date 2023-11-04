using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace A._API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserDomain _userDomain;
        private IUserData _userData;

        public UserController(IUserDomain userDomain, IUserData userData)
        {
            _userDomain = userDomain;
            _userData = userData;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //UserData userData = new UserData();
            //userData.GetAll();
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{payMethod}", Name = "Get")]
        public string Get(string payMethod)
        {
            //UserSQLData userSqlData = new UserSQLData();
            //return userSqlData.GetAll();
            return _userData.GetByPayMethod(payMethod);
        }

        // POST: api/User
        [HttpPost]
        public bool Post([FromBody] string value)
        {
            //UserDomain userDomain = new UserDomain();
            return _userDomain.create(value);
            //return userDomain.Create(value);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}