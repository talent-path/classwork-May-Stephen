using CardCollection.Models;
using CardCollection.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    public class CollectionService
    {
        ICollectionRepo _collectionRepo = new DbCollectionRepo();

        public string AddCard(Card toAdd)
        {
            return _collectionRepo.Add(toAdd);
        }

        public List<Card> GetAll()
        {
            return _collectionRepo.GetAll();
        }

        public void Remove(string id)
        {
            _collectionRepo.Remove(id);
        }
    }
}
