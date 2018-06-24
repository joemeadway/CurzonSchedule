using System.Collections.Generic;

namespace CurzonSchedule.Models{
    public class Cinema
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public IEnumerable<Showing> ShowingFilms { get; set; } 
    }
}