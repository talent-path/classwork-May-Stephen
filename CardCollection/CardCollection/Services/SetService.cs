using CardCollection.Repos;
using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    public class SetService
    {
        ITCGCardRepo _tcgRepo = new TCGCardRepo();
        ISetRepo _setRepo;

        public SetService()
        {

        }

        public SetService(CardDbContext context)
        {

            _setRepo = new DbSetRepo(context);
        }

        internal void AddAllSets()
        {
            _tcgRepo.AddAllSets();
        }

        internal List<string> GetAllSeries()
        {
            return _setRepo.GetAllSeries();
        }

        internal List<Sets> GetSetsBySeries(string name)
        {
            return _setRepo.GetSetsBySeries(name);
        }
    }
}
