﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PingWebApi.Model;
using System.Net;

namespace PingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighscoreController : ControllerBase
    {
        // GET: api/Highscore
        [HttpGet]
        public IEnumerable<UserScore> GetAllScores()
        {
            return DatabaseCommand.ReadScore("SELECT * FROM User_Score ORDER BY Score DESC");
        }

        // GET: api/Highscore/5
        [HttpGet("{userId}", Name = "Get")]
        public IEnumerable<UserScore> GetAllScoresFromSingleUser(string userId)
        {
            return DatabaseCommand.ReadScore($"SELECT * FROM User_Score WHERE UserId ='{userId}' ORDER BY Score DESC");
        }

        // GET: api/Highscore/top/5
        [HttpGet("top/{amount}", Name = "Top")]
        public IEnumerable<UserScore> GetTop(int amount)
        {
            return DatabaseCommand.ReadScore($"SELECT TOP {amount} * FROM User_Score ORDER BY Score DESC");
        }

        // POST: api/Highscore
        [HttpPost]
        public HttpStatusCode Post([FromBody] UserScore userScore)
        {
            int status = DatabaseCommand.ExecuteQuery($"INSERT INTO User_Score(UserId, Score) VALUES('{userScore.UserId}', '{userScore.Score}')");

            if (status == 0)
            {
                return HttpStatusCode.BadRequest;
            }

            return HttpStatusCode.OK;
        }

        // DELETE: api/5
        [HttpDelete("{userId}")]
        public void DeleteAllSpecificUserScores(string userId)
        {
            DatabaseCommand.ExecuteQuery($"DELETE FROM User_Score WHERE UserId = '{userId}'");
        }
    }
}
