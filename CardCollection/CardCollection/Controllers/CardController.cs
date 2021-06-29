using CardCollection.Repos;
using CardCollection.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Controllers
{


    [ApiController]
    [Route("Cards")]
    public class CardController : Controller
    {
        CardService _cardService = new CardService();
        


        [HttpPost("AddAll")]
        public IActionResult AddAll()
        {
            _cardService.AddAllCards();
            return Accepted();
        }
    }
}
