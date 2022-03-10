using Registry.Api.Billing.Integratiion;
using Registry.Api.Billing.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "google_auth_credentials.json");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions();

builder.Services.Configure<GCSettings>(configuration.GetSection(nameof(GCSettings)));
builder.Services.AddScoped<IBillingService, BillingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
