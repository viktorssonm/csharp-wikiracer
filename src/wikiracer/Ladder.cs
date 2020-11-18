using System;
using System.Collections.Generic;
public class Ladder : IComparable<Ladder>
{

    public Ladder(HashSet<string> start, GetWikiPageLinks c)
    {
        startPageLinks = start;
        client = c;
        ladder = new List<string>();
    }

    public List<string> ladder;
    GetWikiPageLinks client;
    HashSet<string> startPageLinks;

    public int CompareTo(Ladder other)
    {
        if (this.priority < other.priority)
        {
            return -1;
        }
        else
        {
            return 1;
        }

    }

    public int priority
    {
        get
        {
            int counter = 0;
            string lastLink = ladder[ladder.Count - 1];
            HashSet<string> lastLinks = client.GetListOfLinksForWord(lastLink);
            foreach (string w in startPageLinks)
            {
                if (lastLinks.Contains(w))
                {
                    counter++;
                }
            }
            return counter * -1;
        }
    }

}