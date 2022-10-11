using SecondHandCarBidProject.ApiService.ApiServices;
using SecondHandCarBidProject.ApiService.HttpConfiguration;
using SercondHandCarBidProject.Logging.MongoContext.Abstract;
using SercondHandCarBidProject.Logging.MongoContext.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddHttpClient<BidApiServices>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration.GetSection("ApiURL").Value);
});
// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddHttpService(builder.Configuration);
var app = builder.Build(); 




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AdminAuthentication}/{action=Login}/{id?}");

app.Run();
