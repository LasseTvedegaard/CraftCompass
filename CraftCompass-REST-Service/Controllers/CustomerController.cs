using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CraftPro_REST_Service.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase {

        private readonly ICRUD<Customer> _customerControl;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICRUD<Customer> customerControl, ILogger<CustomerController> logger = null) {
            _customerControl = customerControl;
            _logger = logger;
        }
    }
}
