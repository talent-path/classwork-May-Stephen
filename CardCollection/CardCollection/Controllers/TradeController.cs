using CardCollection.Models;
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
    [Route("/Trades")]
    public class TradeController : Controller
    {

        TradeService _tradeService = new TradeService();

        public TradeController(CardDbContext context)
        {
            _tradeService = new TradeService(context);
        }

        [HttpPost("Add")]
        public IActionResult AddTrade(Trade toAdd)
        {
            _tradeService.AddTrade(toAdd);
            return Accepted(toAdd);
        }

        [HttpGet]
        public IActionResult GetAllTrades()
        {
            
            List<Trade> all = _tradeService.GetAll();
            return Accepted(all);
        }

        [HttpGet("{id}")]
        public IActionResult GetTradeById(int id)
        {
            Trade toReturn = _tradeService.GetById(id);
            return Accepted(toReturn);
        }

        [HttpDelete("Remove/{id}")]
        public IActionResult RemoveTradeById(int id)
        {
            string response = _tradeService.RemoveTrade(id);
            return Accepted(response);
        }
    }


}
