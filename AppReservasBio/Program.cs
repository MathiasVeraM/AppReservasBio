using AppReservasBio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configura tu contexto de base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agrega autenticación por cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Cuenta/Login";   // Página para iniciar sesión
        options.LogoutPath = "/Cuenta/Logout"; // Página para cerrar sesión
        options.AccessDeniedPath = "/Cuenta/AccessDenied"; // Opcional
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// Agrega autenticación y autorización en el pipeline
app.UseAuthentication();  // Muy importante que vaya antes de UseAuthorization
app.UseAuthorization();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            context.Response.Redirect("/Reservas/Listado");
            return;
        }
    }

    await next();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Reservas}/{action=Calendario}/{id?}");

app.Run();
