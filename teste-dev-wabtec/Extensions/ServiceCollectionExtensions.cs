using teste_dev_wabtec.Api.Services;

namespace teste_dev_wabtec.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            #region Service
            services.AddScoped<ITaskService, TaskService>();
            #endregion

            #region Repository
            #endregion

            return services;
        }
    }
}
