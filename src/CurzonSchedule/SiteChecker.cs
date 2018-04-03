using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace CurzonSchedule{
    public class SiteChecker
    {
        public IEnumerable<Showing> GetShowings()
        {
            var toReturn = new List<Showing>();
            var initialLinks = GetInitialLinks();

            var showBuidler = new ShowingBuilder();
            var initialShowings = showBuidler.FromInitialUrlList(initialLinks);
            
            foreach (var showing in initialShowings)
            {
                var cinemaFilmDivs = GetCinemasLinks(showing.At.Number, showing.What.Slug);
                
                toReturn.AddRange(showBuidler.FromScheduleDivs(cinemaFilmDivs);
                
            }

            return new List<Showing>();
        }

        public IEnumerable<string> GetInitialLinks()
        {

            StringBuilder builder = new StringBuilder();

            var site = @"https://curzoncinemas.com/this-week";
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(site);

            var links = doc.DocumentNode.Descendants("a")
                                    .Select(a => a.GetAttributeValue("href", null))
                                    .Where(u => !String.IsNullOrEmpty(u));

            return links
                .Where(l => l.Contains("film-info") && l.Contains("cinema") )
                .Select(l => l.Substring(l.LastIndexOf("/") + 1, l.Length - (l.LastIndexOf("/") + 1)))
                .Distinct().ToList();
        }

        public IEnumerable<HtmlNode> GetCinemasLinks(string cinema, string filmSlug)
        {
            List<string> toReturn = new List<string>();


            StringBuilder builder = new StringBuilder();

            var site = @"https://curzoncinemas.com/cinema/"+cinema+"/film-info/"+filmSlug;
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(site);

            var sessionNodes = doc.DocumentNode.Descendants("div")
                                .Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("filmSessions"))
                                .ToList();

            return toReturn;
        }


    }
}