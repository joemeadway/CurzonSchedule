using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurzonSchedule.Commands
{
    public class Cinemas
    {

        public string List()
        {

            var checker = new SiteChecker();
            var result = checker.GetCinemas();
            
            return result;
        }
    }
}
