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
            var initialLinks = GetInitialLinks();

            var showBuidler = new ShowingBuilder();
            var initialShowings = showBuidler.FromInitialUrlList(initialLinks);
            

            return new List<Showing>();
        }

        private IEnumerable<Showing> GetInitialShowings(IEnumerable<string> initialLinks)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetInitialLinks()
        {

            StringBuilder builder = new StringBuilder();

            //var site = @"https://curzoncinemas.com/bloomsbury/this-week";
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


            // var showings = filmLinks.Select(l => new Showing{
            //     At = new Cinema{
            //         Number = 123
            //     },
            //     What = new Film{
            //         Name = "Film Title"
            //     }
            // }).ToList();



            var filmRoot = @"https://curzoncinemas.com/bloomsbury/film-info/";

            var filmAndTimes = new Dictionary<string, List<string>>();

            // foreach (var link in filmLinks)
            // {
            //     var toCheck = filmRoot + link;
            //     var checkingDoc = web.Load(site);

            //     var timeSections = checkingDoc.DocumentNode.Descendants("div").Where(d => d.GetAttributeValue("class", "").Contains("filmSessions")).ToList();


            //     //get date and times out
            //     //split up multiple cinema results
            //     //format to be readable

            //     foreach (var section in timeSections)
            //     {
            //         builder.AppendLine(section.InnerHtml);
            //     }
            //     break;
            // }

            // return builder.ToString();

        }


    }
}