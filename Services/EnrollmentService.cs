using System.Collections.Generic;
using System.Threading.Tasks;
using TmsApi.Models;

namespace TmsApi.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly List<Enrollment> _enrollments = new();

        public Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Enrollment>>(_enrollments);
        }

        public Task AddEnrollmentAsync(string studentName, string courseName)
        {
            var student = new Student { Id = _enrollments.Count + 1, Name = studentName };
            var course = new Course { Code = $"C{_enrollments.Count + 1}", Title = courseName, Capacity = 30 };

            _enrollments.Add(new Enrollment
            {
                Id = _enrollments.Count + 1,
                Student = student,
                Course = course
            });

            return Task.CompletedTask;
        }
    }
}
