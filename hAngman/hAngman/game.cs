using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hAngman
{
    class game
    {
        private letterStruct[] word;

        public game(string theWord)
        {
            word = new letterStruct[9];

            for (int i = 0; i < theWord.Length; i++)
            {
                word[i] = new letterStruct(theWord[i]);
            }            
        }

        private struct letterStruct
        {
            public char letter;
            public bool guessed;

            public letterStruct(char theLetter)
            {
                letter = theLetter;
                guessed = false;
            }
        }

        public string attempt(char theChar)
        {
            string returnString = "";

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].letter == theChar)
                {
                    word[i].guessed = true;
                    returnString += i;
                }
            }

            return returnString;
        }
    }
}
