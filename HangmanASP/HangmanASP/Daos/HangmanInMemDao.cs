using System;
using System.Collections.Generic;
using System.Linq;
using HangmanASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace HangmanASP.Daos
{
    
    public class HangmanInMemDao
    {
        static List<HangmanGame> _allGames = new List<HangmanGame>() { new HangmanGame {
                Id = 1,
                word = "zebra",
                guessedCharacters = new List<char>() {'z', 'e', 'b', 'r', 'a' },
                turnsLeft = 10,
                completed = true } };

        List<string> _allWords = new List<string>();

        public HangmanInMemDao()
        {

            _allWords.Add("apple");
            _allWords.Add("banana");
            _allWords.Add("purple");
            _allWords.Add("giraffe");
            _allWords.Add("coffee");
        }

        public List<HangmanGame> GetAllGames()
        {
            return _allGames;
        }

        public HangmanGame GetGameById(int id)
        {
            var toReturn = _allGames.SingleOrDefault(g => g.Id == id);
            return toReturn;
        }

        public int CreateGame()
        {
            Random rng = new Random();
            
            int parsed = rng.Next(0, _allWords.Count - 1);

            HangmanGame newGame = new HangmanGame {
                Id = _allGames.Count + 1,
                word = _allWords[parsed],
                guessedCharacters = new List<char>(),
                turnsLeft = 10};

            _allGames.Add(newGame);
            return (int)newGame.Id;
        }

        public void SubmitGuess(HangmanGame game)
        {
            var toUpdate = _allGames.SingleOrDefault(g => g.Id == game.Id);
            toUpdate = game;
        }

        public bool GameOver(HangmanGame game)
        {

        }

    }
}
