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
    public class PostsController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public List<Post> Get(int id)
        {
            return Models.Post.GetPostsByUserId(id);
        }

        [HttpGet("GetPostByUser")]
        public string GetPostByUser(int userId)
        {
            return JsonConvert.SerializeObject(Models.Post.GetPostsByUserId(userId));
        }

        [HttpPost]
        public int Post([FromBody]Post post)
        {

            if (post == null)
                return 1;
            return post.Save();
        }
       
    }
}
