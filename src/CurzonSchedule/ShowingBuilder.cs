using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace CurzonSchedule{

    public class ShowingBuilder
    {
        public IEnumerable<Showing> FromInitialUrlList(IEnumerable<string> inputList)
        {
            
            var toReturn =  new List<Showing>();

            if(inputList == null || inputList.Count() == 0)
            {
                return toReturn; 
            }

            var films = new List<Film>();
            var cinemas = new List<Cinema>();

            foreach (var item in inputList)
            {
                var slug = item.Substring((item.LastIndexOf('/')+1));
                var showing = new Showing();
                if(films.Any(f => f.Slug == slug))
                {
                    showing.What = films.First(f => f.Slug == slug);
                }
                else
                {
                    var newFilm = new Film
                    {
                        Slug = slug
                    };
                    showing.What = newFilm;
                    films.Add(newFilm);
                }

                var cinemaNumber = GetCinemaNumber(item);
                if(cinemas.Any(c => c.Number == cinemaNumber))
                {
                    showing.At = cinemas.First(c => c.Number == cinemaNumber);
                }
                else
                {
                    var newCinema = new Cinema
                    {
                        Number = cinemaNumber
                    };
                    showing.At = newCinema;
                    cinemas.Add(newCinema);
                }
                toReturn.Add(showing);
            }

            return toReturn;
        }

        public string GetCinemaNumber(string item)
        {
            item = item.Replace("/cinema/", "");
            if (item.StartsWith('/'))
            {
                item = item.TrimStart('/');
            }
            return item.Substring(0, item.IndexOf('/'));
        }

        public IEnumerable<Showing> FromScheduleDivs(Showing sourceShowing, IEnumerable<HtmlNode> inputDivs)
        {
            var toReturn = new List<Showing>();

            foreach (var node in inputDivs)
            {
                DateTime date = Convert.ToDateTime(node.Descendants("div")
                    .Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("filmItemDate"))
                    .FirstOrDefault().Attributes["data-dateformat"].Value);

                foreach (var sched in node.Descendants("li"))
                {
                    var timeLinks = sched.Descendants("a");
                    if (timeLinks.Count() == 0) break;
                    var time = DateTime.Parse(timeLinks.First().InnerText);
                    var thisTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
                    var newShowing = sourceShowing.Copy();
                    newShowing.When = thisTime;
                    toReturn.Add(newShowing);
                }
            }

            return toReturn;
        }
    }

}