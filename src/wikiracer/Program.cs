using System;

namespace wikiracer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simple test program for algorithm.
            GetWikiLadder ladderCreater = new GetWikiLadder();

            Console.WriteLine("Welcome to Wikiracer!");
            System.Console.WriteLine("Please enter start word:");
            var startWord = Console.ReadLine();
            System.Console.WriteLine("Please enter end word:");
            var endWord = Console.ReadLine();
            System.Console.WriteLine("Stand by, Operation in progres....");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var result = ladderCreater.FindWikiLadder(startWord, endWord);
            watch.Stop();

            System.Console.WriteLine("WikiLadder is found!");
            string ladderString = "";
            foreach (string page in result)
            {
                ladderString += $"{page}-";
            }
            System.Console.WriteLine(ladderString);
            System.Console.WriteLine($"Time for algorithm to find solution was {watch.ElapsedMilliseconds / 1000} s");
        }
    }
}
