using EFBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlog.Controllers
{
    [ApiController]
    public class BlogController : Controller
    {

        BlogDbContext _context;

        public BlogController(BlogDbContext context)
        {
            //should be used to instantiate a service object instead
            // this is "cheating"
            _context = context;
        }

        [HttpPost("/User")]
        public IActionResult AddUser(BlogUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return this.Accepted(user.BlogUserId);
        }

        [HttpGet("/User/{id}")]
        public IActionResult GetUser(int id)
        {
            BlogUser user = _context.Users.Find(id);
            return Accepted(user);
        }

        [HttpGet("/User/All")]
        public IActionResult GetAllUsers()
        {
            return Accepted(_context.Users.ToList());
        }

        [HttpPut("/User")]
        public IActionResult EditUser(BlogUser edited)
        {
            //BlogUser current = _context.Users.Find(edited.BlogUserId);
            //_context.Entry(current).CurrentValues.SetValues(edited);
            _context.Attach(edited);
            _context.Entry(edited).State = EntityState.Modified;
            _context.SaveChanges();
            return Accepted(edited);
        }

        [HttpDelete("/User/{id}")]
        public IActionResult DeleteUser(int id)
        {
            BlogUser toDelete = new BlogUser 
            {
                BlogUserId = id
            };
            _context.Attach(toDelete);
            _context.Remove(toDelete);
            _context.SaveChanges();
            return Accepted();
        }

    }
}
