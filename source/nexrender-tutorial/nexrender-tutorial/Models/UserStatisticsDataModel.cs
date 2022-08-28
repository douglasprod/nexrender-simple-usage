using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexrender_tutorial.Models
{
    public class UserStatisticsDataModel
    {
        public string Username { get; set; }
        public string FavoritePizza { get; set; }
        public string FavoriteDay { get; set; }
        public string FavoriteTime { get; set; }
        public string DeliveryTime { get; set; }
        public string YearSum { get; set; }
        public string MonthSum  { get; set; }
    }
}
