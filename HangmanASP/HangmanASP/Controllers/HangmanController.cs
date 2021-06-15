using System;
using System.Collections.Generic;
using HangmanASP.Models;
using HangmanASP.Services;
using Microsoft.AspNetCore.Mvc;

namespace HangmanASP.Controllers
{
    [ApiController]
    [Route("/api")]
    public class HangmanController : ControllerBase
    {
        HangmanService _service = new HangmanService();

        public HangmanController()
        {
            
        }

        [HttpGet("games")]
        public ActionResult<List<ViewModel>> GetAllGames()
        {
            return _service.GetAllGames();
        }

        [HttpGet("game/{id}")]
        public ActionResult<ViewModel> GetGameById(int id)
        {
            return _service.GetGameById(id);
        }

        [HttpPost("begin")]
        public ActionResult<int> CreateGame()
        {
            return _service.CreateGame();
        }

        [HttpPut("game")]
        public ActionResult SubmitGuess(GuessModel g)
        {
            _service.SubmitGuess(g.Id, g.Guess);
            return this.LocalRedirect("/game/id");
        }
    }

}
