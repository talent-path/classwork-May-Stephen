using System;
namespace HangmanASP.Models
{
    public class GuessModel
    {
        public int Id { get; set; }
        public char Guess { get; set; }

        public GuessModel()
        {
           
        }
    }
}
