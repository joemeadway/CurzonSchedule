using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurzonSchedule.Commands
{
    public class Cinemas
    {
        private ResultsFormatter _formatter;

        public Cinemas()
        {
            _formatter = new ResultsFormatter();
        }

        public string All()
        {

            var checker = new SiteChecker();
            var cinemas = checker.GetCinemas();

            return _formatter.GetResultsTable(cinemas).ToString();
        }

        public string Mine()
        {
            throw new NotImplementedException();
        }
    }
}
