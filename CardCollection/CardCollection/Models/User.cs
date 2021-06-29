using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Models
{
    public class User
    {

        public int Id { get; set; }

        public string UserName { get; set; }

        public List<Card> PersonalCollection { get; set; } = new List<Card>();

        public User()
        {

        }
    }
}
