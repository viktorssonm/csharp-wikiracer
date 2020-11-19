This is a project to learn the basics of C# language.
Inspired by a exercise I did earlier in C++ following the Stanford University CS106L course.

I also implemented a PriorityQueue based on a binary heap to be used with any type that is comparable.
The PQ is needed in the algorithm for the wikiracer.

The algorithm is designed to find “ladders” between pages on Wikipedia, at the moment it supports English version of Wikipedia, however it’s just a small change to make it working with other languages.

The words need to match the URL on Wikipedia for the algorithm to work. It For example the ladder found between Colgate and New York it needs to be entered as follows:

Startpage: Colgate\_(toothpaste)
EndPage: New_York_City

Ladder in above example should be Colgate\_(toothpaste)-United_States-New_York_City-
It took 12s to run on my computer.

Another example is:
Startpage: Concorde
EndPage: Hong_Kong

Result:
Concorde-Bahrain-Hong_Kong
