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

        public IEnumerable<Showing> GetShowings()
        {
            var toReturn = new List<Showing>();
            var initialPage = _siteReader.GetInitialPage();
            var initialLinks = _siteParser.GetInitialLinks(initialPage);

            var showBuidler = new ShowingBuilder();
            var initialShowings = showBuidler.FromInitialUrlList(initialLinks);

            foreach (var showing in initialShowings)
            {
                var filmPage = _siteReader.GetCinemasLinks(showing.At.Number, showing.What.Slug);
                if (string.IsNullOrEmpty(showing.What.Name))
                {
                    showing.What.Name = _siteParser.GetFilmTitle(filmPage);
                }
                var filmSessions = _siteParser.GetFilmPageSessions(filmPage);
                
                toReturn.AddRange(showBuidler.FromScheduleDivs(showing, filmSessions));
            }

            return toReturn;
        }
    }
}