namespace EFCoreEncapsulation.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container

        builder.Services.AddScoped(_ => new SchoolContext(
            builder.Configuration.GetConnectionString("ConnectionString"),
            builder.Environment.IsDevelopment()
        ));

        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline

        app.MapControllers();

        app.Run();
    }
}
