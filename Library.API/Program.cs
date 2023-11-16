using System.Text.Json.Serialization;
using Biblioteka.Data;
using Biblioteka.Data.Abstract;
using Biblioteka.Data.Concrete;
using Library.API.Data.Abstract;
using Library.API.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;


var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorBookRepository, AuthorBookRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(
            options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
        );
builder.Services.AddDbContext<LibraryDbContext>(options => {options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));});
builder.Host.UseSerilog();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseWebAssemblyDebugging();
}

app.UseBlazorFrameworkFiles();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("Open");

app.MapControllers();

app.MapFallbackToFile("index.html");


app.Run();

