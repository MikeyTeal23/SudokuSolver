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
            Stopwatch sw = new Stopwatch();

            Random rnd = new Random();
            var wordList = GetWordList();

            sw.Start();

            for (int i = 0; i < 50000; i++)
            {
                int rndPosition = rnd.Next(0, wordList.Count);
                string rndWord = wordList[rndPosition];

                int wordPosition = BinarySearchForWord(rndWord, wordList);
            }
            sw.Stop();
            Console.WriteLine("Binary search : {0}", sw.Elapsed);
            sw.Reset();

            sw.Start();

            for (int i = 0; i < 50000; i++)
            {
                int rndPosition = rnd.Next(0, wordList.Count);
                string rndWord = wordList[rndPosition];

                int wordPosition = LinearSearchForWord(rndWord, wordList);
            }
            sw.Stop();
            Console.WriteLine("Linear search : {0}", sw.Elapsed);
            Console.ReadLine();
        }

        public static int BinarySearchForWord(string s, List<string> list)
        {
            var halfwayValue = (int)Math.Floor((double)list.Count / 2);
            var first = 0;
            var last = list.Count - 1;

            while (true)
            {
                if (s.CompareTo(list[halfwayValue]) == 0)
                {
                    return halfwayValue;
                }
                if (s.CompareTo(list[halfwayValue]) == -1)
                {
                    last = halfwayValue - 1;
                    halfwayValue = (int)Math.Floor((double)(first + last) / 2);
                }
                else
                {
                    first = halfwayValue + 1;
                    halfwayValue = (int)Math.Floor((double)(first + last) / 2);
                }
            }
        }

        public static int LinearSearchForWord(string s, List<string> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if(list[i] == s)
                {
                    return i;
                }
            }
            return 0;
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
            wordList.Sort();
            return wordList;
        }
    }
}
