using System;
using CashierStation.Data;
using CashierStation.Model;

namespace CashierStation.Serivce
{
    public interface ICustomerService
    {
        public List<CustomerModel> GetCustomers();
        public CustomerModel GetCustomerByID(int ID);
        public CustomerModel AddCustomer(string firstName, string lastName, string email, bool isVIP);
        public CustomerModel AddVIPCustomer(string firstName, string lastName, string email);
        bool DeleteCustomer(int ID);
        List<CustomerModel> GetVIPCustomers();
    }

    public class CustomerService : ICustomerService
    {
        private ICustomerDAO _customerDAO;

        public CustomerService(ICustomerDAO customerService)
        {
            _customerDAO = customerService;
        }

        public List<CustomerModel> GetCustomers()
        {
            return _customerDAO.GetCustomers();
        }

        public CustomerModel GetCustomerByID(int ID)
        {
            return _customerDAO.GetCustomerByID(ID);
        }

        public CustomerModel AddCustomer(string firstName, string lastName, string email, bool isVIP)
        {
            return _customerDAO.AddCustomer(firstName, lastName, email, isVIP);
        }

        public CustomerModel AddVIPCustomer(string firstName, string lastName, string email)
        {
            return _customerDAO.AddCustomer(firstName, lastName, email, true);
        }

        public List<CustomerModel> GetVIPCustomers()
        {
            return _customerDAO.GetVIPCustomers();
        }

        public bool DeleteCustomer(int ID)
        {
            return _customerDAO.DeleteCustomer(ID);
        }
    }
}

