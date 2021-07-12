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
        ICollectionRepo _repo;

        public CollectionService()
        {
        }

        public CollectionService(CardDbContext context)
        {
            _repo = new DbCollectinoRepo(context);
        }

        internal List<Card> GetByType(int id, string type)
        {
            return _repo.GetByType(id, type);
        }

        internal List<string> GetAllTypes(int id)
        {
            return _repo.GetAllTypes(id);
        }

        internal List<Card> GetBySuper(int id, string superType)
        {
            return _repo.GetBySuper(id, superType);
        }

        internal List<Card> GetByRarity(int id, string rarity)
        {
            return _repo.GetByRarity(id, rarity);
        }

        internal List<string> GetAllRarities(int id)
        {
            return _repo.GetAllRarities(id);
        }

        internal List<string> GetAllSeries(int id)
        {
            return _repo.GetAllSeries(id);
        }
    }
}
