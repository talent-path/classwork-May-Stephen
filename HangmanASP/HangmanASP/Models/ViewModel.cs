using System;
using System.Collections.Generic;

namespace HangmanASP.Models
{
    public class ViewModel
    {  
        public List<char> GuessedCharacters { get; set; }
        public string PartialWord { get; set; }
        public bool Completed { get; set; }


        public ViewModel(bool completed, string partialWord, List<char> guessedCharacters)
        {
            Completed = completed;
            PartialWord = partialWord;
            GuessedCharacters = guessedCharacters;
            
        }
    }
}
