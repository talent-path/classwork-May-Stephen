using CardCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public class DbCollectionRepo : ICollectionRepo
    {
        string _connectionString = "Server=localhost;Database=TradingCardManager;Trusted_Connection=true;";

        private DataSet ExecuteQuery(string query)
        {
            DataSet set = new DataSet();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(set);
            }
            return set;
        }

        public string Add(Card toAdd)
        {
            DataSet set = ExecuteQuery("INSERT INTO Card " +
                "(Id, Name, Type, SetId, Rarity, NumberInSet, Illustrator, Image, Price, ReleaseYear) " +
                $"VALUES('{toAdd.Id}', '{toAdd.Name}', '{toAdd.Type}', '{toAdd.SetId}', '{toAdd.Rarity}', {toAdd.NumberInSet}, '{toAdd.Illustrator}', '{toAdd.Image}', {toAdd.Price}, {toAdd.ReleaseYear} )");
            return set.Tables[0].Rows[0].Field<string>("Id");
        }

        public List<Card> GetAll()
        {
            List<Card> toReturn = new List<Card>();

            DataSet set = ExecuteQuery("SELECT * FROM Card");

            var table = set.Tables[0];

            for(int i = 0; i < table.Rows.Count; i++)
            {
                Card toAdd = new Card();

                var cardId = table.Rows[i].Field<string>("Id");
                var cardName = table.Rows[i].Field<string>("Name");
                var cardType = table.Rows[i].Field<string>("Type");
                var cardSetId = table.Rows[i].Field<string>("SetId");
                var cardRarity = table.Rows[i].Field<string>("Rarity");
                var cardNumberInSet = int.Parse(table.Rows[i]["NumberInSet"].ToString());
                var cardIllustartor = table.Rows[i].Field<string>("Illustrator");
                var cardImage = table.Rows[i].Field<string>("Image");
                var cardPrice = Decimal.Parse(table.Rows[i]["Price"].ToString());
                var cardYear = int.Parse(table.Rows[i]["ReleaseYear"].ToString());

                toAdd.Id = cardId;
                toAdd.Name = cardName;
                toAdd.Type = cardType;
                toAdd.SetId = cardSetId;
                toAdd.Rarity = cardRarity;
                toAdd.NumberInSet = cardNumberInSet;
                toAdd.Illustrator = cardIllustartor;
                toAdd.Image = cardImage;
                toAdd.Price = cardPrice;
                toAdd.ReleaseYear = cardYear;

                toReturn.Add(toAdd);

            }

            return toReturn;
        }

        public string Remove(string id)
        {
            DataSet set = ExecuteQuery($"DELETE FROM Card WHERE Id = {id} ");
            return $"Card {id} removed from the collection.";
        }

    }
}
