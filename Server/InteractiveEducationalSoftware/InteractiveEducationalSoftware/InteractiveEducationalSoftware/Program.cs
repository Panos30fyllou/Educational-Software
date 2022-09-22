using IES.Interfaces;
using IES.WebHost;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IDbConfig>(db => new DbConfig { ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") });

InjectionContainer.InjectRepositories(builder.Services);
InjectionContainer.InjectServices(builder.Services);
builder.Services.AddCors(options => { options.AddDefaultPolicy(builder => { builder.AllowAnyOrigin(); builder.AllowAnyMethod(); builder.AllowAnyHeader(); }); });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
