using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Entities;
using RestfulAPI.ResponseModel;

namespace RestfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("GetStudents")]
        public CommonResponse<List<Student>> GetStudents()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { Id = 1, Name = "Halil", Surname = "Koçak", CreatedDate = DateTime.Now, Score = 100 });
            students.Add(new Student { Id = 2, Name = "Ali", Surname = "Koçak", CreatedDate = DateTime.Now, Score = 100 });
            students.Add(new Student { Id = 3, Name = "Ayşe", Surname = "Koçak", CreatedDate = DateTime.Now, Score = 100 });

            return new CommonResponse<List<Student>>(students);
        }

        [HttpGet]
        [Route("GetAll")]
        public CommonResponse<List<Student>> GetAll()
        {
            return GetStudents();
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
                var list = GetAll();
                var student = list.Data.Where(x => x.Id == id).FirstOrDefault();
                return Ok(new CommonResponse<Student>(student));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetByFilterName")]
        public IActionResult GetFilterByName([FromQuery] string name)
        {
            try
            {
                var list = GetAll();
                var result = list.Data.Where(x => x.Name.ToUpper() == name.ToUpper()).ToList();
                return Ok(new CommonResponse<List<Student>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: StudentController/Create
        [HttpPost]
        [Route("CreateStudent")]
        public IActionResult Create(Student student)
        {
            try
            {
                var list = GetAll().Data;
                list.Add(student);
                return Ok(new CommonResponse<Student>(student));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: StudentController/Edit/5
        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult Edit(int id, Student student)
        {
            try
            {
                var result = GetAll().Data.Where(x => x.Id == id).FirstOrDefault();
                GetAll().Data.Remove(result);

                student.Id = id;
                GetAll().Data.Add(student);
                return Ok(new CommonResponse<Student>(student));
            }
            catch (Exception ex)
            {
                return BadRequest("Not Found!!");
            }
        }

        // POST: StudentController/Delete/5
        [HttpDelete]
        [Route("DeleteStudent")]
        public IActionResult Delete(int id)
        {
            var result = GetAll().Data.Where(x => x.Id == id).FirstOrDefault();
            if (result is not null)
            {
                GetAll().Data.Remove(result);
                return Ok("Removed Student");
            }
            else
                return BadRequest("Not Found Student!!");
        }
    }
}
