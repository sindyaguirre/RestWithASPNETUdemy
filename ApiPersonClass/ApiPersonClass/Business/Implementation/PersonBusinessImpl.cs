using ApiPersonClass.Model;
using ApiPersonClass.Model.Context;
using ApiPersonClass.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ApiPersonClass.Business.Implementation
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        private IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository) 
        {
            _repository = repository;
        }
        private volatile int count;

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
        public Person findById(long id)
        {
            return _repository.findById(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

    }
}
