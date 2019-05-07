﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PingWebApi.Model;

namespace PingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighscoreController : ControllerBase
    {
        // GET: api/Highscore
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return DatabaseCommand.ReadQuery("SELECT * FROM Users");
        }

        // GET: api/Highscore/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Highscore
        [HttpPost]
        public void Post([FromBody] string value)
        {
            DatabaseCommand.ExecuteQuery(value);
        }

        // PUT: api/Highscore/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
