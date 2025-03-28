

using LibraryManagement.Application.IService;
using LibraryManagement.Application.Service;
using LibraryManagement.Domain.Interface;
using LibraryManagement.Identity.Model;
using LibraryManagement.Infrastructure.Context;
using LibraryManagement.Infrastructure.Repository;
using LibraryManagement.Infrastucture.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace LibraryManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("LibraryConnString");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString),
                ServiceLifetime.Scoped
                );

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString),
                ServiceLifetime.Scoped
                );

            builder.Services
            .AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();


            builder.Services.AddControllersWithViews();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
