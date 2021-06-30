﻿using CardCollection.Models;
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

        internal void AddTrade(Trade toAdd)
        {
            _tradeRepo.AddTrade(toAdd);
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
    }
}
