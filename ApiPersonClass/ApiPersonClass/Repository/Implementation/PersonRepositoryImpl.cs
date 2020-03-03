using ApiPersonClass.Model;
using ApiPersonClass.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ApiPersonClass.Repository.Implementation
{
    public class PersonRepositoryImpl : IPersonRepository
    {

        private MySQLContext _context;

        public PersonRepositoryImpl(MySQLContext context) 
        {
            _context = context;
        }
        private volatile int count;

        public Person Create(Person person)
        {
            try 
            {
                _context.Add(person);
                _context.SaveChanges();
            } 
            catch(Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null)
                _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Person> FindAll()
        {
            return _context.Persons.Where(e => e.Id.HasValue).ToList();
            /*
            List<Person> persons = new List<Person>();

            for(int i = 0; i < 8; i++) 
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;*/
        }
        public Person findById(long id)
        {
            
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

           /* return new Person { 
                Id = 1,
                FirstName="Leandro",
                LastName="Martins",
                Address="Centro, Porto Alegre",
                Gender="Male"
            
            };*/
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person(); 

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public bool Exists(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + i,
                LastName = "Person last name " + i,
                Address = "Person Anddress " + i,
                Gender = "Person Gender " + i

            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }


    }
}
