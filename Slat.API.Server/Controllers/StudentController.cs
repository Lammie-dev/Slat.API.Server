using Microsoft.AspNetCore.Mvc;
using Slat.API.Server.Services;
using System.Reflection.Metadata.Ecma335;

namespace Slat.API.Server.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        //injecting studentServices into the controller
        private readonly StudentService studentService;
        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost("api/student/create")]
        public ActionResult CreateStudent([FromBody] StudentCredentials studentCredentials)
        {
            var createdStudent = studentService.CreateStudent(studentCredentials);


            return Ok(createdStudent);

        }

        [HttpGet("{id}")]
        public ActionResult GetStudent(Guid id)
        {
            var retrieveStudent = studentService.GetStudent(id);


            return Ok(retrieveStudent);

        }

        [HttpGet("api/student/GetAllStudent")]

        public ActionResult GetAllStudent()
        {
            
                var getAllStudent = studentService.GetAllStudent();
                return Ok(getAllStudent);
          
        }


        [HttpDelete("api/student/{id}")]
        public ActionResult RemoveStudent(Guid id)

        {
            var result = studentService.RemoveStudent(id);


            if (!result.Successful)
            {
                return NotFound(result.ErrorMessage);
            }

            return Ok(result.Result);
        }


        [HttpPut("api/student/{id}")]
        public ActionResult UpdateStudent(Guid id, [FromBody] StudentCredentials studentCredentials)
        {
            var result = studentService.UpdateStudent(id, studentCredentials);

            if (!result.Successful)
            {
                return NotFound(result.ErrorMessage);
            }

            return Ok(result.Result);
        }

    }

}

