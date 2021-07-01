using CardCollection.Models;
using CardCollection.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    public class RequestService
    {

        IRequestRepo _requestRepo;

        public RequestService()
        {

        }

        public RequestService(CardDbContext context)
        {
            _requestRepo = new DbRequestRepo(context);
        }

        internal Request AddRequest(Request toAdd, int id)
        {
            return _requestRepo.AddRequest(toAdd, id);
        }
    }
}
