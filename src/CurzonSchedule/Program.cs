using System;
using McMaster.Extensions.CommandLineUtils;

namespace CurzonSchedule
{   
    public class Program
    {
        static int Main(string[] args)
        {
            var app = new CommandLineApplication();

            app.HelpOption();
            var fetchScope = app.Option("-f|--fetch <AMOUNT>", "Which cinemas to check - ALL or MINE. MINE checks for local settings json file; defaults to ALL.", CommandOptionType.SingleValue);
            var sortOrder = app.Option("-s|--sort <ORDER>", "Sort order: by <c>inema, <f>ilm, <d>ate. Defaults to date.", CommandOptionType.SingleValue);
            var period = app.Option("-p|--period <PERIOD>", "Period to fetch: <t>oday, to<m>orrow <a>ll. Defaults to all.", CommandOptionType.SingleValue);

            var argument = app.Argument("cinemas", "List the cinemas, manage favourites");
            var fetch = app.Argument("fetch", "Get film schedules");
            
            app.OnExecute(() =>
            {
                var blah = argument;

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
                if(scope == FetchScope.Mine)
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

                Console.WriteLine(toPrint);
                
                Console.ReadLine();
                return 0;
            });

            return app.Execute(args);
        }
    }
}
