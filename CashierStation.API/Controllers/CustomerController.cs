using Microsoft.AspNetCore.Mvc;
using CashierStation.Model;
using CashierStation.Serivce;

namespace CashierStation.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // why did this work??

    public class CustomerController : ControllerBase
    {
        private ICustomerService? _customerService;

        // create constructor, initialize customer service instance
       public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet(Name = "GetCustomers")]
        public List<CustomerModel>? GetCustomers()
        {
            return _customerService?.GetCustomers();

        }

        [HttpGet(Name = "GetCustomerByID")]
        public CustomerModel? GetCustomer(int ID)
        {
            return _customerService?.GetCustomerByID(ID);
        }

        // post method to create a new customer and return all customers
        [HttpPost(Name = "AddNewCustomer")]
        public CustomerModel? AddNewCustomer(string firstName, string lastName, string email, bool isVIP)
        {
            return _customerService?.AddCustomer(firstName, lastName, email, isVIP);
        }

        // post method to create a new customer and return all customers
        [HttpPost(Name = "AddNewVIPCustomer")]
        public List<CustomerModel>? AddNewVIPCustomer(string firstName, string lastName, string email)
        {
            _customerService?.AddVIPCustomer(firstName, lastName, email);
            return _customerService?.GetVIPCustomers();
        }

        [HttpGet(Name = "GetVIPCustomers")]
        public List<CustomerModel>? GetVIPCustomers()
        {
            return _customerService?.GetVIPCustomers();
        }
    }
}

// new CustomerController
// endpoints for getcustomers, get by id, add new customer