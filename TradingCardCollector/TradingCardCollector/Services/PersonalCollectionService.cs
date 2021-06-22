using System;
using TradingCardCollector.Repos;

namespace TradingCardCollector.Services
{
    public class PersonalCollectionService
    { 
        InMemCollectionRepo _collectionRepo = new InMemCollectionRepo();


        public List<Card> GetAll()
        {
            return _collectionRepo.GetAll();
        }
    }
}
