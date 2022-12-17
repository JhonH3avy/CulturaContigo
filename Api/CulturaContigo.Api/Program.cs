using CulturaContigo.Api;

const string LocalHostCorsPolicy = "AllowLocalHostOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAccessServices();
builder.Services.AddManagerServices();
builder.Services.AddOptionsConfiguration(builder.Configuration);
builder.Services.AddMapper();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: LocalHostCorsPolicy,
        policy =>
        {
            policy.WithHeaders("Content-Type", "Accept");
            policy.WithOrigins("http://localhost:4200", "http://localhost:8100");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(LocalHostCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
