using Domain.Commands.v1.User.Create;
using Domain.Interfaces.v1.User;
using Domain.MapperProfile.v1;
using Infrastructure.Core.Context.v1;
using Infrastructure.Data.Repositories.v1.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var commands = new Assembly[]
{
    typeof(CreateUserCommandHandler).Assembly
};

builder.Services.AddMediatR(commands);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();