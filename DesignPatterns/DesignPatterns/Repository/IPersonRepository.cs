using DesignPatterns.AppDbModels;

namespace DesignPatterns.Repository
{
    public interface IPersonRepository
    {
        public Task<List<Person>> GetPeople();
        public Task<Person> GetPersonById(int id);


        public Task<int> AddPerson(Person person);
        public Task<Person> UpdatePerson(Person person);
        public Task DeletePerson(int id);

    }
}
