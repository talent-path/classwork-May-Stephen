﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Models
{
    public class Card
    {
        [Column("Id")]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        public string Type { get; set; }


        public string SetId { get; set; }


        public string Rarity { get; set; }


        public string NumberInSet { get; set; }


        public string Illustrator { get; set; }


        public string Image { get; set; }


        public int ReleaseYear { get; set; }

        public string supertype { get; set; }

        public int hp { get; set; }

        

        public List<UserModel> Owners { get; set; } = new List<UserModel>();

        public List<Trade> TradeOffers { get; set; } = new List<Trade>();

        public List<Offer> Offers { get; set; } = new List<Offer>();

        public List<Request> Requests { get; set; } = new List<Request>();





        public Card() { }





        public Card(Card card)
        {
            Id = card.Id;
            Name = card.Name;
            Type = card.Type;
            SetId = card.SetId;
            Rarity = card.Rarity;
            NumberInSet = card.NumberInSet;
            Illustrator = card.Illustrator;
            Image = card.Image;
            ReleaseYear = card.ReleaseYear;
            Owners = card.Owners;
            TradeOffers = card.TradeOffers;
            Requests = card.Requests;
            Offers = card.Offers;
        } 
    }
}
