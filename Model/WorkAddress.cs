using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class WorkAddress {
        public int WorkAddressId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public WorkAddress() { }

        public WorkAddress(int workAddressId, string address, string city, string postalCode, string country) {
            WorkAddressId = workAddressId;
            Address = address;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
