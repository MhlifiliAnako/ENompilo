using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nompilo.Areas.Identity.Data;
using Nompilo.Services;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationUserDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationUserDbContextConnection' not found.");

builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddDbContext<ApplicationUserDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationUserDbContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEmailSender, EmailSender>();




var app = builder.Build();

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapRazorPages();

//creating Default Roles
using (var scope = app.Services.CreateScope())
{
    var roleManager =

    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Administration", "Patient", "Nurse", "Doctor", "Pharmacist", "Pharmacy Manager", "Referral Coordinator", "Healthcare Provider", "Therapist" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {

            await roleManager.CreateAsync(new IdentityRole(role));

        }

    }

}


using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Noma";
    string lastName = "Silane";
    string contactNumber = "0785623254";
    string email = "nomalanga@gmail.com";
    string password = "Nomalanga 02";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.contactNumber = contactNumber;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Patient");
    }


}

using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Bridgette";
    string lastName = "Mahlangu";
    string contactNumber = "0865235176";
    string email = "bmahlangu@enompilo.com";
    string password = "BMahlangu01$";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.contactNumber = contactNumber;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Therapist");
    }


}
using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Luzuko";
    string lastName = "Nodumo";
    string contactNumber = "0785452365";
    string email = "luzuko@gmail.com";
    string password = "Luzuko @4";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.contactNumber = contactNumber;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Referral Coordinator");
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Sindi";
    string lastName = "Jele";
    string contactNumber = "0795625799";
    string email = "sindi@gmail.com";
    string password = "Jele 02";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.contactNumber = contactNumber;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Nurse");
    }

}

using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Themba";
    string lastName = "Zulu";
    string contactNumber = "0785452365";
    string email = "themba@gmail.com";
    string password = "Themba 01";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.contactNumber = contactNumber;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Pharmacist");
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Zethu";
    string lastName = "Hadebe";
    string contactNumber = "0785452365";
    string email = "zethu@gmail.com";
    string password = "Zethu 01";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.contactNumber = contactNumber;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Pharmacy Manager");
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Nomvuyo";
    string lastName = "Msibi";
    string contactNumber = "0785452365";
    string email = "nomvuyo@gmail.com";
    string password = "Nomvuyo 01";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.contactNumber = contactNumber;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Doctor");
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Owethu";
    string lastName = "Fakude";
    string contactNumber = "0785452365";
    string email = "Owethu@gmail.com";
    string password = "Owethu 01";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.contactNumber = contactNumber;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Healthcare Provider");
    }


}
using (var scope = app.Services.CreateScope())
{
    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string firstName = "Zonke";
    string lastName = "Manzi";
    string contactNumber = "0785452365";
    string email = "Zonke@gmail.com";
    string password = "Zonke 01";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.firstName = firstName;
        user.lastName = lastName;
        user.contactNumber = contactNumber;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Administration");
    }


}

app.Run();
