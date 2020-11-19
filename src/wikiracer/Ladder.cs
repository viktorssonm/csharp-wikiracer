using System;
using System.Collections.Generic;
public class Ladder : IComparable<Ladder>
{
    List<string> ladder;


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