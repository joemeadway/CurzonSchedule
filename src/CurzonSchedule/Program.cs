using System;
using McMaster.Extensions.CommandLineUtils;

namespace CurzonSchedule
{
    class Program
    {
        static int Main(string[] args)
        {
            var app = new CommandLineApplication();

            app.HelpOption();
            var optionSubject = app.Option("-f|--fetch <AMOUNT>", "Which cinemas to check - ALL or MINE. MINE checks for local settings json file; defaults to ALL.", CommandOptionType.SingleValue);
            var sortOrder = app.Option("-s|--sort <ORDER>", "Sort order: by <c>inema, <f>ilm, <d>ate. Defaults to date.", CommandOptionType.SingleValue);
            var period = app.Option("-p|--period <PERIOD>", "Period to fetch: <t>oday, to<m>orrow <a>ll. Defaults to all.", CommandOptionType.SingleValue);

            app.OnExecute(() =>
            {

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
                var result = checker.GetShowings();

                result = result.SortThisBy(sort);
                result = result.JustThisPeriod(periodToFetch);

                var formatter = new ResultsFormatter();
                var toPrint = formatter.GetResultsTable(result);

                Console.WriteLine(toPrint);

                var subject = optionSubject.HasValue()
                    ? optionSubject.Value()
                    : "world";

                Console.WriteLine($"Hello {subject}!");
                Console.ReadLine();
                return 0;
            });

            return app.Execute(args);
        }
    }
}
