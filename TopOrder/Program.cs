using SocialNetworkAnalyser.ExceptionHandler;
using TopOrder.DAL;
using TopOrder.Repositories;
using TopOrder.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TopOrderContext>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddExceptionHandler<ExceptionHandler>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<TopOrderContext>();
    dataContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
