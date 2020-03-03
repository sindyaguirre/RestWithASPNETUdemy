using ApiPersonClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonClass.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person findById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
