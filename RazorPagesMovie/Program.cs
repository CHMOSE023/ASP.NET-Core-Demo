using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 1.1 添加 Razor Pages 支持
builder.Services.AddRazorPages();

// 2.1 添加数据库链接字符串
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? 
    throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

var app = builder.Build();

// 4.1 添加种子初始值设定项
using (var scope = app.Services.CreateScope()) //  using 语句将确保释放上下文
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //  1.2.1 将异常终结点设置为 /Error
    app.UseExceptionHandler("/Error");
    //  1.2.2 HTTP 严格传输安全协议 (HSTS)
    app.UseHsts();
}

// 1.3.1 将 HTTP 请求重定向到 HTTPS
app.UseHttpsRedirection();

// 1.3.2 使能够提供 HTML、CSS、映像和 JavaScript 等静态文件。
app.UseStaticFiles();

// 1.3.3 向中间件管道添加路由匹配。
app.UseRouting();

// 1.3.3 授权用户访问安全资源。 此应用不使用授权，因此可删除此行。
app.UseAuthorization();

// 1.3.3 为 Razor Pages 配置终结点路由。
app.MapRazorPages();

// 1.3.3 运行应用。
app.Run();
