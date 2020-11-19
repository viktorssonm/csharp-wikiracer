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

        //Get links for endPage
        HashSet<string> linksOnEndPage = linkClient.GetListOfLinksForWord(endPage);

        // Create add a ladder containg start page to queue.
        Ladder startLadder = new Ladder();
        startLadder.ladderList.Add(startPage);
        startLadder.priority = 1;
        pq.Enqueue(startLadder);

        while (pq.count > 0)
        {
            //Deque ladder with highest priority.
            Ladder ladderWithHighestPriority = pq.Dequeue();
            string lastLinkFromLadder = ladderWithHighestPriority.ladderList[ladderWithHighestPriority.ladderList.Count - 1];

            HashSet<string> linksFromLastPage = linkClient.GetListOfLinksForWord(lastLinkFromLadder);


            // If end page is in this set, the ladder is found. Return.
            if (linksFromLastPage.Contains(endPage))
            {
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
                    Ladder newLadder = new Ladder(ladderWithHighestPriority);
                    // Put neighbor page at end of copied ladder.
                    newLadder.ladderList.Add(neighBourPage);
                    // Set priority of new ladder. By comparing links on last page with links on end page.
                    HashSet<string> linksOnNeighBourPage = linkClient.GetListOfLinksForWord(neighBourPage);
                    int counter = 0;

                    foreach (string link in linksOnNeighBourPage)
                    {
                        if (linksOnEndPage.Contains(link))
                        {
                            counter++;
                        }
                    }
                    // Inverse the priority to work with binary three with minimum value first.
                    counter *= -1;
                    newLadder.priority = counter;
                    pq.Enqueue(newLadder);
                    visitedPages.Add(neighBourPage);
                }

            }
        }
        // In case this point is reached no matching ladder was found, so return empty list.
        List<string> empty = new List<string>();
        return empty;

    }
}