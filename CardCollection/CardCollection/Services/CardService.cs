using CardCollection.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    
    public class CardService
    {

        ICardRepo _cardRepo = new DbCardRepo();

        public string AddAllCards()
        {
            return _cardRepo.AddAll();
        }
    }
}
