using System;

namespace CashierStation.Model
{
    public class CustomerModel
    {
        private static int ID = 0;

        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsVIP { get; set; }

        public CustomerModel(string FirstName, string LastName, string Email, bool isVIP)
        {
            CustomerID = CustomerModel.ID++;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.IsVIP = isVIP;
        }
    }
}