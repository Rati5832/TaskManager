using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Middleware;
using TaskManager.Application;
using TaskManager.Application.Common.Behaviours;
using TaskManager.Application.Common.Interfaces;
using TaskManager.Application.Common.Mappings;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("TaskManagerDb");
});

builder.Services.AddMediatR(typeof(ApplicationAssemblyMarker).Assembly);

builder.Services.AddAutoMapper(
    config => { },
    typeof(TaskMappingProfile).Assembly);

builder.Services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyMarker).Assembly);
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>)
);
builder.Services.AddTransient<ValidationExceptionMiddleware>();

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseAuthorization();

await app.RunAsync();