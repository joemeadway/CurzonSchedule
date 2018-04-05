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
            var optionSubject = app.Option("-s|--subject <SUBJECT>", "The subject", CommandOptionType.SingleValue);

            app.OnExecute(() =>
            {
                var checker = new SiteChecker();
                var result = checker.GetShowings();

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
