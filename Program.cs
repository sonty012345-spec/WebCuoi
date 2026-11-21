using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Phục vụ thư mục gốc project (chứa images/, audio/, index.html...) qua đường dẫn /WebCuoi/...
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(builder.Environment.ContentRootPath),
    RequestPath = "/WebCuoi"
});

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapGet("/", context =>
{
    context.Response.Redirect("/WebCuoi/index.html");
    return Task.CompletedTask;
});

app.MapRazorPages();
app.Run();