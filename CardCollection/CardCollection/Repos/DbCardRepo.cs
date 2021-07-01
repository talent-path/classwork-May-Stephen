﻿using CardCollection.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public class DbCardRepo :ICardRepo
    {
        string _connectionString = "Server=localhost;Database=TradingCardManager;Trusted_Connection=true;";

        string _cardConnection = "https://api.pokemontcg.io/v2/cards";

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

        public string AddAll()
        {
            ExecuteQuery("DELETE FROM Cards");
            using (WebClient wc = new WebClient())
            {
                for (int i = 1; i < 56; i++)
                {
                    string json = "";
                    if (i == 1)
                    {
                         json = wc.DownloadString(_cardConnection);
                    }
                    else
                    {
                        if (i % 20 == 0)
                        {
                            Thread.Sleep(60000);
                        }

                        json = wc.DownloadString(_cardConnection + "?page=" + i) ;
                    }

                    JObject data = JObject.Parse(json);

                    
                    foreach (var x in data.First)
                    {
                        foreach (var card in x)
                        {
                            Card toAdd = new Card();
                            toAdd.Name = card["name"].ToString();
                            toAdd.Id = card["id"].ToString();
                            toAdd.NumberInSet = card["number"].ToString();
                            toAdd.Rarity = (card["rarity"] != null) ? card["rarity"].ToString() : null;
                            toAdd.ReleaseYear = ((DateTime)card["set"]["releaseDate"]).Year;
                            toAdd.SetId = card["set"]["id"].ToString();
                            toAdd.Illustrator = (card["artist"] != null) ? card["artist"].ToString() : null;

                            //TODO: GET ALL TYPES
                            toAdd.Type = (card["types"] != null) ? card["types"][0].ToString() : null;

                            toAdd.Image = card["images"]["small"].ToString();

                            if (toAdd.Name.Contains("'"))
                            {
                                toAdd.Name = toAdd.Name.Insert(toAdd.Name.IndexOf("'"), "'");
                            }

                            DataSet set = ExecuteQuery("INSERT INTO Cards " +
                                "(Id, Name, Type, SetId, Rarity, NumberInSet, Illustrator, Image, ReleaseYear) " +
                                $"VALUES('{toAdd.Id}', '{toAdd.Name}', '{toAdd.Type}', " +
                                $"'{toAdd.SetId}', '{toAdd.Rarity}', '{toAdd.NumberInSet}', '{toAdd.Illustrator}', " +
                                $"'{toAdd.Image}', {toAdd.ReleaseYear} )");
                        }
                    }

                }
                
            }

            return "Cards added successfully.";
        }

    }
}