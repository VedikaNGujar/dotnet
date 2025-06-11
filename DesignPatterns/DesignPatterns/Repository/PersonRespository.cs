using System;
using DesignPatterns.AppDbModels;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Repository
{
    public class PersonRespository(AppDbContext appDbContext) : IPersonRepository
    {
        public async Task<int> AddPerson(Person person)
        {
            await appDbContext.Persons.AddAsync(person);
            appDbContext.SaveChanges();
            return person.Id;
        }

        public async Task DeletePerson(int id)
        {
            var res = await appDbContext.Persons.FindAsync(id);
            if (res != null)
                appDbContext.Persons.Remove(res);
        }

        public async Task<List<Person>> GetPeople()
        {
            return await appDbContext.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await appDbContext.Persons.FindAsync(id);
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            var res = await appDbContext.Persons.FindAsync(person.Id);
            if (res == null)
            {
                return null;
            }
            else
            {
                res.Address = person.Address;
                res.Name = person.Name;
                res.Phone = person.Phone;
                appDbContext.Persons.Update(res);
                appDbContext.SaveChanges();
                return person;
            }

        }
    }
}
