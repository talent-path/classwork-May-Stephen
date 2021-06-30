﻿using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    interface ITradeRepo
    {
        int AddTrade(Trade toAdd);
        List<Trade> GetAll();
        Trade GetById(int id);
        string RemoveTrade(int id);
    }
}
