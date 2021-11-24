using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.Models.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class plantcommentsController : ControllerBase
    {
        // GET: api/plantcomments
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<PlantComments> Get()
        {
            IPlantCommentsDataHandler commentsDataHandler = new PCommentsDataHandler();
            return commentsDataHandler.Select();
        }

        // GET: api/plantcomments/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetT")]
        public string GetT(int id)
        {
            return "value";
        }

        // POST: api/plantcomments
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/plantcomments/5
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
