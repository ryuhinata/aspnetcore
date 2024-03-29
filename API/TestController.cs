﻿using System.Collections.Generic;
using System.Linq;
using aspnetcore.API.Models;
using aspnetcore.Models;
using aspnetcore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MySqlDapper _dapper;

        public TestController(MySqlDapper dapper)
        {
            _dapper = dapper;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Connection is okay");
        }

        [HttpGet("DB")]
        public ActionResult CheckDBConnection()
        {
            _dapper.Query<string>("select top 1 * from account").FirstOrDefault();
            return Ok("Db Connection is okay");
        }

        [HttpPost("getbalance2/{id}")]
        public ActionResult GetBalance(int id)
        {
            var balance = new PlayerBalance { DiamondBalance = 100, StarBalance = 1000 };
            return Ok(balance);
        }


        [HttpPost("getbalance")]
        public ActionResult GetBalance(GetBalanceRequest request)
        {
            var balance = new PlayerBalance { DiamondBalance = 100, StarBalance = 1000 };
            return Ok(balance);
        }

        [Produces("application/json")]
        [HttpPost("getuserrankings")]
        public ActionResult GetUserRankings()
        {
            var userRankings = new List<UserRanking>()
            {
                new UserRanking {Username = "TestPlayer1", Ranking = 1},
                new UserRanking {Username = "TestPlayer2", Ranking = 2},
                new UserRanking {Username = "TestPlayer3", Ranking = 3}
            };
            return Ok(userRankings);
        }
    }
}