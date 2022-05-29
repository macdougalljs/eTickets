using eTickets.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        // we are just going to device the method signatures - an interface is just a contract

        Task<IEnumerable<Actor>> GetAllAsync();

        Task<Actor> GetByIdAsync(int id);
      
        Task AddAsync(Actor actor);

        Task<Actor> UpdateAsync(int id, Actor newActor);
        void Delete(int id);
    }
}
