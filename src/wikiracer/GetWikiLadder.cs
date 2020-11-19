using System;
using System.Collections.Generic;
public class GetWikiLadder
{

    public List<string> FindWikiLadder(string startPage, string endPage)
    {

        HashSet<string> visitedPages = new HashSet<string>();
        PriorityQueue<Ladder> pq = new PriorityQueue<Ladder>();

        Ladder test = new Ladder();
        Ladder test2 = new Ladder();
        Ladder test3 = new Ladder();
        Ladder test4 = new Ladder();
        pq.Enqueue(test);
        pq.Enqueue(test2);
        pq.Enqueue(test3);
        pq.Enqueue(test4);

        test.priority = -1;
        test2.priority = -2;
        test3.priority = -3;
        test4.priority = -4;

        System.Console.WriteLine(pq.Dequeue().priority);





        return null;

    }
}