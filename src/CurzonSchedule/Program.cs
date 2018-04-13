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
            var sortOrder = app.Option("-s|--sort <ORDER>", "Sort order: by <C>inema, <F>ilm, <D>ate. Defaults to Date.", CommandOptionType.SingleValue);

            app.OnExecute(() =>
            {
                var checker = new SiteChecker();
                var result = checker.GetShowings();

                SortOrder sort;
                if (sortOrder.HasValue())
                {
                    if(!Enum.TryParse<SortOrder>(sortOrder.Value(), out sort))
                    {
                        Console.WriteLine($"Sort value {0} couldn't be parsed - sorting by Cinema", sortOrder.Value());
                        sort = SortOrder.Date;

                        result = result.SortThisBy(sort);
                    }
                }

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
