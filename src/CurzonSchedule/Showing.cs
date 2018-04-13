using System;
using System.Collections.Generic;

namespace CurzonSchedule
{
    public class Showing 
    {
        public Cinema At { get; set; }
        public Film What { get; set; }
        public DateTime When { get; set; }

        public Showing Copy()
        {
            return (Showing)this.MemberwiseClone();
        }
    }

    public class ShowingCinemaComparer : IComparer<Showing>
    {
        public int Compare(Showing x, Showing y)
        {
            return x.At.Number.CompareTo(y.At.Number);
        }
    }

    public class ShowingFilmComparer : IComparer<Showing>
    {
        public int Compare(Showing x, Showing y)
        {
            return x.What.Name.CompareTo(y.What.Name);
        }
    }
}