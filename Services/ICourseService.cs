using System.Collections.Generic;
using TmsApi.Models;

namespace TmsApi.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        void AddCourse(string code, string title, int capacity);
    }
}
