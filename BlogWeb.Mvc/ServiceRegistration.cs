using BlogWeb.Mvc.Abstractions;
using BlogWeb.Mvc.Concretes;
using BlogWeb.Mvc.Data;
using BlogWeb.Mvc.Data.Seeds;
using BlogWeb.Mvc.Entities;
using BlogWeb.Mvc.Helpers;
using BlogWeb.Mvc.Middlewares;
using BlogWeb.Mvc.Options;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogWeb.Mvc
{
    public static class ServiceRegistration
    {
        public static IServiceCollection MVCServiceRegistration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder =>
                    {
                        builder.AllowAnyHeader()
                                       .AllowAnyMethod()
                                       .AllowAnyHeader()
                                       .SetIsOriginAllowed(_ => true)
                                       .AllowCredentials();
                    });
            });

            var sqlServerOptions = services.GetOptions<SqlServerOptions>("SqlServerOptions");

            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(
                    sqlServerOptions.SqlConnection,
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: int.Parse(sqlServerOptions.RetryCount),
                            maxRetryDelay: TimeSpan.FromSeconds(int.Parse(sqlServerOptions.RetryDelay)),
                            errorNumbersToAdd: null);
                    });
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
            }).AddEntityFrameworkStores<BlogDbContext>()
             .AddDefaultTokenProviders();

            services.AddHttpContextAccessor();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUserServive, UserService>();

            var sp = services.BuildServiceProvider();
            BlogDbSeedContext.SeedAsync(sp.GetRequiredService<BlogDbContext>()).GetAwaiter().GetResult();

            services.AddSingleton<NotificationService>();

            return services;
        }

        public static IApplicationBuilder MVCApplicationRegistration(this IApplicationBuilder app)
        {
            app.UseCors("AllowOrigin");

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            return app;
        }
    }
}
