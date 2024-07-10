using Microsoft.EntityFrameworkCore;
using Project_Cecilious.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CeciliousContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CeciliousContext") 
    ?? throw new InvalidOperationException("Connection string 'CeciliousContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<CeciliousContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapGet("/", async context =>
{
    context.Response.Redirect("/Views/Dishes/Index");
});
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
