using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities.Products.Commands;
using Store.DataAccessLayer.Common;
using Store.DataAccessLayer.Repositories;
using Store.DataAccessLayer.StoreDbContext;
using Store.Entities.BuisnessEntities.User.Entitites;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("LocalDB");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(CreateProductHandler).Assembly));
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(connectionString).AddInterceptors(new AddAuditFeildInterceptor());
});
builder.Services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<StoreContext>().AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IGenericRepository<>) , typeof(GenericRepository<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






var app = builder.Build();

app.UseCors(policy => policy.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());


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
