using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurzonSchedule
{
    public static class ResultsSorter
    {
        public static IEnumerable<Showing> SortThisBy(this IEnumerable<Showing> input, SortOrder sortBy)
        {
            if (input.Count() == 0 || input.Count() == 1)
                return input;
            switch (sortBy)
            {
                case SortOrder.Cinema:
                    input = SortByCinema(input);
                    return input;
                case SortOrder.Date:
                    input = SortByDate(input);
                    return input;
                case SortOrder.Film:
                    input = SortByFilm(input);
                    return input;
                default:
                    break;
            }
            return input;
        }

        private static IEnumerable<Showing> SortByFilm(IEnumerable<Showing> input)
        {
            input = input.OrderBy(s => s, new ShowingFilmComparer()).ToList();
            return input;
        }

        private static IEnumerable<Showing> SortByDate(IEnumerable<Showing> input)
        {
            input = input.OrderBy(s => s.When).ToList();
            return input;
        }

        private static IEnumerable<Showing> SortByCinema(IEnumerable<Showing> input)
        {
            input = input.OrderBy(s => s, new ShowingCinemaComparer()).ToList();
            return input;
        }
    }
}
