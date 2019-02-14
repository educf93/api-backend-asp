using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiGtt.Models;
using ApiGtt.Helpers;

namespace ApiGtt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/values
        private readonly AppDBContext _context;

        public UsersController(AppDBContext context)
        {
            this._context = context;
            
        }


           [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return this._context.Users.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(long id)
        {
            User user = this._context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<User> Post([FromBody] User value)
        {
            this._context.Users.Add(value);
            this._context.SaveChanges();
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] User value)
        {
            User user = this._context.Users.Find(id);
            user.username = value.username;
            user.password = value.password;
            this._context.SaveChanges();
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User userDelete = this._context.Users.Where((user) => id == id).First();
            this._context.Remove(userDelete);
            this._context.SaveChanges();
        }
    }
}
