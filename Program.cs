using Microsoft.EntityFrameworkCore;
using FavoriteSongs.Models;

var builder = WebApplication.CreateBuilder(args);

// ���������� ��������� ���� ������ � �������������� ������ �����������
builder.Services.AddDbContext<MusicContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));


// ���������� MVC ���������
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ��������� ������������� � ��������� ������
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
