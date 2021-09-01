using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCineplex.Models.Interfaces;

namespace TheCineplex.Models
{
    public class Concert : IShow
    {
        public Concert()
        {

        }

        public Concert(string title, List<DateTime> showTimes)
        {
            Title = title;
            ShowTimes = showTimes;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public List<DateTime> ShowTimes { get; set; }

        public decimal Price => 20;
    }
}
