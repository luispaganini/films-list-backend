using FilmsList.Infra.IoC;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);
//builder.Services.AddInfrastructureInMemory(builder.Configuration);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FilmsList.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Luis Fernando",
            Email = "luisfernando_paganini@hotmail.com",
            Url = new Uri("https://www.linkedin.com/in/luis-fernando-paganini-68763b1a9/")
        }
    });
    var xmlFile = "FilmsList.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);

});

//Logs
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    Serilog.Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.MSSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],
            sinkOptions: new MSSqlServerSinkOptions()
            {
                AutoCreateSqlTable = true,
                TableName = "Logs"
            })
        .WriteTo.Console()
        .CreateLogger();
}).UseSerilog();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseExceptionHandler("/error");

//Error Treatment
app.Map("/error", (HttpContext http) =>
{
    return Results.Problem(title: "Internal Server Error", statusCode: 500);
});

app.Run();
