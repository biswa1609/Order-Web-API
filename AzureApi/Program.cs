using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using AzureApi.Interface;
using AzureApi.RepositoryEF;
using AzureApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

string ClientId = "0f235aae-1f36-4a6c-9d61-04a4173630c0";
string ClientSecret = "TQT8Q~pQxf9DgkiRM6IN5BxmRYgJfkVLPSI3WdmA";
string TanentId = "2206a67a-1c0a-4fd4-ae8d-c1b11d2cef06";

ClientSecretCredential clientSecret = new ClientSecretCredential(TanentId, ClientId, ClientSecret);
string keyurl = "https://keyvalut100.vault.azure.net/";

SecretClient secretClient = new SecretClient(new Uri(keyurl), clientSecret);
var secret = secretClient.GetSecret("ConnectionString");
var connctionString = secret.Value.Value;

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyDatabaseDbContext>(option => option.UseSqlServer(connctionString));
builder.Services.AddScoped<IMyDatabaseDbContext>(provider => provider.GetRequiredService<MyDatabaseDbContext>());
builder.Services.AddScoped<IOrderService, OrderService>();
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

app.MapControllers();

app.Run();
