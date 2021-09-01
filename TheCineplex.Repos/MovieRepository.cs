using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCineplex.Models;

namespace TheCineplex.Repos
{
    public class MovieRepository
    {
        private readonly List<Movie> _movies = new List<Movie>();
        private int _idCounter = default;

        public bool Create(Movie movie)
        {
            if (movie == default)
            {
                return false;
            }

            return this.AddMovie(movie);
        }

        public List<Movie> GetAll()
        {
            return _movies;
        }

        private bool AddMovie(Movie movie)
        {
            movie.Id = this.GenerateId();

            int beforeCount = _movies.Count();
            _movies.Add(movie);
            int afterCount = _movies.Count();

            return afterCount > beforeCount;
        }

        private int GenerateId() => ++_idCounter;
    }
}
