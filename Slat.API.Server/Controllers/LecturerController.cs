using Microsoft.AspNetCore.Mvc;
using Slat.API.Server.DataModels;
using Slat.API.Server.Services;

namespace Slat.API.Server.Controllers
{
    [Route("api/[controller]")]
    public class LecturerController : ControllerBase


    {
        //making Lecturer service  readonly 
        private readonly LecturrerService lecturrerService;

        //injecting lecturer service into the controller
        public LecturerController(LecturrerService lecturrerService)
        {
            this.lecturrerService = lecturrerService;

        }
        [HttpPost("api/lecturer/create")]
        public ActionResult CreatedLecturer([FromBody] LecturerCredentials lecturerCredentials)
        {
            var CreateLecturer = lecturrerService.CreatedLecturer(lecturerCredentials);
            return Ok(CreateLecturer);
        }

        [HttpGet("{id}")]
        public ActionResult GetLecturer(Guid id)
        {
            var LecturerId = lecturrerService.GetLecturer(id);
            return Ok(LecturerId);
        }

        [HttpGet("api/GetAllLecturer/create")]
        public ActionResult AllLecturer()
        {
            var GetAllLecturer = lecturrerService.AllLecturer();
                
                return Ok(GetAllLecturer);
            
        }

        [HttpDelete("api/lecturer/{lecturerId}")]
        public ActionResult RemoveLecturer(Guid lecturerId)
            
        {
            var result = lecturrerService.RemoveLecturer(lecturerId);
      

            if (!result.Successful)
            {
                return NotFound(result.ErrorMessage);
            }

            return Ok(result.Result);
        }


        [HttpPut("api/lecturer/{id}")]
        public ActionResult UpdateLecturer(Guid id, [FromBody] LecturerCredentials lecturerCredentials)
        {
            var result = lecturrerService.UpdateLecturer(id, lecturerCredentials);

            if (!result.Successful)
            {
                return NotFound(result.ErrorMessage);
            }

            return Ok(result.Result);
        }


    }
}
