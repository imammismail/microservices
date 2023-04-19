using Microsoft.EntityFrameworkCore;
using OrderServices.Data;
using OrderServices.SyncDataServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// service automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// service interface product repo
builder.Services.AddScoped<IOrderRepo, OrderRepo>();

// seed db service
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddHttpClient<IProductDataClient, HttpProductDataClient>();
builder.Services.AddHttpClient<IWalletDataClient, HttpWalletDataClient>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IWalletRepo, WalletRepo>();

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

//jalankan seedaing data
PrepDb.PrepPopulation(app);

app.Run();
