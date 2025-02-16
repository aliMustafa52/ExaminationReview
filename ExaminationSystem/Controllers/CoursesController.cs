using ExaminationSystem.Entities;
using ExaminationSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PredicateExtensions;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        CourseRepository _courseRepository;

        public CoursesController()
        {
            _courseRepository = new CourseRepository();
        }

        public IActionResult GetAll()
        {
            var x = _courseRepository.GetAll();

            return Ok(x);
        }

        [HttpGet]
        public IEnumerable<Course> Get(int? crsId, string name, int? hours)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<Course>(true);

            if(crsId.HasValue)
            {
                predicate.And(c => c.Id == crsId.Value);
            }

            if (!string.IsNullOrEmpty(name))
            {
                predicate.And(c => c.Name == name);
            }

            if (hours.HasValue)
            {
                predicate.And(c => c.Hours == hours.Value);
            }

            return _courseRepository.Get(predicate).ToList();
        }

        [HttpPost]
        public bool Add(Course course)
        {
            _courseRepository.Add(course);

            return true;
        }

        [HttpPut]
        public bool Update(Course course)
        {
            _courseRepository.UpdateInclude(course, nameof(Course.Name), nameof(Course.Hours));

            return true;
        }

    }
}
