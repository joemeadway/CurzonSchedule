using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurzonSchedule.Commands
{
    public class Run
    {
        public string Execute(CommandOption fetchScope, CommandOption sortOrder, CommandOption period)
        {
            FetchScope scope = FetchScope.All;
            if (fetchScope.HasValue())
            {
                switch (fetchScope.Value().ToUpperInvariant())
                {
                    case "MINE":
                        scope = FetchScope.Mine;
                        break;
                    case "ALL":
                        break;
                    default:
                        Console.WriteLine($"Fetch value {fetchScope.Value()} couldn't be parsed - fetching all");
                        scope = FetchScope.All;
                        break;
                }
            }
            string[] cinemasToCheck = null;
            if (scope == FetchScope.Mine)
            {
                cinemasToCheck = new SettingsReader().GetCinemas();
            }

            SortOrder sort = SortOrder.Date;
            if (sortOrder.HasValue())
            {
                switch (sortOrder.Value().ToUpperInvariant())
                {
                    case "D":
                        sort = SortOrder.Date;
                        break;
                    case "F":
                        sort = SortOrder.Film;
                        break;
                    case "C":
                        sort = SortOrder.Cinema;
                        break;
                    default:
                        Console.WriteLine($"Sort value {sortOrder.Value()} couldn't be parsed - sorting by Date");
                        sort = SortOrder.Date;
                        break;
                }
            }
            Period periodToFetch = Period.All;
            if (period.HasValue())
            {
                switch (period.Value().ToUpperInvariant())
                {
                    case "T":
                        periodToFetch = Period.Today;
                        break;
                    case "M":
                        periodToFetch = Period.Tomorrow;
                        break;
                    default:
                        Console.WriteLine($"Period value {period.Value()} couldn't be parsed - fetching all");
                        periodToFetch = Period.All;
                        break;
                }
            }
            var checker = new SiteChecker();
            var result = checker.GetShowings(cinemasToCheck);

            result = result.SortThisBy(sort);
            result = result.JustThisPeriod(periodToFetch);

            var formatter = new ResultsFormatter();
            var toPrint = formatter.GetResultsTable(result);
            return toPrint.ToString();
            //Console.WriteLine(toPrint);

            //Console.ReadLine();
            //return 0;
        }


    }
}
