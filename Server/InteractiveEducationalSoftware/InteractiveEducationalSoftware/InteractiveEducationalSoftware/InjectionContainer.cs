using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
using IES.Models;
using IES.Services;
using PhoneCatalog.Repositories;

namespace IES.WebHost
{
    public static class InjectionContainer
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IUsersService), typeof(UsersService));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IUsersRepository), typeof(UsersRepository));
        }
    }
}
