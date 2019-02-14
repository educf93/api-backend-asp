using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using ApiGtt.Models;

using ApiGtt.Helpers;

using Jose;

using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Json;

namespace ApiGtt.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class AuthController : ControllerBase

    {
        public AuthController(AppDBContext contex)

        {

            this._context = contex;

        }
        private readonly AppDBContext _context;

        public object JsonValue { get; private set; }

        // GET api/values

        [HttpGet]

        public ActionResult<IEnumerable<string>> Get()

        {

            return new string[] { "value1", "value2" };

        }        // GET api/values/5

        [HttpGet("{ id}")]

        public ActionResult<string> Get(int id)

        {

            return "value";

        }        // POST api/values

        [HttpPost]

        public ActionResult Post([FromBody] User value)
        {
            try
            {

                User UserResult = this._context.Users.Where(
                   user => user.username == value.username).First();
                if (UserResult.password == Encrypt.Hash(value.password))
                {

                    string token = Jose.JWT.Encode(value.id, "topsecret", JweAlgorithm.PBES2_HS256_A128KW, JweEncryption.A256CBC_HS512);
                    //token = "{ \"token\":\"" + token + "\"}";
                    token = "{ \"token\":\"" + token + "\"," + "\"id\":\"" + UserResult.id + "\"}";
                    string json = JsonConvert.SerializeObject(token);
                    return Ok(json);

                }
                else
                {
                    return Unauthorized();
                }

            }
            catch (Exception e)
            {
                return NotFound(e.Message);

            }

        }      // PUT api/values/5

        [HttpPut("{id}")]

        public void Put(int id, [FromBody] string value)

        { }        // DELETE api/values/5

        [HttpDelete("{id}")]

        public void Delete(int id)

        {

        }
        //public ActionResult BuildToken()
        //{
        //    var claims = new[]
        //    {//Todo esto va en el cuerpo(playload)
        //        new Claim(JwtRegisteredClaimNames.UniqueName, "Edu"),
        //        new Claim("vaolr","algo"),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //    };
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("password"));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var expiration = DateTime.UtcNow.AddHours(2);
        //    JwtSecurityToken token = new JwtSecurityToken(
        //        issuer: "gtt.com",
        //        audience: "gtt",
        //        claims: claims,
        //        expires: expiration,
        //        signingCredentials: creds
        //        );
        //    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration });
        //}
        //public ActionResult ConvertString(string token){
            
        //}

           
    }
}
