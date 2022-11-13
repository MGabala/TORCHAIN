using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using TORCHAIN.Repositories;

var builder = WebApplication.CreateBuilder(args);

//My services

builder.Services.AddDbContextFactory<MainDatabase>(db_config => db_config.UseSqlite(builder.Configuration["ConnectionStrings:DB"]));
builder.Services.AddScoped<IForumRepository,ForumRepository>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
