using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Models;

namespace Portal.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _context;

        public MoviesController(IMovieRepository context)
        {
            _context = context;
        }

        // GET: Movies
        public IActionResult Index()
        {
            return View(_context.MovieListAsync());
        }

        // GET: Movies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            
            var movie = _context.FindMovie((int) id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,ReleaseYear,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.AddMovie(movie);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            var movie = _context.FindMovie((int) id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("ID,Name,ReleaseYear,Rating")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.UpdateMovie(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            var movie = _context.FindMovie((int) id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
            //_context.Movie.Remove(movie);
            //await _context.SaveChangesAsync();
            var movie = _context.FindMovie((int)id);
            _context.DeleteMovie(movie);
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {

            if (_context.FindMovie((int) id) != null)
            {
                return true;
            }
            else return false;

            //return _context.Movie.Any(e => e.ID == id);
        }
    }
}
