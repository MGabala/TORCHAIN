using Blazored.Modal;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.RichTextEdit;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.ResponseCompression;

using TORCHAIN.Hubs;
using TORCHAIN.Repositories;

var builder = WebApplication.CreateBuilder(args);

//My services

builder.Services.AddDbContextFactory<MainDatabase>(db_config => db_config.UseSqlite(builder.Configuration["ConnectionStrings:DB"]));
builder.Services.AddScoped<IForumRepository,ForumRepository>();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredModal();
builder.Services
	.AddBlazorise(options =>
	{
		options.Immediate = true;
	})
	.AddBootstrapProviders()
	.AddFontAwesomeIcons();

var app = builder.Build();

app.UseResponseCompression();
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
app.MapHub<ChatHub>("/chathub");
app.MapFallbackToPage("/_Host");

app.Run();
