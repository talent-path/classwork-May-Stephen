using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public class DbRequestRepo : IRequestRepo
    {

        CardDbContext _context;

        public DbRequestRepo(CardDbContext context)
        {
            _context = context;
        }

        public Request AddRequest(Request req, int id)
        {
            Request toAdd = new Request();
            toAdd.trade = _context.AvailableTrades.Find(id);
            _context.Requests.Add(toAdd);
            
           
            foreach(Card c in req.RequestedCards)
            {
                _context.Cards.Find(c.Id).Requests.Add(toAdd);
            }
            

            
            _context.SaveChanges();

            return toAdd;
        }

        
    }
}
