using CardCollection.Entities;
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

        public Request AddRequest(int id, List<Card> req)
        {
            Request toAdd = new Request();
            toAdd.RequestedCards = req;
            List<Trade> allTrades = _context.AvailableTrades.OrderBy(t => t.Id).ToList();
            if (allTrades.Count > 0)
            {
                toAdd.trade = allTrades.Last();
            }
            
            foreach (Card c in req)
            {
                _context.Attach(c);
                c.Requests.Add(toAdd);
            }
            _context.SaveChanges();

            return toAdd;
        }

        public Request GetReqByTrade(int id)
        {
            Request toReturn = _context.Requests.SingleOrDefault(r => r.trade.Id == id);
            return toReturn;
        }
    }
}
