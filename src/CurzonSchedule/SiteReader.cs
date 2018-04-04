using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurzonSchedule
{
    public interface ISiteReader
    {
        HtmlDocument GetCinemasLinks(string cinema, string filmSlug);
        HtmlDocument GetInitialPage();
    }

    public class SiteReader : ISiteReader
    {
        public HtmlDocument GetInitialPage()
        {
            var site = @"https://curzoncinemas.com/this-week";
            HtmlWeb web = new HtmlWeb();
            return web.Load(site);
        }

        public HtmlDocument GetCinemasLinks(string cinema, string filmSlug)
        {
            var site = @"https://curzoncinemas.com/cinema/" + cinema + "/film-info/" + filmSlug;
            HtmlWeb web = new HtmlWeb();
            return web.Load(site);
        }

    }
}
