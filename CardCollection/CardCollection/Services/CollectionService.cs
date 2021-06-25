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

        public int AddCard(Card toAdd)
        {
            return _collectionRepo.Add(toAdd);
        }
    }
}
