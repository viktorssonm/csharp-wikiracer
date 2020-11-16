using System.Net;
using System.IO;
using System.Collections.Generic;

/* 
Class for fetching all links from a wikipedia page.
To qualify as a link it must be on the form <a href="/wiki/PAGE_NAME">LINK TEXT</a>
*/
public class GetWikiPageLinks
{
    public GetWikiPageLinks()
    {
        client = new WebClient();
    }

    private string getWikipediaSourceForWord(string word)
    {

        Stream data = client.OpenRead($"https://en.wikipedia.org/wiki/{word}");
        reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        return s;
    }

    public List<string> getListOfLinksForWord(string word)
    {
        List<string> listOfLinks = new List<string>();

        return listOfLinks;
    }





    private WebClient client;
    private StreamReader reader;
}