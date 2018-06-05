using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurzonSchedule.Commands
{
    [Command(Name = "cinemas", Description = "Manage favourite cinemas"),
        Subcommand("all", typeof(All))]
    [HelpOption("--help")]
    class Docker
    {
        private int OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("You must specify at a subcommand.");
            app.ShowHelp();
            return 1;
        }
        
        [Command(Description = "List all cinemas")]
        [HelpOption("--help")]
        private class All
        {
            [Argument(0, Description = "The id of the cinema")]
            public string Image { get; }

            private int OnExecute(IConsole console)
            {
                console.Error.WriteLine("You must specify an action. See --help for more details.");
                return 1;
            }
        }

        [Command(Description = "List all cinemas")]
        [HelpOption("--help")]
        private class List
        {
            
            private int OnExecute(IConsole console)
            {
                console.Error.WriteLine("You must specify an action. See --help for more details.");
                return 1;
            }
        }
    }
}
