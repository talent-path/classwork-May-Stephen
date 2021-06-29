using CardCollection.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    interface IUserRepo
    {

        int AddUser(User toAdd);
        User GetUserById(int id);
        string DeleteUserById(int id);
        int AddToCollection(int id, string cardId);
        List<Card> GetUserCollection(int id);
        string RemoveFromCollection(int id, string cardId);
    }
}
