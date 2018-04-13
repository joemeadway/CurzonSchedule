using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
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
            return web.Load(site, "GET", new WebProxy
            {
                Address = new Uri("http://proxy.jpmchase.net:8443")
            }, new NetworkCredential());
        }

        public HtmlDocument GetCinemasLinks(string cinema, string filmSlug)
        {
            var site = @"https://curzoncinemas.com/cinema/" + cinema + "/film-info/" + filmSlug;
            HtmlWeb web = new HtmlWeb();
            return web.Load(site, "GET", new WebProxy
            {
                Address = new Uri("http://proxy.jpmchase.net:8443")
            }, new NetworkCredential());
        }

    }
}
