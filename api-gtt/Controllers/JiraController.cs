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

    public class JiraController : ControllerBase

    {

        private readonly AppDBContext _context;        // GET api/jira

        public JiraController(AppDBContext context)
        {
            this._context = context;

        }

        [HttpGet]
        public ActionResult<List<Jira>> GetAll()
        {
            return this._context.Jira.ToList();
        }

        [HttpGet("{id}")]

        public ActionResult<Jira> Get(long id)

        {
            try
            {
                Jira userGet = this._context.Jira.Where((jira) => jira.iduser == id).First();
                return userGet;
            }
            catch(Exception e)
            {
                return NotFound("No existe usuario de jira");
            }
            //return userGet.iduser == null ? (ActionResult<Jira>)NotFound() : (ActionResult<Jira>)userGet;
        }        // GET api/values/5



        [HttpPost]

        public ActionResult<Jira> Post([FromBody] Jira value)

        {
           
            this._context.Jira.Add(value);
            this._context.SaveChanges();
            return Ok();
        }        // PUT api/values/5

        [HttpPut("{id}")]

        public ActionResult<Jira> Put(long id, [FromBody] Jira value)

        {
            Jira jira = this._context.Jira.Where(
                  jiraUser => jiraUser.iduser == value.iduser).First();
            jira.description = value.description;
            jira.username = value.username;
            jira.password = value.password;
            this._context.SaveChanges();
            return Ok("Actualizado correctamente");


        }
        // DELETE api/values/5

        [HttpDelete("{id}")]

        public void Delete(int id)

        {
            this._context.SaveChanges();
        }

    }

}