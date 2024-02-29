using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Case {

        public int CaseId { get; set; }
        public string CaseName { get; set; }
        public string CaseType { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? Deadline { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public string Priority { get; set; }
        public DateTime? StartDate { get; set; }
        public int? EstimatedWorkTime { get; set; }
        public string MaterialStatus { get; set; }
        public WorkAddress WorkAddressId { get; set; }
        public Customer CustomerId { get; set; }

        public Case() { }

        public Case(int caseId, string caseName, string caseType, decimal totalPrice, DateTime deadline, string status, string paymentStatus, string priority, DateTime startDate, int estimatedWorkTime, string materialStatus, WorkAddress workAddressId, Customer customerId) {
            CaseId = caseId;
            CaseName = caseName;
            CaseType = caseType;
            TotalPrice = totalPrice;
            Deadline = deadline;
            Status = status;
            PaymentStatus = paymentStatus;
            Priority = priority;
            StartDate = startDate;
            EstimatedWorkTime = estimatedWorkTime;
            MaterialStatus = materialStatus;
            WorkAddressId = workAddressId;
            CustomerId = customerId;
        }

        public Case(string caseName, string caseType, decimal totalPrice, DateTime deadline, string status, string paymentStatus, string priority, DateTime startDate, int estimatedWorkTime, string materialStatus, WorkAddress workAddressId, Customer customerId) {
            CaseName = caseName;
            CaseType = caseType;
            TotalPrice = totalPrice;
            Deadline = deadline;
            Status = status;
            PaymentStatus = paymentStatus;
            Priority = priority;
            StartDate = startDate;
            EstimatedWorkTime = estimatedWorkTime;
            MaterialStatus = materialStatus;
            WorkAddressId = workAddressId;
            CustomerId = customerId;
        }
    }
}
