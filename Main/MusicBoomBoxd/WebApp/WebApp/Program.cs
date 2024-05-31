using Infrastructure;
using Logic;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<UserManager>();
builder.Services.AddSingleton<ValidateUser>();
builder.Services.AddRazorPages();

// Tells us how we want to use auth.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.LoginPath = new PathString("/Index");
        options.AccessDeniedPath = new PathString("/Error");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//this tells us that we want to use auth.
app.UseAuthentication();
app.UseAuthorization();
            
app.MapRazorPages();

app.Run();
        