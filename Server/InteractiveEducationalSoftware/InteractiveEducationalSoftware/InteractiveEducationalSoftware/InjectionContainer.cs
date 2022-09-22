namespace IES.WebHost
{
    public static class InjectionContainer
    {
        public static void InjectServices(IServiceCollection services)
        {
            //services.AddScoped(typeof(ISubscribersService), typeof(SubscribersService));
            //services.AddScoped(typeof(IService<Region, int>), typeof(RegionsService));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            //services.AddScoped(typeof(IRepository<Subscriber, int>), typeof(SubscribersRepository));
            //services.AddScoped(typeof(IRepository<Region, int>), typeof(RegionsRepository));
        }
    }
}
