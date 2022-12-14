using IES.Interfaces.Repositories;
using IES.Interfaces.Services;
using IES.Services;
using IES.Repositories;

namespace IES.WebHost
{
    public static class InjectionContainer
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IUsersService), typeof(UsersService));
            services.AddScoped(typeof(ILessonsService), typeof(LessonsService));
            services.AddScoped(typeof(ITestsService), typeof(TestsService));
            services.AddScoped(typeof(IQuestionsService), typeof(QuestionsService));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IUsersRepository), typeof(UsersRepository));
            services.AddScoped(typeof(ILessonsRepository), typeof(LessonsRepository));
            services.AddScoped(typeof(IChaptersRepository), typeof(ChaptersRepository));
            services.AddScoped(typeof(ITestsRepository), typeof(TestsRepository));
            services.AddScoped(typeof(IQuestionsRepository), typeof(QuestionsRepository));



        }
    }
}
