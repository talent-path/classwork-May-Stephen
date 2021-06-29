using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Models
{
    public class Request
    {

        public int Id { get; set; }

        public int TradeId { get; set; }

        public List<Card> RequestedCards { get; set; } = new List<Card>();
    }
}
