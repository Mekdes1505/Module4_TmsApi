using System.Collections.Generic;
using TmsApi.Models;

namespace TmsApi.Services
{
    public class CourseService : ICourseService
    {
        private readonly List<Course> _courses = new();

        public IEnumerable<Course> GetAllCourses() => _courses;

        public void AddCourse(string code, string title, int capacity)
        {
            _courses.Add(new Course
            {
                Code = code,
                Title = title,
                Capacity = capacity,
                EnrolledCount = 0
            });
        }
    }
}
