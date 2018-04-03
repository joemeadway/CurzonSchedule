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

                var cinemaNumber = item.Substring((item.IndexOf('/')+1),(item.IndexOf('/', item.IndexOf('/')+1)-(item.IndexOf('/')+1)));
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

        public IEnumerable<Showing> FromScheduleDivs(IEnumerable<HtmlNode> inputDivs)
        {
            var toReturn = new List<Showing>();

            foreach (var node in inputDivs)
            {
                node.SelectSingleNode("//div")
            }
        }
    }

}