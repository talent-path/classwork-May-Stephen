using System;
using System.Collections.Generic;

namespace HangmanASP.Models
{
    public class HangmanGame
    {
        public int? Id { get; set; }
        public string word { get; set; }
        public List<char> guessedCharacters { get; set; }
        public int turnsLeft { get; set; }
        public bool completed { get; set; }
    }
}
