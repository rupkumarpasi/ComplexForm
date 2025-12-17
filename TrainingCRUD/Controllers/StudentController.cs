using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingCRUD.Service;
using TrainingCRUD.Models;
using TrainingCRUD.Dto;

namespace TrainingCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto student) // ← rename "std" → "student"
        {
            if (!ModelState.IsValid)
                return BadRequest("ModelState");

            var createdStudent = await _studentService.CreateStudent(student);
            return Ok(createdStudent);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("ModelState");
             await _studentService.UpdateStudent(id, studentDto);
            return Ok(await _studentService.GetStudentById(id));

        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            return Ok(students);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
           bool data= await _studentService.DeleteStudent(id);

            if (data)
            {

                return Ok("Deleted successfully");
            }
            else
            {
                return Ok("data not found,database doesnot contain related data");
            }
        }
    }
}
