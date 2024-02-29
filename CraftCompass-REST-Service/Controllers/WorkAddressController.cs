using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CraftPro_REST_Service.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WorkAddressController : ControllerBase {

        private readonly ICRUD<WorkAddress> _workAddress;
        private readonly ILogger<WorkAddressController> _logger;

        public WorkAddressController(ICRUD<WorkAddress> workAddress, ILogger<WorkAddressController> logger = null) {
            _workAddress = workAddress;
            _logger = logger;
        }

        
    }
}
