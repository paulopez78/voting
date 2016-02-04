using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;

using voting.api.model;

namespace voting.api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddJsonFormatters();
            services.AddEntityFramework()
                    .AddInMemoryDatabase() 
                    .AddDbContext<VotingContext>(options =>
                            options.UseInMemoryDatabase()); ;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            SampleData.Initialize(app.ApplicationServices);
        }

        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}
