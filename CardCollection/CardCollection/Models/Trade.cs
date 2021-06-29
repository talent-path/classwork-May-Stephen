using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Models
{
    public class Trade
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public List<Card> CardsOffered { get; set; } = new List<Card>();

        public Trade()
        {

        }
    }
}
