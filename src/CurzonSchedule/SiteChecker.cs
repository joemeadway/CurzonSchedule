using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace CurzonSchedule{
    public class SiteChecker
    {
        private readonly ISiteReader _siteReader;
        private readonly ISiteParser _siteParser;

        public SiteChecker(ISiteReader reader = null, ISiteParser parser = null)
        {
            _siteReader = reader ?? new SiteReader();
            _siteParser = parser ?? new SiteParser();
        }

        public IEnumerable<Showing> GetShowings(string[] cinemasToCheck)
        {
            var toReturn = new List<Showing>();
            var initialPage = _siteReader.GetInitialPage();
            var initialLinks = _siteParser.GetInitialLinks(initialPage);

            var showBuidler = new ShowingBuilder();
            var initialShowings = showBuidler.FromInitialUrlList(initialLinks);


            if(cinemasToCheck != null && cinemasToCheck.Length != 0)
            {
                initialShowings = initialShowings.Where(s => cinemasToCheck.Contains(s.At.Number)).ToList();
            }

            foreach (var showing in initialShowings)
            {
                var filmPage = _siteReader.GetCinemasLinks(showing.At.Number, showing.What.Slug);
                if (string.IsNullOrEmpty(showing.What.Name))
                {
                    showing.What.Name = _siteParser.GetFilmTitle(filmPage);
                }
                if (string.IsNullOrEmpty(showing.At.Name))
                {
                    showing.At.Name = _siteParser.GetCinemaName(filmPage);
                }
                var filmSessions = _siteParser.GetFilmPageSessions(filmPage);
                
                toReturn.AddRange(showBuidler.FromScheduleDivs(showing, filmSessions));
            }

            return toReturn;
        }
    }
}