using SecondHandCarBidProject.ApiService.ApiServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<BidApiServices>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["ApiURL"]);
});
// Add services to the container.
builder.Services.AddRazorPages();

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
