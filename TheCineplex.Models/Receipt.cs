using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCineplex.Models.Interfaces;

namespace TheCineplex.Models
{
    public class Receipt : IPrintable
    {
        public Receipt()
        {
            this.PurchaseDate = DateTime.Now;
        }

        //public Receipt(List<MovieTicket> tickets)
        //{
        //    this.Tickets = tickets;
        //    this.PurchaseDate = DateTime.Now;
        //}

        public Receipt(List<Ticket> tickets)
        {
            this.PurchaseDate = DateTime.Now;
            this.Tickets = tickets;
        }

        //public List<MovieTicket> Tickets { get; set; }

        public List<Ticket> Tickets { get; set; }

        public decimal ReceiptTotal
        {
            get
            {
                decimal sum = default;
                foreach (var ticket in this.Tickets)
                {
                    sum += ticket.Total;
                }
                return sum;
            }
        }

        public DateTime PurchaseDate { get; set; }

        public string GenerateText()
        {
            string dashes = "---------------------------------";
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(dashes);
            stringBuilder.AppendLine($"Date: {this.PurchaseDate}");
            stringBuilder.AppendLine(dashes);
            foreach(var ticket in this.Tickets)
            {
                stringBuilder.AppendLine($"{ticket.Show.Title}");
                stringBuilder.AppendLine($"Quantity: {ticket.Quantity} x {ticket.Show.Price.ToString("C")} = {ticket.Total.ToString("C")}");
                stringBuilder.AppendLine(dashes);
            }

            stringBuilder.AppendLine(dashes);
            stringBuilder.AppendLine(dashes);

            stringBuilder.AppendLine($"Total: {this.ReceiptTotal.ToString("C")}");
            stringBuilder.AppendLine(dashes);

            return stringBuilder.ToString();
        }
    }
}
