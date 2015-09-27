using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer() { id = 1, Name = "Jonhn" };

            CustomerRepository repo = new CustomerRepository();

            repo.Add(c1);

            Console.WriteLine(repo.FindById(1).Name.ToString());
            Console.ReadKey();
        }
    }

    public class Entity
    {
        
    }

    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int id);
    }

    public class Customer : Entity
    {
        public int id { get; set; }

        public string Name { get; set; }
    }

    public class CustomerRepository : IRepository<Customer>
    {
        List<Customer> FakeDB = new List<Customer>(); 

        public IEnumerable<Customer> List { get { return FakeDB; } }

        public void Add (Customer customer)
        {
            FakeDB.Add(customer);
        }

        public void Delete(Customer customer)
        {
            FakeDB.Remove(customer);
        }

        public void Update(Customer customer)
        {

            FakeDB.Single(c => c.id == customer.id).Name = customer.Name;

        }

        public Customer FindById(int ID)
        {
            return FakeDB.Single(cust => cust.id == ID);
        }

    }
}
