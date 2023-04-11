public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // services.AddRazorPages();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });
    }

        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCors();
        app.UseStaticFiles();
        app.UseRouting();

        app.MapControllers();
        // app.UseEndpoints(endpoints =>
        // {
        //     endpoints.MapRazorPages();
        // });
    }
}