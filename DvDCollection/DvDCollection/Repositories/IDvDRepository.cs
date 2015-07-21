using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DvDCollection.Repositories
{
    interface IDvDRepository
    {
        void Add(Movy movie);
        void Edit(Movy movie);
        void AddActor(Actor actor);
        void EditActor(Actor actor);
        Movy GetMovieById(int id);
        List<Movy> GetAllMoviesList();
        Actor GetActorById(int id);
        List<Actor> GetAllActorsList();
        void Delete(int id);
    }
}
