using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiRoutes.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using WebApiRoutes.Data.Repositories;
using WebApiRoutes.Data.Context;

namespace WebApiRoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRepository _repository;

        public ValuesController(IRepository repository)
        {
            _repository = repository;
        }


        // GET api/values
        [Authorize]
        [HttpGet]
        public string Get()
        {
            var model = _repository.ToList<UserModel>();
            string json = JsonConvert.SerializeObject(model);
            return json;
        }

        // GET api/values/5
       [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
