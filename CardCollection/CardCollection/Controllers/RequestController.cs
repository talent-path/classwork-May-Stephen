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
    [Route("/Trades/Requests")]
    public class RequestController : Controller
    {
        RequestService _requestService = new RequestService();

        public RequestController(CardDbContext context)
        {
            _requestService = new RequestService(context);
        }

        [HttpPost("Add/{id}")]
        public IActionResult AddRequest(int id, List<Card> toAdd)
        {
            Request req = _requestService.AddRequest(id, toAdd);
            return Accepted(req);
        }

        [HttpGet("{id}")]
        public IActionResult GetRequestByTradeId(int id)
        {
            Request req = _requestService.GetReqByTrade(id);
            return Accepted(req);
        }

        
    }
}
