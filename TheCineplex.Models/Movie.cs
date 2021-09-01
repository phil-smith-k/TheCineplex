using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCineplex.Models.Enumerations;
using TheCineplex.Models.Interfaces;

namespace TheCineplex.Models
{
    public class Movie : IShow
    {
        public Movie()
        {

        }

        public Movie(string title, Rating rating, List<DateTime> showTimes)
        {
            Title = title;
            Rating = rating;
            ShowTimes = showTimes;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public Rating Rating { get; set; }

        public List<DateTime> ShowTimes { get; set; }

        public decimal Price => 5;

        public override string ToString()
        {
            return $"-------------------\n" +
                   $"Title: {this.Title}\n" +
                   $"Rating: {this.Rating}\n" +
                   $"-------------------\n";
        }
    }
}
