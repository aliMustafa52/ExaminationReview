using ExaminationSystem.Abstractions;

namespace ExaminationSystem.Errors
{
    public static class CourseErrors
    {
        public static readonly Error CourseNotFound =
            new("Course.NotFound", "No Course was found with the given ID", StatusCodes.Status404NotFound);

        public static readonly Error DuplicatedCourseTitle =
            new("Course.DuplicatedTitle", "Another Course with the same content is already exists", StatusCodes.Status409Conflict);
    }
}
