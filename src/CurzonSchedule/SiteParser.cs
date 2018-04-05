using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurzonSchedule
{
    public interface ISiteParser
    {
        IEnumerable<HtmlNode> GetFilmPageSessions(HtmlDocument page);
        string GetFilmTitle(HtmlDocument page);
        IEnumerable<string> GetInitialLinks(HtmlDocument page);
    }

    public class SiteParser : ISiteParser
    {
        public IEnumerable<string> GetInitialLinks(HtmlDocument page)
        {
            var links = page.DocumentNode.Descendants("a")
                            .Select(a => a.GetAttributeValue("href", null))
                            .Where(u => !String.IsNullOrEmpty(u));

            return FilterLinks(links);
        }

        public IEnumerable<string> FilterLinks(IEnumerable<string> links)
        {
            return links
                .Where(l => l.Contains("film-info") && l.Contains("cinema"))
                .Select(l => l.Substring(l.IndexOf("/"), l.Length))
                .Distinct().ToList();
        }

        public IEnumerable<HtmlNode> GetFilmPageSessions(HtmlDocument page)
        {
            return page.DocumentNode.Descendants("div")
                            .Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("filmSessions"))
                            .ToList();
        }

        public string GetFilmTitle(HtmlDocument page)
        {
            var element = page.DocumentNode.Descendants("h1")
                            .Where(h => h.Attributes.Contains("class") && h.Attributes["class"].Value.Contains("filmPageTitle"))
                            .FirstOrDefault();
            if (element == null) return "";

            return element.InnerText;
        }
    }
}
