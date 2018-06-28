using System.Collections.Generic;

namespace CurzonSchedule.Models{
    public class Cinema
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public IEnumerable<Showing> ShowingFilms { get; set; } 
    }

    public class CinemaEqualityComparer : IEqualityComparer<Cinema>
    {
        public bool Equals(Cinema x, Cinema y)
        {
            return (x.Name == y.Name && x.Number == y.Number);
        }

        public int GetHashCode(Cinema obj)
        {
            int h = obj.Number.GetHashCode() ^ obj.Name.GetHashCode();
            return h.GetHashCode();
        }
    }
}