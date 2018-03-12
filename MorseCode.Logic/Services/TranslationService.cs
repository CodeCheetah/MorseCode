using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MorseCode.Logic.Interfaces;

namespace MorseCode.Logic.Services
{
    public class TranslationService : ITranslationService
    {
        private Dictionary<string, string> _morse;

        public string TranslateMorseToEnglish(string text)
        {
            InitializeDictionary();

            var sb = new StringBuilder();

            var arrWord = text.Split(new string[] { "   " }, StringSplitOptions.None);

            for (int i = 0; i < arrWord.Length; i++)
            {
                var arrMorse = arrWord[i].Split(new char[] { ' ' });

                arrMorse.ToList().ForEach(x =>
                {
                    if (_morse.ContainsKey(x))
                    {
                        var value = _morse.FirstOrDefault(z => string.Equals(z.Key, x, StringComparison.CurrentCultureIgnoreCase)).Value;
                        sb.Append(value);
                    }
                });

                if (i != (arrWord.Length - 1))
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }

        public string TranslateEnglishToMorse(string text)
        {
            InitializeDictionary();

            var sb = new StringBuilder();

            var arrWord = text.Split(new string[] { " " }, StringSplitOptions.None);

            for (int i = 0; i < arrWord.Length; i++)
            {
                var arrChar = arrWord[i].ToCharArray();

                for (int z = 0; z < arrChar.Length; z++)
                {
                    if (_morse.ContainsValue(arrChar[z].ToString()))
                    {
                        var key = _morse.FirstOrDefault(x => string.Equals(x.Value, arrChar[z].ToString(), StringComparison.CurrentCultureIgnoreCase)).Key;
                        sb.Append(key);

                        if (z < (arrChar.Length - 1))
                        {
                            sb.Append(" ");
                        }
                    }
                }
                if (i < (arrWord.Length - 1))
                {
                    sb.Append("   ");
                }

            }
            return sb.ToString();
        }

        private void InitializeDictionary()
        {
            _morse = new Dictionary<string, string>()
                                   {
                                       {".-", "a"},
                                       {"-...", "b"},
                                       {"-.-.", "c"},
                                       {"-..","d"},
                                       {".", "e"},
                                       {"..-.", "f"},
                                       {"--.","g"},
                                       { "....","h"},
                                       {"..","i"},
                                       {".---","j"},
                                       {"-.-","k"},
                                       {".-..","l"},
                                       {"--","m"},
                                       {"-.","n"},
                                       {"---","o"},
                                       {".--.","p"},
                                       {"--.-","q"},
                                       {".-.","r"},
                                       {"...","s"},
                                       {"-","t"},
                                       {"..-","u"},
                                       {"...-","v"},
                                       {".--","w"},
                                       {"-..-","x"},
                                       {"-.--","y"},
                                       {"--..","z"},
                                       {"-----","0"},
                                       {".----","1"},
                                       {"..---","2"},
                                       {"...--","3"},
                                       {"....-","4"},
                                       {".....","5"},
                                       {"-....","6"},
                                       {"--...","7"},
                                       {"---..","8"},
                                       {"----.","9"}
                                   };
        }
    }
}
