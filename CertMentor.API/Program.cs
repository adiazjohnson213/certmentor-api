using CertMentor.Application.Interfaces.Catalog;
using CertMentor.Application.Interfaces.Exam;
using CertMentor.Infrastructure.ExternalServices.MicrosoftLearn.Clients;
using CertMentor.Infrastructure.Persistence;
using CertMentor.Infrastructure.Repositories.Catalog;
using CertMentor.Infrastructure.Repositories.Exam;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CertMentorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<IMicrosoftLearnClient, MicrosoftLearnClient>(client =>
{
    client.BaseAddress = new Uri("https://learn.microsoft.com/api/catalog/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// TODO: Register services when implemented
// builder.Services.AddScoped<ICatalogService, CatalogService>();
// builder.Services.AddScoped<IExamService, ExamService>();

builder.Services.AddScoped<ICertificationRepository, CertificationRepository>();
builder.Services.AddScoped<ISkillAreaRepository, SkillAreaRepository>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<IExamSessionRepository, ExamSessionRepository>();
builder.Services.AddScoped<IPerformanceRecordRepository, PerformanceRecordRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
