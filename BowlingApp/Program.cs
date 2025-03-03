using BowlingApp.Core;
using BowlingApp.Factories;
using BowlingApp.Repository;
using BowlingApp.Repository.Repositories;
using BowlingApp.Services;
using BowlingApp.Utilities;
using Microsoft.Extensions.DependencyInjection;


//Set up DI container
var services = new ServiceCollection()
    .AddScoped<AppDbContext>()
    .AddScoped<GameFacade>()
    .AddScoped<UserRepository>()
    .AddScoped<MenuHandler>()
    .AddScoped<GameFactory>()
    .AddScoped<BowlingGame>()
    .AddScoped<EventSystem>()
    .AddSingleton<UserInputHandler>()
    .AddSingleton<SingletonLogger>()
    .BuildServiceProvider();

var gameFacade = services.GetRequiredService<GameFacade>();
gameFacade.StartGame();