using Microsoft.EntityFrameworkCore;
using TestTask.Application.Services.Implementations;
using TestTask.Data;
using TestTask.Services.Interfaces;

namespace TestTask.WebAPI.Registarations
{
    /// <summary>
    /// Сomponent registration class, DI container
    /// </summary>
    public class TestTaskRegistarations
    {
        public static void RegisterRepositories(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
        }
    }
}
