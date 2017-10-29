using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Newtonsoft.Json;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

             
        [HttpPost("Register")]
        public int Register([FromBody]User user)
        {

            if (user == null)
                return 1;
             return Models.User.RegisterUser(user);
            
        }
        [HttpGet("Login")]
        public string Login(string email,string password)
        {
            string jsonstring = JsonConvert.SerializeObject(Models.User.LoginUser(email, password));
            return jsonstring;

        }

    }
}
