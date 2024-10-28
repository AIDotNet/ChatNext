using ChatNext.Application.Extensions;
using ChatNext.EntityFrameworkCore.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoGnarly();

builder.Services.AddApplication();

builder.Services.AddHttpContextAccessor();

builder.Services.AddEntityFrameworkCore(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ChatNext"));
});

var app = builder.Build();

app.MapControllers();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();