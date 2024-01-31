using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KountaApp.Areas.Identity.Data;
using KountaApp.Sender_Services;
using KountaApp.Sender_Settings;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("KountaDbContextConnection") ?? throw new InvalidOperationException("Connection string 'KountaDbContextConnection' not found.");

builder.Services.AddDbContext<KountaDbContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<KountaDbContext>();

// manually add SignIn Manager
builder.Services.TryAddScoped<SignInManager<ApplicationUser>>();
builder.Services.TryAddScoped<UserManager<ApplicationUser>>();


builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;

});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(30); // Set the desired expiration time for the cookie
    options.SlidingExpiration = true;
  
});

builder.Services.Configure<SendGridSettings>(builder.Configuration.GetSection("SendGridSettings"));

builder.Services.AddSendGrid(options =>
{
    options.ApiKey = builder.Configuration.GetSection("SendGridSettings").GetValue<string>("ApiKey");
});


builder.Services.AddScoped<IEmailSender, EmailSenderService>();

// Googgle AUTH
builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration.GetSection("GoogleAuthSettings").GetValue<string>("ClientId");
    googleOptions.ClientSecret = builder.Configuration.GetSection("GoogleAuthSettings").GetValue<string>("ClientSecret");

});









// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;


app.UseAuthorization();

app.MapRazorPages();

app.Run();
