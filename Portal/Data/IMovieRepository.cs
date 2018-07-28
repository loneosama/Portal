using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models;

namespace Portal.Data
{
    public interface IMovieRepository
    {
        List<Movie> MovieListAsync();
        void AddMovie(Movie mov);
        Movie FindMovie(int id);
        void UpdateMovie(Movie mov);
        void DeleteMovie(Movie mov);

    }
}
