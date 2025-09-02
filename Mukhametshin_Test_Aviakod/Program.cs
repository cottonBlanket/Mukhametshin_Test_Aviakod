using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mukhametshin_Test_Aviakod.DataAccess;
using Mukhametshin_Test_Aviakod.Domain.Repositories;
using Mukhametshin_Test_Aviakod.Domain.Repositories.Interfaces;
using Mukhametshin_Test_Aviakod.Middlewares;
using Mukhametshin_Test_Aviakod.Options;
using Mukhametshin_Test_Aviakod.Services.Auth;
using Mukhametshin_Test_Aviakod.Services.Auth.Interfaces;
using Mukhametshin_Test_Aviakod.UseCases.Infrastructure;
using Mukhametshin_Test_Aviakod.UseCases.Issues.Commands.CreateIssue;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
    c.AutoRegisterRequestProcessors = true;
});
builder.Services.AddValidatorsFromAssemblyContaining<CreateIssueCommandValidator>();
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationPipelineBehavior<,>)
);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IIssueRepository, IssueRepository>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();


builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))); 

var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>()!;
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt.Issuer,
            ValidAudience = jwt.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key))
        };
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();

    db.Database.SetCommandTimeout(TimeSpan.FromMinutes(5));
    await db.Database.MigrateAsync();
}

app.Run();