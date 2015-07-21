using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DvDCollection.Repositories;

namespace DvDCollection.BizLogic
{
    public class BusinessLogic
    {
        private IDvDRepository _repo = new DvDDBRepository();

        public void AddMovie(Movy movie)
        {
            _repo.Add(movie);
        }

        public void EditMovie(Movy movie)
        {
            _repo.Edit(movie);
        }

        public void DeleteMovie(Movy movie)
        {
            _repo.Delete(movie.MovieID);
        }

        public Movy GetMovie(int id)
        {
            return _repo.GetMovieById(id);
        }

        public List<Movy> GetAllMovies()
        {
            return _repo.GetAllMoviesList();
        }

        public Actor GetActor(int id)
        {
            return _repo.GetActorById(id);
        }

        public List<Actor> GetAllActors()
        {
            return _repo.GetAllActorsList();
        }

        public void AddStar(Actor actor)
        {
            _repo.AddActor(actor);
        }

        public void EditStar(Actor actor)
        {
            _repo.EditActor(actor);
        }
    }
}