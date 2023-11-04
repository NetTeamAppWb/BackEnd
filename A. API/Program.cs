using A._API.Mapper;
using Data;
using Data.DBContext;
using Data.Model;
using Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//inyeccion
builder.Services.AddScoped<IRestaurantDomain, RestaurantDomain>();
builder.Services.AddScoped<IRestaurantData, RestaurantMySQLData>();

//Conextion MySQL
var connectionString = builder.Configuration.GetConnectionString("EmprendeChefDB");



builder.Services.AddDbContext<EmprendeChefBDContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

builder.Services.AddAutoMapper(
    typeof(ModelToAPI),
    typeof(RequestToAPI)
);

var app = builder.Build();


using (var scope=app.Services.CreateScope())
    using (var context=scope.ServiceProvider.GetService<EmprendeChefBDContext>())
    {
        context.Database.EnsureCreated();
    }

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