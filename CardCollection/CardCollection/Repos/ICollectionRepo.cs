using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    interface ICollectionRepo
    {
        string Add(Card toAdd);
        List<Card> GetAll();
        string Remove(string id);
    }
}
