global using bootcamper_helpdesk.Models;
global using bootcamper_helpdesk.Services.ResponseService;
global using bootcamper_helpdesk.Services.UserService;
global using bootcamper_helpdesk.Services.SurveyQuestionService;
global using bootcamper_helpdesk.Dtos.User;
global using bootcamper_helpdesk.Dtos.Response;
global using bootcamper_helpdesk.Dtos.SurveyQuestion;
global using bootcamper_helpdesk.Data;
global using AutoMapper;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IResponseService, ResponseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISurveyQuestionService, SurveyQuestionService>();
// Register db context
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
));
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
