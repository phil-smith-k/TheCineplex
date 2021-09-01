using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCineplex.Models.Interfaces;

namespace TheCineplex.Models
{
    public class Ticket : IPrintable
    {
        public Ticket()
        {
                
        }

        public Ticket(
            IShow show, 
            int quantity,
            DateTime showTime)
        {
            Show = show;
            Quantity = quantity;
            ShowTime = showTime;
        }

        public IShow Show { get; set; }

        public int Quantity { get; set; }

        public DateTime ShowTime { get; set; }

        public decimal Total => this.Show.Price * this.Quantity;

        public string GenerateText()
        {
            return $"***********************************\n" +
                   $"Admit: {this.Quantity}\n" +
                   $"Movie: {this.Show.Title}\n" +
                   $"Show Time: {this.ShowTime}\n" +
                   $"***********************************\n";
        }
    }
}
