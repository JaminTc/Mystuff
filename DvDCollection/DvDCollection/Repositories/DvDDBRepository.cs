using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DvDCollection.Repositories
{
    public class DvDDBRepository : IDvDRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DvDDBsource"].ConnectionString;

        public void Add(Movy movie)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var commandText =
                    "INSERT INTO Movies (Title, Rating, Year, Runtime, Director) VALUES (@Title, @Rating, @Year, @Runtime, @Director)";
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@Rating", movie.Rating);
                command.Parameters.AddWithValue("@Year", movie.Year);
                command.Parameters.AddWithValue("@Runtime", movie.Director);
                command.Parameters.AddWithValue("@Director", movie.Director);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Edit(Movy movie)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var commandText =
                    "UPDATE Movies Set Title = @Title, Rating = @Rating, Year = @Year, Runtime = @Runtime, Director = @Director WHERE MovieId = @Id";
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.AddWithValue("@Id", movie.MovieID);
                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@Rating", movie.Rating);
                command.Parameters.AddWithValue("@Year", movie.Year);
                command.Parameters.AddWithValue("@Runtime", movie.Director);
                command.Parameters.AddWithValue("@Director", movie.Director);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Movy GetMovieById(int id)
        {
            return GetAllMoviesList().FirstOrDefault(x => x.MovieID == id);
        }

        public List<Movy> GetAllMoviesList()
        {
            List<Movy> movies = new List<Movy>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Movies", conn);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Movy movie = new Movy();
                    movie.MovieID = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.Rating = reader.GetString(2);
                    movie.Year = reader.GetInt32(3);
                    movie.Runtime = reader.GetInt32(4);
                    movie.Director = reader.GetString(5);
                    movie.Actors = new List<Actor>();
                    movies.Add(movie);
                }
            }
            return movies;
        }

        public List<Actor> GetAllActorsList()
        {
            List<Actor> Actors = new List<Actor>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Actors WHERE ActorID == id", conn);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Actor star = new Actor();
                    star.ActorID = reader.GetInt32(0);
                    star.FirstName = reader.GetString(1);
                    star.LastName = reader.GetString(2);
                    star.Movies = new List<Movy>();
                    Actors.Add(star);
                }
            }
            return Actors;
        }
        public Actor GetActorById(int id)
        {
            return GetAllActorsList().FirstOrDefault(x => x.ActorID == id);
        }


        public void AddActor(Actor actor)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var commandText = "INSERT INTO Actors (FirstName, LastName) VALUES (@FirstName, @LastName)";
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.AddWithValue("@FirstName", actor.FirstName);
                command.Parameters.AddWithValue("@LastName", actor.LastName);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditActor(Actor actor)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var commandText =
                    "UPDATE Movies Set FirstName = @FirstName, LastName = @LastName WHERE ActorId = @Id";
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.AddWithValue("@Id", actor.ActorID);
                command.Parameters.AddWithValue("@FirstName", actor.FirstName);
                command.Parameters.AddWithValue("@LastName", actor.LastName);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var commandText = "DELETE FROM Movies WHERE MovieID = @id";
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.AddWithValue("@id", id);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}