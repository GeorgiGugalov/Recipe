using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe.WinFormsApp.Data;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Add DbContext
        services.AddDbContext<RecipeContext>(options =>
            options.UseSqlServer("Server=DESKTOP-3IMUUA7;Database=Recipes;Integrated Security=True;TrustServerCertificate=True"));
    }
}