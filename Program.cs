using CelilCavus.RepositoryDesiginPattern.Data.Context;
using CelilCavus.RepositoryDesiginPattern.Data.Interfaces;
using CelilCavus.RepositoryDesiginPattern.Data.Repository;
using CelilCavus.RepositoryDesiginPattern.Data.UnitOfWork;
using CelilCavus.RepositoryDesiginPattern.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<BankContext>(opt =>
        {
            opt.UseSqlServer("Server=.;Database=AspEFCore_RepPattern;Trusted_Connection=True;TrustServerCertificate=True;");
        });
        // builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
        // builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        // builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IUserMapper, UserMapper>();
        builder.Services.AddScoped<IAccountMapper, AccountMapper>();

        var app = builder.Build();
        
        app.UseStaticFiles();
        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
            RequestPath = "/node_modules"
        });
        app.MapDefaultControllerRoute();

        app.Run();
    }
}