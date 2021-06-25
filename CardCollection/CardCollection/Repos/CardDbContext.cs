using CardCollection.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public class CardDbContext : DbContext
    {

        public DbSet<Card> Collection { get; set; }

        public DbSet<Card> TradeBoard { get; set; }

        public DbSet<Card> UserTrades { get; set; }

        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options) { }
    }
}
