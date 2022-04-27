using Code420.SfBlazorPlus.Code.CssUtilities;
using Code420.SfBlazorPlus.Code.Models.Orchestrator;
using Code420.SfBlazorPlus.Code.Models.Theme;
using Code420.SfBlazorPlus.Data;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. --- OOB Dependencies
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


// Add SyncFusion
builder.Services.AddSyncfusionBlazor();


// Our Dependencies
builder.Services.AddTransient<ICssUtilities, CssUtilities>();
builder.Services.AddScoped<IOrchestratorParameters, OrchestratorParameters>();
builder.Services.AddScoped<IThemeManager, ThemeManager>();



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
