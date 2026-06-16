using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace TmsApi.Services
{
    public class EnrollmentWorker
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public EnrollmentWorker(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task ProcessBatchAsync()
        {
            // ✅ Create a short-lived scope
            using var scope = _scopeFactory.CreateScope();

            // ✅ Resolve the scoped service from this scope
            var svc = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();

            // ✅ Use the service inside the scope
            var all = await svc.GetAllAsync();

            // Example: log or process the batch
            Console.WriteLine($"Processed {all.Count()} enrollments");

            // Scope and its services are disposed automatically at the end of the using block
        }
    }
}
