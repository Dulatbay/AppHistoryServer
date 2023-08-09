using AppHistoryServer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using AppHistoryServer.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using AppHistoryServer.Models;
using AppHistoryServer.Services.Impl;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Repositories.Impl;
using AppHistoryServer.Utils.Initializer;
using AppHistoryServer.Services.BaseInterfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        // Add services to the container.
        builder.Services.AddControllers()
          .AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IQuestionService, QuestionService>();
        builder.Services.AddScoped<IModuleService, ModuleService>();
        builder.Services.AddScoped<ITopicService, TopicService>();
        builder.Services.AddScoped<IQuizService, QuizService>();

        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IVariantRepository, VariantRepository>();
        builder.Services.AddTransient<IModuleRepository, ModuleRepository>();
        builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
        builder.Services.AddTransient<ITopicRepository, TopicRepository>();
        builder.Services.AddTransient<IArchiveBookRepository, ArchiveBookRepository>();
        builder.Services.AddTransient<IQuizRepository, QuizRepository>();

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = "67237047055-cbk8le14k7oj8dcomohkok2u28bss8kg.apps.googleusercontent.com";
                googleOptions.ClientSecret = "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";
            })
            .AddJwtBearer(options =>
            {
                var key = builder.Configuration.GetValue<string>("JWT:Secret");
                if (key == null)
                    throw new ArgumentNullException(nameof(key));

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });


    

        var app = builder.Build();

        app.UseAuthentication();
        app.UseAuthorization();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();



        app.MapControllers();

        app.Run();
    }

}