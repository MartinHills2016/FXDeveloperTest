using System;
using System.Collections.Generic;
using System.Linq;

namespace FXDeveloperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WordCounter wc = new WordCounter("This is a statement, and so is this.");
            wc.CountWords();
            Console.Write(wc.ToString());
            Console.ReadKey();
        }
    }

    public class WordCounter
    {
        public string Sentance { get; private set; }
        private Dictionary<string, int> _wordDictionary;
        public WordCounter(string sentance)
        {
            Sentance = sentance.ToLower();
        }

        public void CountWords()
        {
            string sentenceWithoutPunctuation = new string(Sentance.ToCharArray().Where(c => !char.IsPunctuation(c)).ToArray());

            string[] words = sentenceWithoutPunctuation.Split(' ');
            _wordDictionary = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (_wordDictionary.ContainsKey(words[i]))
                    _wordDictionary[words[i]] = _wordDictionary[words[i]] = _wordDictionary[words[i]]+1;
                else
                    _wordDictionary.Add(words[i], 1);
            }
        }

        public override string ToString()
        {
            var output = _wordDictionary.Select(kvp => kvp.Key + " - " + kvp.Value.ToString());
            return string.Join(Environment.NewLine, output);
        }
    }
}
