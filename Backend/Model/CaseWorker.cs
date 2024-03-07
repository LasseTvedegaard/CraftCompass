using System;

namespace Model {
    public class CaseWorker {

        public int CaseWorkerId { get; set; }
        public int CaseId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation properties
        public Case Case { get; set; }
        public Employee Employee { get; set; }

        public CaseWorker() { }

        public CaseWorker(int caseId, int employeeId) {
            CaseId = caseId;
            EmployeeId = employeeId;
        }

        public CaseWorker(int caseId, int employeeId, DateTime startDate, DateTime endDate) : this(caseId, employeeId) {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
