using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCineplex.Models
{
    public class MovieTicket
    {
        public MovieTicket()
        {

        }

        public MovieTicket(int quantity, Movie movie, DateTime showTime)
        {
            Quantity = quantity;
            Movie = movie;
            ShowTime = showTime;
        }

        public int Quantity { get; set; }

        public Movie Movie { get; set; }

        public DateTime ShowTime { get; set; }

        public decimal Total => this.Movie.Price * this.Quantity;

        public string GetTicketText()
        {
            return $"***********************************\n" +
                   $"Admit: {this.Quantity}\n" +
                   $"Movie: {this.Movie.Title}\n" +
                   $"Show Time: {this.ShowTime}\n" +
                   $"***********************************\n";
        }
    }
}
