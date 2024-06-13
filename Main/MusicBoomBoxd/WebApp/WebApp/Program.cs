using Infrastructure;
using Logic;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<UserManager>();
builder.Services.AddSingleton<IProfileRepository, ProfileRepository>();
builder.Services.AddSingleton<ISongRepository, SongRepository>();
builder.Services.AddSingleton<SongManager>();
builder.Services.AddSingleton<IArtistRepository, ArtistRepository>();
builder.Services.AddSingleton<ArtistManager>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IValidateUser, ValidateUser>();
builder.Services.AddSingleton<IReviewRepository, ReviewRepository>();
builder.Services.AddSingleton<IValidateAlbum, ValidateAlbum>();
builder.Services.AddSingleton<IValidateSong, ValidateSong>();
builder.Services.AddSingleton<IAlbumRepository, AlbumRepository>();
builder.Services.AddSingleton<AlbumManager>();
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(7);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

app.UseSession();

//this tells us that we want to use auth.
app.UseAuthentication();
app.UseAuthorization();
            
app.MapRazorPages();

app.Run();
        