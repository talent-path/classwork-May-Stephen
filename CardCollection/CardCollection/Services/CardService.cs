using CardCollection.Models;
using CardCollection.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    
    public class CardService
    {

        ITCGCardRepo _tcgRepo = new TCGCardRepo();
        ICardRepo _cardRepo;

        public CardService()
        {
        }

        public CardService(CardDbContext context)
        {
            
            _cardRepo = new DbCardRepo(context);
        }

        

        public string AddAllCards()
        {
            return _tcgRepo.AddAll();
        }

        internal Card GetCardById(string id)
        {
            return _cardRepo.GetCardById(id);
        }

        internal List<Card> GetCardsByType(string type)
        {
            return _cardRepo.GetCardsByType(type);
        }

        internal List<Card> GetCardsByRarity(string rarity)
        {
            return _cardRepo.GetCardsByRarity(rarity);
        }

        internal List<Card> GetCardsByIllustrator(string name)
        {
            return _cardRepo.GetCardsByIllustrator(name);
        }

        internal List<Card> GetCardsBySet(string set)
        {
            return _cardRepo.GetCardsBySet(set);
        }
    }
}
