using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace WordList
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordList = GetWordList();

            Stopwatch sw = new Stopwatch();

            Random rnd = new Random();

            sw.Start();

            for (int i = 0; i < 1000000; i++)
            {
                int rndPosition = rnd.Next(0, wordList.Count);
                string rndWord = wordList[rndPosition];

                BinarySearchForWord(rndWord, wordList);
            }
            sw.Stop();
            Console.WriteLine("Binary search : {0}", sw.Elapsed);
            sw.Reset();

            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                int rndPosition = rnd.Next(0, wordList.Count);
                string rndWord = wordList[rndPosition];

                LinearSearchForWord(rndWord, wordList);
            }
            sw.Stop();
            Console.WriteLine("Linear search : {0}", sw.Elapsed);
            Console.ReadLine();
        }

        public static void BinarySearchForWord(string s, List<string> list)
        {
            while (true)
            {
                var halfwayValue = list.Count == 1 ? 0 : (int)Math.Ceiling((double)list.Count / 2) - 1;

                if (s.CompareTo(list[halfwayValue]) == 0)
                {
                    break;
                }
                if (s.CompareTo(list[halfwayValue]) == -1)
                {
                    list.RemoveRange(halfwayValue, list.Count - halfwayValue);
                }
                else
                {
                    list.RemoveRange(0, halfwayValue+1);
                }
            }
        }

        public static void LinearSearchForWord(string s, List<string> list)
        {
            foreach(var word in list)
            {
                if(word == s)
                {
                    break;
                }
            }
        }

        public static List<string> GetWordList()
        {
            List<string> wordList = new List<string>();
            using (StreamReader reader = new StreamReader("../wordlist.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    wordList.Add(line);

                }
            }
            return wordList;
        }
    }
}
