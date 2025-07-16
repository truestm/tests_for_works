using BiogenomAPI.Models.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BiogenomAPI
{
    public class Program
    {
        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IUsersService, UsersService>();
            builder.Services.AddScoped<IQuestionnairesService, QuestionnairesService>();
            builder.Services.AddScoped<IAnalysisService, AnalysisService>();
        }

        private static void ConfigureControllers(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
        }

        private static void InitializeDb(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                context.Database.EnsureCreated();

                var predefines = Path.Combine(AppContext.BaseDirectory, "Predefines");

                context.Nutrients.ImportJson(Path.Combine(predefines, "Nutrients.json"));
                context.Products.ImportJson(Path.Combine(predefines, "Products.json"));
                context.ProductNutrients.ImportJson(Path.Combine(predefines, "ProductNutrients.json"));
                context.NutritionalNorms.ImportJson(Path.Combine(predefines, "NutritionalNorms.json"));

                context.SaveChanges();
            }
        }

        private static void InitializeHttp(WebApplication app)
        {
            app.UseAuthorization();
        }

        private static void Initialize(WebApplication app)
        {
            InitializeDb(app);
            InitializeHttp(app);
            
            app.MapControllers();
        }

        private static WebApplication BuildApp(WebApplicationBuilder builder)
        {
            ConfigureServices(builder);
            ConfigureControllers(builder);
            
            return builder.Build();
        }

        public static void Main(string[] args)
        {
            var app = BuildApp(WebApplication.CreateBuilder(args));
            Initialize(app);
            app.Run();
        }
    }
}
