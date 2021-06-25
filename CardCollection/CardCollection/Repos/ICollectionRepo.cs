using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    interface ICollectionRepo
    {
        int Add(Card toAdd);
    }
}
