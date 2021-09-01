using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCineplex.Models;

namespace TheCineplex.Repos
{
    public class ConcertRepository
    {
        private readonly List<Concert> _concerts = new List<Concert>();
        private int _idCounter = default;

        public bool Create(Concert concert)
        {
            if (concert == default)
            {
                return false;
            }

            return this.AddConcert(concert);
        }

        public List<Concert> GetAll()
        {
            return _concerts;
        }

        private bool AddConcert(Concert concert)
        {
            concert.Id = this.GenerateId();

            int beforeCount = _concerts.Count();
            _concerts.Add(concert);
            int afterCount = _concerts.Count();

            return afterCount > beforeCount;
        }

        private int GenerateId() => ++_idCounter;
    }
}
