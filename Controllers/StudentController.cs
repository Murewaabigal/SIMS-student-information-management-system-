using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using SIMS.model;
using SIMS.RepositoryFolder;

namespace SIMS.Controllers
{
    [ApiController]
    //[Route("api/[Controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentRepository _repo;
        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }
        [HttpPost("add")]
        public IActionResult AddStudent(Student student)
        {
            _repo.Add(student);
            return Ok();
        }

        [HttpGet("get")]
        public IActionResult GetStudent(string Id)
        {
            Student student = _repo.GetStudent(Id);
            return Ok(student);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(string Id)
        {
            _repo.Delete(Id);
                return Ok();
        }
        [HttpPost("add")]
        public IActionResult Update(Student student) 
        {
            _repo.Update(student);
            return Ok();
        }
    }
    
}
