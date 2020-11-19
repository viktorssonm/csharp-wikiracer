using System;
using System.Collections.Generic;
public class GetWikiLadder
{

    public List<String> FindWikiLadder(string startPage, string endPage)
    {

        // Hashset to keep track of visited pages.
        HashSet<string> visitedPages = new HashSet<string>();

        // PQ to keep ladders in.
        PriorityQueue<Ladder> pq = new PriorityQueue<Ladder>();

        // Client for fetching links from wikipedia.
        GetWikiPageLinks linkClient = new GetWikiPageLinks();

        //Get links for startpage
        HashSet<string> linksOnStartPage = linkClient.GetListOfLinksForWord(startPage);

        // Create add a ladder containg start page to queue.
        Ladder startLadder = new Ladder();
        startLadder.ladderList.Add(startPage);
        pq.Enqueue(startLadder);
        visitedPages.Add(startPage);

        while (pq.count > 0)
        {
            //Deque ladder with highest priority.
            Ladder ladderWithHighestPriority = pq.Dequeue();

            string lastLinkFromLadder = ladderWithHighestPriority.ladderList[ladderWithHighestPriority.ladderList.Count - 1];

            visitedPages.Add(lastLinkFromLadder);

            HashSet<string> linksFromLastPage = linkClient.GetListOfLinksForWord(lastLinkFromLadder);
            System.Console.WriteLine(lastLinkFromLadder);


            // If end page is in this set, the ladder is found. Return.
            if (linksFromLastPage.Contains(endPage))
            {
                System.Console.WriteLine("Ladder found!");
                ladderWithHighestPriority.ladderList.Add(endPage);
                return ladderWithHighestPriority.ladderList;
            }

            // For each neighbourpage
            foreach (string neighBourPage in linksFromLastPage)
            {
                // Check if already visited.
                if (!visitedPages.Contains(neighBourPage))
                {
                    // Create copy of  ladder.
                    Ladder newLadder = ladderWithHighestPriority;
                    newLadder.ladderList.Add(neighBourPage);
                    // Set priority of new ladder.
                    HashSet<string> linksOnNeighBourPage = linkClient.GetListOfLinksForWord(neighBourPage);
                    int counter = 0;
                    foreach (string link in linksOnNeighBourPage)
                    {
                        if (linksOnStartPage.Contains(link))
                        {
                            counter++;
                        }

                    }


                    counter *= -1;
                    newLadder.priority = counter;
                    pq.Enqueue(newLadder);
                }
            }




        }





        return null;

    }
}