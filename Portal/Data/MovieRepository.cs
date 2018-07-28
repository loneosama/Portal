using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models;

namespace Portal.Data
{
    public class MovieRepository:IMovieRepository
    {
        private ApplicationDbContext _db;
        public MovieRepository(ApplicationDbContext context)
        {
            _db = context;
        }
        public List<Movie> MovieListAsync()
        {
             return _db.Movie.ToList();
        }

        public void AddMovie(Movie mov)
        {
            _db.Movie.Add(mov);
            _db.SaveChanges();
        }

        public Movie FindMovie(int id)
        {
           return _db.Movie.SingleOrDefault(x => x.ID == id);
        }

        public void UpdateMovie(Movie mov)
        {
            _db.Update(mov);
            _db.SaveChanges();

        }

        public void DeleteMovie(Movie mov)
        {
            _db.Movie.Remove(mov);
            _db.SaveChanges();
        }
    }
}
