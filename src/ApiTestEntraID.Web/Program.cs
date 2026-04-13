using ApiTestEntraID.Infrastructure;
using ApiTestEntraID.Web.Authorization;
using ApiTestEntraID.Web.Constants;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, RedirectToHomeAuthorizationMiddlewareResultHandler>();

builder.Services.AddControllersWithViews();

builder.Services
    .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddInfrastructure();

builder.Services.AddAuthorization(options =>
{
    // General area access
    options.AddPolicy(AppPolicies.DocsGeneral, p =>
        p.RequireRole(AppRoles.DocUser, AppRoles.DocManager, AppRoles.SupportUser, AppRoles.SupportManager, AppRoles.Admin));
    options.AddPolicy(AppPolicies.HRGeneral, p =>
        p.RequireRole(AppRoles.HrUser, AppRoles.HrManager, AppRoles.SupportUser, AppRoles.SupportManager, AppRoles.Admin));
    options.AddPolicy(AppPolicies.ITGeneral, p =>
        p.RequireRole(AppRoles.SupportUser, AppRoles.SupportManager, AppRoles.Admin));

    // Tasks action
    options.AddPolicy(AppPolicies.DocsTasks, p =>
        p.RequireRole(AppRoles.DocUser, AppRoles.DocManager, AppRoles.SupportUser, AppRoles.SupportManager, AppRoles.Admin));
    options.AddPolicy(AppPolicies.HRTasks, p =>
        p.RequireRole(AppRoles.HrUser, AppRoles.HrManager, AppRoles.SupportUser, AppRoles.SupportManager, AppRoles.Admin));
    options.AddPolicy(AppPolicies.ITTasks, p =>
        p.RequireRole(AppRoles.SupportUser, AppRoles.SupportManager, AppRoles.Admin));

    // Report action
    options.AddPolicy(AppPolicies.DocsReport, p =>
        p.RequireRole(AppRoles.DocManager, AppRoles.SupportManager, AppRoles.Admin));
    options.AddPolicy(AppPolicies.HRReport, p =>
        p.RequireRole(AppRoles.HrManager, AppRoles.SupportManager, AppRoles.Admin));
    options.AddPolicy(AppPolicies.ITReport, p =>
        p.RequireRole(AppRoles.SupportManager, AppRoles.Admin));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Index");
    app.UseHsts();
}

app.UseStatusCodePagesWithRedirects("/Home/Index");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();