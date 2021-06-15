using System;
using System.Collections.Generic;
using HangmanASP.Daos;
using HangmanASP.Models;

namespace HangmanASP.Services
{


    public class HangmanService
    {
        HangmanInMemDao _dao = new HangmanInMemDao();
        List<ViewModel> _toReturn = new List<ViewModel>();

        public HangmanService()
        {

        }


        public List<ViewModel> GetAllGames()
        {
            List<HangmanGame> toConvert = _dao.GetAllGames();

            foreach (HangmanGame game in toConvert)
            {
                _toReturn.Add(Convert(game));
            }

            return _toReturn;
        }

        public ViewModel GetGameById(int id)
        {
            var toReturn = Convert(_dao.GetGameById(id));
            if (toReturn == null)
            {
                throw new ArgumentException();
            }

            return toReturn;
        }

        public int CreateGame()
        {
            return _dao.CreateGame();
        }

        public void SubmitGuess(int id, char guess)
        {
            if (guess == ' ')
            {
                throw new ArgumentException();
            }
            var toUpdate = _dao.GetGameById(id);
            if(toUpdate.turnsLeft < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                toUpdate.turnsLeft--;
                toUpdate.guessedCharacters.Add(guess);
                _dao.SubmitGuess(toUpdate);
            }
            
        }

        public ViewModel Convert(HangmanGame game)
        {
            
            
            string partialWord = new string('_', game.word.Length);

            char[] arr = partialWord.ToCharArray();
            for (int i = 0; i < partialWord.Length; i++)
            {
                char c = game.word[i];
                if (game.guessedCharacters.Contains(c))
                {
                    arr[i] = c;
                }
            }
            partialWord = new string(arr);
            bool completed = !partialWord.Contains('_');
            ViewModel toReturn = new ViewModel(completed, partialWord, game.guessedCharacters);
            return toReturn;
        }
    }
}
