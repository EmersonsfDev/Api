using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }
       
        async Task<Person> IPersonRepository.CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        async Task IPersonRepository.DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        async Task IPersonRepository.EditAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }

        async Task<Person> IPersonRepository.GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        async Task<ICollection<Person>> IPersonRepository.GetPeopleAsync()
        {
            return await _db.People.ToListAsync();
        }
 
    }
}
