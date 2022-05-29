using eTickets.Models;
using System.Collections;
using System.Collections.Generic;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        // we are just going to device the method signatures - an interface is just a contract

        IEnumerable<Actor> GetAll();

        Actor GetById(int id);

        void Add(Actor actor);

        Actor Update(int id, Actor newActor);

        void Delete(int id);
    }
}
