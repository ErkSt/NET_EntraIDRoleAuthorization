using ApiTestEntraID.Application.Interfaces;
using ApiTestEntraID.Infrastructure.Repositories;
using ApiTestEntraID.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTestEntraID.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
        services.AddSingleton<IUserRepository, InMemoryUserRepository>();
        services.AddSingleton<IDepartmentRepository, InMemoryDepartmentRepository>();
        services.AddSingleton<IReportService, MockReportService>();

        return services;
    }
}