using System;
using System.Collections.Generic;
public class Ladder : IComparable<Ladder>
{

    public Ladder()
    {
        ladderList = new List<string>();
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