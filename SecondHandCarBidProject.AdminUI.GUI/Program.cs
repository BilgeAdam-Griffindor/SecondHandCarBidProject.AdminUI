using SecondHandCarBidProject.AdminUI.GUI.ApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

//builder.Services.AddHttpClient<BaseServices>(opt =>
//{
//    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
//});

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
