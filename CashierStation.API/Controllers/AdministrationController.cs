using System;
using Microsoft.AspNetCore.Mvc;
using CashierStation.Serivce;
using CashierStation.Model;

namespace CashierStation.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // why did this work??
    public class AdministrationController
    {
        private IAdministrationService _administrationService;
        private ICustomerService _customerService;

        public AdministrationController(IAdministrationService administrationService, ICustomerService customerService)
        {
            _administrationService =  administrationService;
            _customerService = customerService;
        }

        [HttpGet(Name = "GetVIPCustomersForAdmin" )]
        public List<CustomerModel> GetVIPCustomersForAdmin()
        {
            return _administrationService.GetVIPCustomers();
        }

        [HttpPost(Name = "AddVIPCustomers")]
        public List<CustomerModel> AddVipCustomers(string firstName, string lastName, string email)
        {
             _administrationService.AddVIPCustomer(firstName, lastName, email);
            return _administrationService.GetVIPCustomers();
        }

        [HttpPost(Name = "AddVIPCustomers2")]
        public List<CustomerModel> AddVipCustomers2(string firstName, string lastName, string email)
        {
            _administrationService.AddVIPCustomer(firstName, lastName, email);
            return _customerService.GetVIPCustomers();
        }
    }
}
