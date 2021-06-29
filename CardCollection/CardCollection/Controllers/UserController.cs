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
    [Route("/Users")]
    public class UserController : Controller
    {
        
        UserService _userService;

        public UserController(CardDbContext context)
        {
            _userService = new UserService(context);
        }
   

        [HttpPost("Add")]
        public IActionResult AddUser(User toAdd)
        {
            _userService.AddUser(toAdd);
            return Accepted(toAdd);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User user = _userService.GetUserById(id);
            return Accepted(user);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteUserById(int id)
        {
            _userService.DeleteUserById(id);
            return Accepted();
        }

        [HttpGet("{id}/Collection")]
        public IActionResult GetUserCollection(int id)
        {
            List<Card> collection = _userService.GetUserCollection(id);
            return Accepted(collection);
        }

        [HttpPost("{id}/Collection/Add/{cardId}")]
        public IActionResult AddToCollection(int id, string cardId)
        {
            _userService.AddToCollection(id, cardId);
            return Accepted();
        }

        [HttpDelete("{id}/Collection/Remove/{cardId}")]
        public IActionResult RemoveFromCollection(int id, string cardId)
        {
            _userService.RemoveFromCollection(id, cardId);
            return Accepted();
        }

    }
}
