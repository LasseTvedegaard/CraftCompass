using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CraftPro_REST_Service.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {

        private readonly ICRUD<Employee> _employeeControl;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ICRUD<Employee> employeeControl, ILogger<EmployeeController> logger = null) {
            _employeeControl = employeeControl;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee) {
            IActionResult foundResult;
            int insertedId = await _employeeControl.Create(employee);
            if (insertedId == -1) {
                foundResult = StatusCode(500);
            } else {
                employee.EmployeeId = insertedId;
                foundResult = CreatedAtAction(nameof(Get), new { id = insertedId }, employee);
            }
            return foundResult;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get() {
            ActionResult<List<Employee>> foundReturn;
            List<Employee>? foundEmployees = await _employeeControl.GetAll();
            if (foundEmployees != null) {
                foundReturn = Ok(foundEmployees);
            } else {
                foundEmployees = new List<Employee>();
                foundReturn = Ok(foundEmployees);
            }
            return foundReturn;
        }

        [HttpPut("EmployeeId")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee) {
            IActionResult foundResult;

            bool isUpdated = await _employeeControl.Update(id, employee);
            if (isUpdated) {
                foundResult = Ok();
            } else {
                foundResult = StatusCode(500);
            }
            return foundResult;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id) {
            IActionResult result;

            if (id > 0) {
                bool isDeleted = await _employeeControl.Delete(id);
                if (isDeleted) {
                    result = NoContent();
                } else {
                    result = StatusCode(500);
                }
            } else {
                result = BadRequest();
            }
            return result;
        }
    }
}
