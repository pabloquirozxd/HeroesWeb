using Microsoft.EntityFrameworkCore;
using HeroesWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<HeroesContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("HeroesDb")
        ?? throw new InvalidOperationException("Falta la cadena de conexión HeroesDb.")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();