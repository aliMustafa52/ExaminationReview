using ExaminationSystem.Persistence;
using ExaminationSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        CourseRepository _courseRepository;

        public QuestionsController()
        {
            _courseRepository = new CourseRepository();
        }
    }
}
