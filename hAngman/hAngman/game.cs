using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hAngman.Properties;

namespace hAngman
{
    class game
    {
        private letterStruct[] word;
        private string wordString;
        private int wrongGuesses;
        private List<string> dictionary;
        private Random rnd;
        private StringReader sr;

        public int GetWrongGuesses() { return wrongGuesses; }
        public string GetWordString() { return wordString; }

        public game()
        {          
            dictionary = new List<string>();
            rnd = new Random();
            sr = new StringReader(Resources.dictionary);            
            while (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();
                if (line.All(char.IsLetter) && line.Length >= 3 && line.Length <= 12)
                {
                    dictionary.Add(line);
                }                
            }

            createWord(randWord());
        }

        public game(string theWord)
        {
            createWord(theWord);
        }

        private void createWord(string theWord)
        {
            wrongGuesses = 0;
            word = new letterStruct[12];
            wordString = theWord;

            for (int i = 0; i < theWord.Length; i++)
            {
                word[i] = new letterStruct(theWord[i]);
            }

            for (int i = theWord.Length; i < 12; i++)
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

        private string randWord()
        {
            return dictionary[rnd.Next(0, dictionary.Count)].ToUpper();
        }
    }
}
