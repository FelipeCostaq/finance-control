using DotNetEnv;
using finance.Api.Data;
using finance.Api.Handlers;
using finance.Core.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

builder.Services.AddDbContext<AppDbContext>
(
    x => x.UseSqlServer(connectionString)
);

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

