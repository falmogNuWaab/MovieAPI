using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI
{
    public class MovieDAL
    {
        public List<Movie> GetMovies()
        {
            using(var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from movies";
                connect.Open();
                List<Movie> allMovies = connect.Query<Movie>(sql).ToList();
                connect.Close();
                return allMovies;
            }
            
        }
    }
}
