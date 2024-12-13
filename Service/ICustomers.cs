using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Service
{
    public interface ICustomers
    {
        string InsertCustomer(Customer customer);
        List<Customer> GetAllCustomer();

    }
}
