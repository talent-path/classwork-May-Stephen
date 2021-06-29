using CardCollection.Models;
using Microsoft.EntityFrameworkCore;

namespace CardCollection.Repos
{
    public class CardDbContext : DbContext
    {

        public DbSet<Card> Cards { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Trade> AvailableTrades { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Request> Requests { get; set; }



        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options) { }


    }
}
