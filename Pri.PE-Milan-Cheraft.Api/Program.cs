using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pri.PE.Milan_Cheraft.Infrastructure.Data;
using Pri.PE.Milan_Cheraft.Infrastructure.Repositories;
using Pri.PE_Milan_Cheraft.Core.Entities;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Repositories;
using Pri.PE_Milan_Cheraft.Core.Interfaces.Services;
using Pri.PE_Milan_Cheraft.Core.Services.Exercises;
using Pri.PE_Milan_Cheraft.Core.Services.MuscleGroups;
using Pri.PE_Milan_Cheraft.Core.Services.Users;
using Pri.PE_Milan_Cheraft.Core.Services.Workouts;
using System.Security.Claims;
using System.Text;

namespace Pri.PE_Milan_Cheraft.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>
               (options => options
               .UseSqlServer(builder.Configuration.GetConnectionString("DefaultDb")));

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                //ONLY FOR TESTING PURPOSES!!!!
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
                        .AddDefaultTokenProviders();
            //configure jwt bearer token
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidAudience = builder.Configuration["JWTConfiguration:Audience"],
                ValidIssuer = builder.Configuration["JWTConfiguration:Issuer"],
                IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfiguration:SecretKey"]))
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Trainer", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Trainer");
                }
                );
                //userclaim
                options.AddPolicy("Client", policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        if (context.User.HasClaim(ClaimTypes.Role, "Trainer")
                            || context.User.HasClaim(ClaimTypes.Role, "Client"))
                        {
                            return true;
                        }
                        return false;
                    });
                });
            });

            builder.Services.AddCors();
            builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
            builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IMuscleGroupRepository, MuscleGroupRepository>();
            builder.Services.AddScoped<IExerciseService, ExerciseService>();
            builder.Services.AddScoped<IMuscleGroupService, MuscleGroupService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IWorkoutService, WorkoutService>();
            builder.Services.AddScoped<IJwtService, JwtService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Bull.com API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
