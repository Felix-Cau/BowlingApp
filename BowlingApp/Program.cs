using BowlingApp.Repository;
using BowlingApp.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//Getting Configuration to check for appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
    
//Getting the connectionstring
string connectionString = configuration.GetConnectionString("DefaultConnection");

//Setting upp DI
var services = new ServiceCollection()
.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString))
.AddScoped<UserRepository>()
.BuildServiceProvider();
