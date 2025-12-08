var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger ALWAYS (also in Docker/Production)
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

// Test endpoint
app.MapGet("/encryption", () => "API is updated!");

app.Run();
// CI/CD test