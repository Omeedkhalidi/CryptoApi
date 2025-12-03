var builder = WebApplication.CreateBuilder(args);

// Enable controller support (important!)
builder.Services.AddControllers();

var app = builder.Build();

// Show OpenAPI in development mode (optional)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Register all controllers (VERY IMPORTANT)
app.MapControllers();

app.Run();
