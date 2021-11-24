using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using API.Models.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumPostsController : ControllerBase
    {
        // GET: api/ForumPosts
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<ForumPost> Get()
        {
            IForumPostsDataHandler forumPosts = new ForumPostDataHandler();
            return forumPosts.Select();
        }

        // GET: api/ForumPosts/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetF")]
        public string GetF(int id)
        {
            return "value";
        }

        // POST: api/ForumPosts
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ForumPosts/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
