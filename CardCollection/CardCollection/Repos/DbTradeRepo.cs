using CardCollection.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public class DbTradeRepo : ITradeRepo
    {

        CardDbContext _context;

        public DbTradeRepo(CardDbContext context)
        {
            _context = context;
        }

        public Trade AddTrade(int id, Trade trade)
        {
            Trade toAdd = new Trade() { user = _context.Users.Single(u => u.Id == id) };

            _context.AvailableTrades.Add(toAdd);

            foreach (Card c in trade.CardsOffered)
            {
                _context.Cards.Find(c.Id).TradeOffers.Add(toAdd);
            }

            _context.SaveChanges();
            return toAdd;
        }

        public List<Trade> GetAll()
        {
            // Get all Trades
            List<Trade> all = _context.AvailableTrades.OrderBy(c => c.Id).ToList();
            foreach(Trade t in all)
            {
                
                IEnumerable<Card> toAdd = _context.Cards.Where(c => c.TradeOffers.Contains(t));
                foreach(Card c in toAdd)
                {
                    t.CardsOffered.Add(c);
                }
                
            }

            return all;

        }

        public Trade GetById(int id)
        {
            Trade toReturn = _context.AvailableTrades.Find(id);
            toReturn.CardsOffered = _context.Cards.Where(c => c.TradeOffers.Contains(toReturn)).ToList();
            

            return toReturn;
        }

        public string RemoveTrade(int id)
        {
            Trade toDelete = _context.AvailableTrades.Find(id);
            Request req = _context.Requests.Single(r => r.trade.Id == toDelete.Id);
            List<Card> reqCards = _context.Cards.Where(c => c.Requests.Contains(req)).ToList();

            foreach (Card c in reqCards)
            {
                c.Requests.Remove(req);
            }

            _context.Attach(req);
            _context.Remove(req);
            _context.Attach(toDelete);
            _context.Remove(toDelete);


            _context.SaveChanges();

            return $"Trade {id} removed.";
        }
    }
}
