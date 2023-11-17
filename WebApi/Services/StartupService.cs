using WebApi.Models;

namespace WebApi.Services
{
    public class StartupService : IStartupService
    {
        public Startup Get(Startup startup)
        {
            Startup startup1 = MongoDBService.GetAsync();
        }
    }
}
