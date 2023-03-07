using System;
using CashierStation.Model;
using CashierStation.Data;

namespace CashierStation.Serivce
{
    public interface IAdministrationService
    {
        public List<CustomerModel> GetVIPCustomers();
        public CustomerModel AddVIPCustomer(string firstName, string lastName, string email);
    }
    public class AdministrationService : IAdministrationService
    {
        private ICustomerDAO _customerDAO;

        public AdministrationService(ICustomerDAO customerDAO)
        {
            _customerDAO = customerDAO;
        }

        public List<CustomerModel> GetVIPCustomers()
        {
            return _customerDAO.GetVIPCustomers();
        }

        public CustomerModel AddVIPCustomer(string firstName, string lastName, string email)
        {
           return _customerDAO.AddVIPCustomer(firstName, lastName, email);
        }
    }
}

