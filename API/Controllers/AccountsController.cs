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
    public class AccountsController : ControllerBase
    {
        // GET: api/Accounts
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Account> Get()
        {
            IAccountDataHandler accountDataHandler = new AccountDataHandler();
            return accountDataHandler.Select();
        }

        // GET: api/Accounts/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetA")]
        public string GetA(int id)
        {
            return "value";
        }

        // POST: api/Accounts
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Accounts/5
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
