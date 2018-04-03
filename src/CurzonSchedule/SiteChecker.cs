using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace CurzonSchedule{
    public class SiteChecker
    {
        private IEnumerable<string> _allFilms;

        public IEnumerable<Showing> GetShowings()
        {
            var toReturn = new List<Showing>();
            var initialLinks = GetInitialLinks();

            var showBuidler = new ShowingBuilder();
            var initialShowings = showBuidler.FromInitialUrlList(initialLinks);
            
            foreach (var showing in initialShowings)
            {
                var cinemaFilmLinks = GetCinemasLinks(showing.At.Number, showing.What.Slug);
                
                //Send film links to showing builder, return times
                //toReturn.AddRange(showBuidler.From
                
            }

            return new List<Showing>();
        }

        public IEnumerable<string> GetInitialLinks()
        {

            StringBuilder builder = new StringBuilder();

            var site = @"https://curzoncinemas.com/this-week";
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(site);

            _allFilms = doc.DocumentNode.Descendants("a")
                                    .Select(a => a.GetAttributeValue("href", null))
                                    .Where(u => !String.IsNullOrEmpty(u));

            return _allFilms
                .Where(l => l.Contains("film-info") && l.Contains("cinema") )
                .Select(l => l.Substring(l.LastIndexOf("/") + 1, l.Length - (l.LastIndexOf("/") + 1)))
                .Distinct().ToList();
        }

        public IEnumerable<string> GetCinemasLinks(string cinema, string filmSlug)
        {
            List<string> toReturn = new List<string>();



            return toReturn;
        }


    }
}