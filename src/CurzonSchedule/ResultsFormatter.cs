using ConsoleTables;
using CurzonSchedule.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurzonSchedule
{
    public class ResultsFormatter
    {
        public ConsoleTable GetResultsTable(IEnumerable<Showing> showings)
        {
            var table = new ConsoleTable(new ConsoleTableOptions());

            table.AddColumn(new List<string> { "Cinema", "Film", "Times" });
            foreach (var show in showings)
            {
                table.AddRow(show.At.Name, show.What.Name, show.When);
            }

            return table;
        }
    }
}
