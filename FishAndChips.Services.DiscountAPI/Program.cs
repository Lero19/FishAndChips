using AutoMapper;
using FishAndChips.Services.CouponAPI;
using FishAndChips.Services.CouponAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//AutoMapping Starts Here
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//AutoMapping Ends Here

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

app.UseAuthorization();

// Mapping controller endpoints
app.MapControllers();

// Applying any pending migrations to the database
ApplyMigration();

// Running the application
app.Run();


// Method to apply pending migrations to the database
void ApplyMigration()
{
    // Creating a scope to obtain a scoped service provider
    using (var scope = app.Services.CreateScope())
    {
        // Getting the ApplicationDbContext service from the service provider
        var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // Checking if there are any pending migrations
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            // Applying any pending migrations to the database
            _db.Database.Migrate();
        }
    }
}

