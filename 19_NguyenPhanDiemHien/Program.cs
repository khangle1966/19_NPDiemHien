using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using _19_NguyenPhanDiemHien.Appdata; // Đảm bảo namespace chính xác

var builder = WebApplication.CreateBuilder(args);

// Cấu hình chuỗi kết nối cho AppDBContext
var connectionString = builder.Configuration.GetConnectionString("AppConnection")
	?? throw new InvalidOperationException("Connection string 'AppConnection' not found.");

// Đăng ký AppDBContext với DI container
builder.Services.AddDbContext<AppDBContext>(options =>
	options.UseSqlServer(connectionString));

// Cấu hình Identity với AppDBContext
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
	options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<AppDBContext>();

// Thêm các dịch vụ vào container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình pipeline HTTP
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Đảm bảo authentication được bật
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Đảm bảo Razor Pages được ánh xạ

app.Run();
