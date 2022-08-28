using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexrender_tutorial
{
    public static class Util
    {
        public static List<DayOfWeek> _days = new List<DayOfWeek>
        {
            DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday
        };

        public static List<string> _pizzaNames = new List<string>
        {
            "Neapolitan",
            "Chicago",
            "New York-Style",
            "Sicilian",
            "Greek",
            "California",
            "Detroit",
            "St. Louis"
        };
    }
}
