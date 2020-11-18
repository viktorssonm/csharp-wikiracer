using System;
using System.Collections.Generic;
public class GetWikiLadder
{

    public List<string> FindWikiLadder(string startPage, string endPage)
    {

        HashSet<string> visitedPages = new HashSet<string>();

        GetWikiPageLinks client = new GetWikiPageLinks();
        HashSet<string> startWords = client.GetListOfLinksForWord(startPage);
        Ladder start = new Ladder(startWords, client);

        start.ladder.Add(startPage);

        PriorityQueue<Ladder> pq = new PriorityQueue<Ladder>();
        pq.Enqueue(start);
        visitedPages.Add(startPage);

        while (pq.count > 0)
        {

            Ladder firstLadder = pq.Dequeue();
            string lastPageOnLadder = firstLadder.ladder[firstLadder.ladder.Count - 1];
            HashSet<string> linksForLastPage = client.GetListOfLinksForWord(startPage);

            if (linksForLastPage.Contains(endPage))
            {
                System.Console.WriteLine("Ladder found");
                List<String> ladder = firstLadder.ladder;
                ladder.Add(endPage);
                return ladder;
            }

            foreach (string link in linksForLastPage)
            {
                if (!visitedPages.Contains(link))
                {
                    Ladder newLadder = firstLadder;
                    firstLadder.ladder.Add(link);
                    visitedPages.Add(link);
                    pq.Enqueue(newLadder);
                    int c = pq.count;
                    System.Console.WriteLine(c);
                }
            }
        }




        return null;

    }
}