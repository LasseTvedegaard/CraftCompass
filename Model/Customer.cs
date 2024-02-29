using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Customer {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Customer() { }

        public Customer(int customerId, string name, string phone, string email) {
            CustomerId = customerId;
            Name = name;
            Phone = phone;
            Email = email;
        }
    }
}
