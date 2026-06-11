using Microsoft.Extensions.DependencyInjection;
namespace TmsApi.Workers;

public class EnrollmentWorker
{
    private readonly IServiceScopeFactory _scopeFactory;

    public EnrollmentWorker(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public void ProcessBatch()
    {
        // ✅ Create a short-lived scope
        using var scope = _scopeFactory.CreateScope();

        // ✅ Resolve the scoped service from this scope
        var svc = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();

        // ✅ Use the service inside the scope
        var all = svc.GetAllAsync().Result;

        // Example: log or process the batch
        Console.WriteLine($"Processed {all.Count} enrollments");

        // Scope and its services are disposed automatically at the end of the using block
    }
}
