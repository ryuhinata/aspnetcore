using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Connection is okay");
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
    public class UserRanking
    {
        public string Username { get; set; }
        public int Ranking { get; set; }
    }

    public class PlayerBalance
    {
        public int StarBalance { get; set; }
        public int DiamondBalance { get; set; }
    }

    public class GetBalanceRequest
    {
        public int Id { get; set; }
    }
}