﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CardCollection.Models
{
    public class UserModel
    {

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public List<Card> PersonalCollection { get; set; } = new List<Card>();

        public UserModel()
        {

        }
    }
}
