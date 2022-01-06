using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        MovieDAL db = new MovieDAL();
        public List<Movie> GetMovie()
        {
            return db.GetMovies();
        }
        [HttpGet("GetRandomMovie")]
        public Movie GetRandomMovie()
        {
            List<Movie> allMovies = GetMovie();
            Random rando = new Random();            
            return allMovies[rando.Next(0, allMovies.Count)];
        }
        [HttpGet("GetMoviesByCategory/{category}")]
        public List<Movie> GetMoviesByCategory(string category)
        {
            List<Movie> allMovies = GetMovie();
            List<Movie> moviesToReturn = new List<Movie>();
            category = category.Trim().ToLower();
            foreach(Movie m in allMovies)
            {
                if(m.Category.ToLower().Trim() == category || m.Category.ToLower().Trim().Contains(category))
                {
                    moviesToReturn.Add(m);
                }
            }
            return moviesToReturn;
        }
        [HttpGet("GetRandomMovieByCategory/{category}")]
        public Movie GetRandomMovieByCategory(string category)
        {
            Movie d = new Movie();
            List<Movie> allMovies = GetMoviesByCategory(category);
            Random rando = new Random();
            try
            {
                return allMovies[rando.Next(0, allMovies.Count)];
            }
            catch (ArgumentOutOfRangeException)
            {
                return d;
            }
        }
    }
}
