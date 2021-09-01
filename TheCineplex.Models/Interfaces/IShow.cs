using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCineplex.Models.Interfaces
{
    public interface IShow
    {
        int Id { get; set; }

        string Title { get; set; }

        List<DateTime> ShowTimes { get; set; }

        decimal Price { get; }
    }
}
