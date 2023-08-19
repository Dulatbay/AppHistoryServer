using AppHistoryServer;
using AppHistoryServer.Models;
using AppHistoryServer.Repositories.Impl;
using AppHistoryServer.Repositories.Interfaces;
using AppHistoryServer.Services.Impl;
using AppHistoryServer.Services.Interfaces;
using AppHistoryServer.Utils.Initializer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
        {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        
        builder.Services.AddCors(options =>
        {

            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        // Add services to the container.
        builder.Services.AddControllers()
          .AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IQuestionService, QuestionService>();
        builder.Services.AddScoped<IModuleService, ModuleService>();
        builder.Services.AddScoped<ITopicService, TopicService>();
        builder.Services.AddScoped<IQuizService, QuizService>();
        builder.Services.AddScoped<IFileService, FileService>();

        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IPassedUserQuestionsRepository, PassedUserQuestionsRepository>();
        builder.Services.AddTransient<IPassedUserQuizzesRepository, PassedUserQuizzesRepository>();
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

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            ModuleInitializer.InitModules(dbContext);
            QuestionInitializer.InitQuestions(dbContext);
            //QuizInitializer.Init(dbContext);
            //UserInitializer.Initialize(dbContext);
        }

        app.UseAuthentication();
        app.UseAuthorization();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();

        //    app.UseSwaggerUI();
        //}

        app.UseHttpsRedirection();
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
              Path.Combine(Directory.GetCurrentDirectory(), "Static")),
            RequestPath = "/api/static",
            DefaultContentType = "image",
        });

        app.UseCors();


        app.MapControllers();

        app.Run();
    }

}