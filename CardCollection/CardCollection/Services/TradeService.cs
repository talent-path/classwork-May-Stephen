using CardCollection.Entities;
using CardCollection.Models;
using CardCollection.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    public class TradeService
    {

        ITradeRepo _tradeRepo;

        public TradeService()
        {
        }

        public TradeService(CardDbContext context)
        {
            _tradeRepo = new DbTradeRepo(context);
        }

        internal Trade AddTrade(int id, Trade toAdd)
        {
            return _tradeRepo.AddTrade(id, toAdd);
        }

        internal List<Trade> GetAll()
        {
            return _tradeRepo.GetAll();
        }

        internal Trade GetById(int id)
        {
            return _tradeRepo.GetById(id);
        }

        internal string RemoveTrade(int id)
        {
            return _tradeRepo.RemoveTrade(id);
        }

        internal List<Card> getCardsByTradeId(int id)
        {
            return _tradeRepo.GetCardsByTradeId(id);
        }

        internal User GetTradeUser(int tradeId)
        {
            return _tradeRepo.GetTradeUser(tradeId);
        }
    }
}
