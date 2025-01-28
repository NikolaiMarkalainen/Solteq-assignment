using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Solteq_server.data;
using Solteq_server.services;
using Solteq.server.services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseNpgsql(connectionString).EnableSensitiveDataLogging().LogTo(Console.WriteLine));

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .WithMethods("GET", "POST");
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// services
builder.Services.AddControllers();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AuthService>();


// authorization
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

//apply cors before anything else
app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseRouting();
app.MapControllers();
var dataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data/migrations/csv_files");
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
}
app.Run();
