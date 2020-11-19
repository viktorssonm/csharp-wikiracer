using System;

namespace wikiracer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // GetWikiPageLinks g = new GetWikiPageLinks();
            GetWikiLadder ladderCreater = new GetWikiLadder();
            var test = ladderCreater.FindWikiLadder("Milkshake", "Gene");

            foreach (string link in test)
            {
                System.Console.WriteLine(link);
            }
        }
    }
}
