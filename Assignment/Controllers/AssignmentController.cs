using Assignment.Service;
using Microsoft.AspNetCore.Mvc;
using static Assignment.Model.AssignmentModel;

namespace Assignment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        #region Task no 1 invert the string

        [HttpGet]
        [Route("InvertText")]
        public async Task<IActionResult> GetInvertedText([FromQuery] InverseText Request)
        {
            if (Request.Text == null)
            {
                return BadRequest();
            }
            string? result = await _assignmentService.StringReverser(Request).ConfigureAwait(false);
            return result != null ? Ok(result) : NotFound();
        }

        #endregion

        #region Task no 2 

        [HttpGet]
        [Route("GetDataProcess")]
        public IActionResult GetDataProcess()
        {
            var Result = _assignmentService.FunctionA();
            return Result != null ? Ok(Result) : NotFound();
        }

        #endregion


        #region Task no 3 read bin file and calculate SHA in Hex form

        [HttpGet]
        [Route("GetSHACalculation")]
        public IActionResult GetSHACalculation()
        {
            int Result = _assignmentService.GetHashCode();
            return Ok(Result.ToString());
        }

        #endregion


        #region Task no 4 get data from given API

        [HttpGet]
        [Route("CryptoBlockAPI")]
        public IActionResult GetDataFromBlocktapAPI()
        {
            var Result = _assignmentService.PageAssets();
            return Ok(Result);
        }

        #endregion

    }
}
