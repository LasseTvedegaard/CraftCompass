using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Employee {

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public Employee() { }

        public Employee(int employeeId, string name, string phone, string email, string role) {
            EmployeeId = employeeId;
            Name = name;
            Phone = phone;
            Email = email;
            Role = role;
        }
    }
}
