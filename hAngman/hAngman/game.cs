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
        private int wrongGuesses; 

        public int GetWrongGuesses() { return wrongGuesses; }

        public game(string theWord)
        {
            wrongGuesses = 0;
            word = new letterStruct[9];

            for (int i = 0; i < theWord.Length; i++)
            {
                word[i] = new letterStruct(theWord[i]);
            }  
            
            for (int i = theWord.Length; i < 9; i++)
            {
                word[i] = new letterStruct(true);
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

            public letterStruct(bool enabled)
            {
                letter = '0';
                guessed = true;
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

            if (returnString == "")
            {
                wrongGuesses++;
            }

            return returnString;
        }

        public int gameEndCheck()
        {
            foreach (letterStruct letter in word)
            {
                if (letter.guessed == false)
                {
                    if (wrongGuesses == 12)
                    {
                        return -1;
                    }

                    return 0;
                }
            }

            return 1;
        }
    }
}
