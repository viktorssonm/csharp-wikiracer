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
            var res = ladderCreater.FindWikiLadder("Milkshake", "Gene");
            foreach (string l in res)
            {
                System.Console.WriteLine(l);
            }
        }
    }
}
