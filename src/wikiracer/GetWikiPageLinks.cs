using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/* 
Class for fetching all links from a wikipedia page.
To qualify as a link it must be on the form <a href="/wiki/PAGE_NAME">LINK TEXT</a>

// REGEX <a href="\/wiki\/(.{1,}?)"
*/
public class GetWikiPageLinks
{
    public GetWikiPageLinks()
    {
        client = new WebClient();
        rg = new Regex(REGEX_FOR_WORDS);
    }

    // Get full page source as a string
    private string GetWikipediaSourceForWord(string word)
    {

        Stream data = client.OpenRead($"https://en.wikipedia.org/wiki/{word}");
        reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        return s;
    }

    // Get HashSet of all words in string matching regex. 
    public HashSet<string> GetListOfLinksForWord(string word)
    {
        HashSet<string> listOfLinks = new HashSet<string>();
        string page = GetWikipediaSourceForWord(word);
        var words = rg.Matches(page);

        foreach (Match match in words)
        {
            var regexMatch = match.Groups[1].ToString();
            if (!regexMatch.Contains('#') && !regexMatch.Contains(':') && regexMatch != "Main_Page")
            {
                listOfLinks.Add(regexMatch);
            }

        }


        return listOfLinks;
    }

    private WebClient client;
    private StreamReader reader;
    private Regex rg;

    const string REGEX_FOR_WORDS = "<a href=\"\\/wiki\\/(.{1,}?)\"";
}


