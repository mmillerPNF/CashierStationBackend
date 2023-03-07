using System;
using CashierStation.Model;

namespace CashierStation.Data
{
    public interface ICustomerDAO
    {
        List<CustomerModel> GetCustomers();
        CustomerModel GetCustomerByID(int ID);
        CustomerModel AddCustomer(string firstName, string lastName, string email, bool isVIP);
        List<CustomerModel> GetVIPCustomers();
        bool DeleteCustomer(int ID);
        CustomerModel AddVIPCustomer(string firstName, string lastName, string email);
    }

    public class CustomerDAO : ICustomerDAO
    {
        private List<CustomerModel> _customers = new List<CustomerModel>();

        public CustomerModel CustomerOne;
        public CustomerModel CustomerTwo;
        public CustomerModel CustomerThree;

        public CustomerDAO()
        {
            CustomerOne = new CustomerModel("Mikail", "Miller", "mmiller@pnf.com", false);
            CustomerTwo = new CustomerModel("Jason", "Linton", "jlinton@pnf.com", true);
            CustomerThree = new CustomerModel("The", "Murlocs", "themurlocs@pnf.com", false);

            // Null-conditional operator ?. only operates on non-null operands
            _customers?.Add(CustomerOne);
            _customers?.Add(CustomerTwo);
            _customers?.Add(CustomerThree);
        }

        public List<CustomerModel> GetCustomers() => _customers;

        public CustomerModel GetCustomerByID(int ID)
        {
            var customerFound = _customers?.FirstOrDefault(x => x.CustomerID == ID);

            if (customerFound == null)
            {
                throw new Exception($"No customer found with ID matching {ID}");
            }

            return customerFound;


        }
        public CustomerModel AddCustomer(string firstName, string lastName, string email, bool isVIP)
        {
            var newCustomer = new CustomerModel(firstName, lastName, email, isVIP);
            _customers?.Add(newCustomer);
            return newCustomer;
        }

        public List<CustomerModel> GetVIPCustomers()
        {
            var tempList = new List<CustomerModel>();

            foreach(var customer in _customers)
            {
                if (customer.IsVIP)
                    tempList.Add(customer);
            }

            return tempList;
        }

        public CustomerModel AddVIPCustomer(string firstName, string lastName, string email)
        {
            var tempCustomer = new CustomerModel(firstName, lastName, email, true);
            _customers.Add(tempCustomer);
            return tempCustomer;
        }

        public bool DeleteCustomer(int ID)
        {
            var index = _customers.FindIndex(x => x.CustomerID == ID);

            if(index == -1)
                throw new Exception($"Customer does not exist with ID: {ID}");
            
            _customers.RemoveAt(index);
            return true;
        }

    }
}

