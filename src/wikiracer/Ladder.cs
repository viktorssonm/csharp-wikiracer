using System;
using System.Collections.Generic;
public class Ladder : IComparable<Ladder>
{

    public Ladder()
    {
        ladderList = new List<string>();
    }

    // Copy constructor.
    public Ladder(Ladder previousLadder)
    {
        this.ladderList = new List<string>();
        foreach (string l in previousLadder.ladderList)
        {
            ladderList.Add(l);
        }
        this.priority = previousLadder.priority;

    }
    public List<string> ladderList;
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
    public int priority;
}