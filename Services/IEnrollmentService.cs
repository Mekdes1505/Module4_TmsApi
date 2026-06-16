using System.Collections.Generic;
using System.Threading.Tasks;
using TmsApi.Models;

namespace TmsApi.Services
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<Enrollment>> GetAllAsync();
        Task AddEnrollmentAsync(string studentName, string courseName);
    }
}
