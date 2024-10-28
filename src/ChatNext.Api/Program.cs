using System.Text;
using ChatNext.Api.Apis;
using ChatNext.Application.Extensions;
using ChatNext.EntityFrameworkCore.EntityFrameworkCore;
using ChatNext.EntityFrameworkCore.EntityFrameworkCore.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "ChatNext.Api", Version = "v1" });

    // 添加Bearer 
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization : Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
                Description = "Bearer token",
                BearerFormat = "JWT",
                Scheme = "Bearer",
            },
            new string[] { }
        }
    });

    var files = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");

    foreach (var item in files)
    {
        options.IncludeXmlComments(item);
    }
}));

builder.Services.AddAuthentication(options => { options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "ChatNext",
            ValidAudience = "ChatNext",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"] ??
                                                                               throw new ArgumentException(
                                                                                   "Jwt:Secret is null"))),
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddAutoGnarly();

builder.Services.AddApplication();

builder.Services.AddHttpContextAccessor();

builder.Services.AddEntityFrameworkCore(options =>
{
    // 创建data目录
    var dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data");
    if (!Directory.Exists(dataPath))
    {
        Directory.CreateDirectory(dataPath);
    }

    options.UseSqlite(builder.Configuration.GetConnectionString("ChatNext"));
});

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapAuthApis();
app.MapUserApis();

app.Run();