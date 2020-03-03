using ApiPersonClass.Model;
using System.Collections.Generic;

namespace ApiPersonClass.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person findById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
        bool Exists(long? id);
    }
}
