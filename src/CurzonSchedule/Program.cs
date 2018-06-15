using System;
using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using CurzonSchedule.Commands;

namespace CurzonSchedule
{
    public class Program
    {
        static int Main(string[] args)
        {

            var app = new CommandLineApplication();

            app.HelpOption(inherited: true);

            app.Command("cinemas", cinemasCmd =>
            {
                cinemasCmd.Description = "List and manage your saved cinemas";
                cinemasCmd.OnExecute(() =>
                {
                    Console.WriteLine("Specify a subcommand");
                    cinemasCmd.ShowHelp();
                    return 1;
                });

                cinemasCmd.Command("list", listCmd =>
                {
                    listCmd.Description = "List all the Curzon Cinemas";
                    listCmd.OnExecute(() =>
                    {
                        Console.WriteLine($"Setting config hello");
                    });
                });

                cinemasCmd.Command("all", allCmd =>
                {
                    allCmd.Description = "List all your saved cinemas";
                    var json = allCmd.Option("--json", "Json output", CommandOptionType.NoValue);
                    allCmd.OnExecute(() =>
                    {
                        Console.WriteLine("Listing your saved cinemas");
                    });
                });

                cinemasCmd.Command("add", addCmd =>
                {
                    addCmd.Description = "Add a cinema to your favourites";
                    var number = addCmd.Argument("Number", "The number of the cinema to save", false);
                    //var json = allCmd.Option("--json", "Json output", CommandOptionType.SingleValue);
                    addCmd.OnExecute(() =>
                    {

                        Console.WriteLine($"Adding cinema {number.Value}");
                    });
                });

                cinemasCmd.Command("remove", remCmd =>
                {
                    remCmd.Description = "Remove a cinema from your favourites";
                    var number = remCmd.Argument("Number", "The number of the cinema to save", false);
                    //var json = allCmd.Option("--json", "Json output", CommandOptionType.SingleValue);
                    remCmd.OnExecute(() =>
                    {

                        Console.WriteLine($"Removing cinema {number.Value}");
                    });
                });
            });

            app.Command("run", runCmd =>
            {
                runCmd.Description = "Get cinema times";
                var fetchScope = runCmd.Option("-f|--fetch <AMOUNT>", "Which cinemas to check - ALL or MINE. MINE checks for local settings json file; defaults to ALL.", CommandOptionType.SingleValue);
                var sortOrder = runCmd.Option("-s|--sort <ORDER>", "Sort order: by <c>inema, <f>ilm, <d>ate. Defaults to date.", CommandOptionType.SingleValue);
                var period = runCmd.Option("-p|--period <PERIOD>", "Period to fetch: <t>oday, to<m>orrow <a>ll. Defaults to all.", CommandOptionType.SingleValue);
                runCmd.OnExecute(() =>
                {
                    var result = new Run().Execute(fetchScope, sortOrder, period);
                    Console.WriteLine(result);
                    return 1;
                });
                
            });

            app.OnExecute(() =>
            {
                Console.WriteLine("Specify a subcommand");
                app.ShowHelp();
                return 1;
            });

            return app.Execute(args);



            //var app = new CommandLineApplication();

            //app.HelpOption("-h|--help");

            //var fetchScope = app.Option("-f|--fetch <AMOUNT>", "Which cinemas to check - ALL or MINE. MINE checks for local settings json file; defaults to ALL.", CommandOptionType.SingleValue);
            //var sortOrder = app.Option("-s|--sort <ORDER>", "Sort order: by <c>inema, <f>ilm, <d>ate. Defaults to date.", CommandOptionType.SingleValue);
            //var period = app.Option("-p|--period <PERIOD>", "Period to fetch: <t>oday, to<m>orrow <a>ll. Defaults to all.", CommandOptionType.SingleValue);

            //var argument = app.Argument("cinemas", "List the cinemas, manage favourites");
            //var fetch = app.Argument("fetch", "Get film schedules");

            //app.Command("cinemas", cinemas =>
            //{
            //    cinemas.OnExecute(() =>
            //    {
            //        Console.WriteLine("Specify a subcommand");
            //        cinemas.ShowHelp();
            //        return 1;
            //    });

            //    cinemas.Command("all", allCinemas =>
            //    {
            //        allCinemas.Name = "all";
            //        allCinemas.Description = "Get all Curzon cinemas";
            //        allCinemas.OnExecute(() =>
            //        {
            //            Console.WriteLine("All cinemas");
            //        });
            //    });
            //});


            //app.OnExecute(() =>
            //{


            //    var blah = "";

            //    FetchScope scope = FetchScope.All;
            //    if (fetchScope.HasValue())
            //    {
            //        switch (fetchScope.Value().ToUpperInvariant())
            //        {
            //            case "MINE":
            //                scope = FetchScope.Mine;
            //                break;
            //            case "ALL":
            //                break;
            //            default:
            //                Console.WriteLine($"Fetch value {fetchScope.Value()} couldn't be parsed - fetching all");
            //                scope = FetchScope.All;
            //                break;
            //        }
            //    }
            //    string[] cinemasToCheck = null;
            //    if (scope == FetchScope.Mine)
            //    {
            //        cinemasToCheck = new SettingsReader().GetCinemas();
            //    }

            //    SortOrder sort = SortOrder.Date;
            //    if (sortOrder.HasValue())
            //    {
            //        switch (sortOrder.Value().ToUpperInvariant())
            //        {
            //            case "D":
            //                sort = SortOrder.Date;
            //                break;
            //            case "F":
            //                sort = SortOrder.Film;
            //                break;
            //            case "C":
            //                sort = SortOrder.Cinema;
            //                break;
            //            default:
            //                Console.WriteLine($"Sort value {sortOrder.Value()} couldn't be parsed - sorting by Date");
            //                sort = SortOrder.Date;
            //                break;
            //        }
            //    }
            //    Period periodToFetch = Period.All;
            //    if (period.HasValue())
            //    {
            //        switch (period.Value().ToUpperInvariant())
            //        {
            //            case "T":
            //                periodToFetch = Period.Today;
            //                break;
            //            case "M":
            //                periodToFetch = Period.Tomorrow;
            //                break;
            //            default:
            //                Console.WriteLine($"Period value {period.Value()} couldn't be parsed - fetching all");
            //                periodToFetch = Period.All;
            //                break;
            //        }
            //    }
            //    var checker = new SiteChecker();
            //    var result = checker.GetShowings(cinemasToCheck);

            //    result = result.SortThisBy(sort);
            //    result = result.JustThisPeriod(periodToFetch);

            //    var formatter = new ResultsFormatter();
            //    var toPrint = formatter.GetResultsTable(result);

            //    Console.WriteLine(toPrint);

            //    Console.ReadLine();
            //    return 0;
            //});

            //return app.Execute(args);
        }
    }
}
