using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.Services;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IRacersService, RacersService>();
builder.Services.AddScoped<ITrackRacesService, TrackRacesService>();


var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.Run();