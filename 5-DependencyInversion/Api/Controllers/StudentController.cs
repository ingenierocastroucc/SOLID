using Microsoft.AspNetCore.Mvc;
using DependencyInversion;

namespace DependencyInversion.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController : ControllerBase
    {
        IStudentRepository studentRepository;
        ILogbook logbook;

        // Constructor de inyección de dependencias
        public StudentController(IStudentRepository student, ILogbook log)
        {
            studentRepository = student;  // Asignamos correctamente el parámetro al campo
            logbook = log;  // Corregido el nombre de la variable
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            logbook.Add("Returning student's list");
            return studentRepository.GetAll();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Student student)
        {
            studentRepository.Add(student);
            logbook.Add($"The Student {student.Fullname} has been added");
            return Ok();
        }
    }
}