using System.Collections.Generic;

namespace CurzonSchedule.Models{
    public class Film 
    {
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Showing> ShowingAt { get; set; }

    }
}