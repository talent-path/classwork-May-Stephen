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
    [Route("/Collection")]
    public class CardController : Controller
    {
        CollectionService _collectionService = new CollectionService();
        CardDbContext _context;

        public CardController(CardDbContext context)
        {
            _context = context;
        }

        [HttpPost("/Add")]
        public IActionResult AddToCollection(Card toAdd)
        {
            _collectionService.AddCard(toAdd);
            return Accepted();
        }

        [HttpGet]
        public IActionResult GetCollection()
        {
            List<Card> collection = _collectionService.GetAll();
            return Accepted(collection);
        }

        [HttpDelete("Remove/{id}")]
        public IActionResult RemoveFromCollection(string id)
        {
            Card toDelete = new Card { Id = id };

            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
            return Accepted();

        }
    }
}
