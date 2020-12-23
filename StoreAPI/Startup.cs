using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreDB;
using StoreDB.Models;
using StoreDB.Repos;
using StoreLib;

namespace StoreAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string AllowedOrigins = "allowedOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy(name: AllowedOrigins,
                    builder => {
                        builder.WithOrigins("*")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.AddControllers();

            services.AddDbContext<StoreContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("StoreDB")));

/*            services.AddHttpClient();
            //put response caching back in
            services.AddResponseCaching();
            services.AddAuthentication();*/

            //services.AddScoped<DbContext, StoreContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepo, DBRepo>();

            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<ICartItemRepo, DBRepo>();
            
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ILocationRepo, DBRepo>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepo, DBRepo>();
 
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartRepo, DBRepo>();

            services.AddScoped<ILineItemService, LineItemService>();
            services.AddScoped<ILineItemRepo, DBRepo>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepo, DBRepo>();

            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IInventoryItemRepo, DBRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(AllowedOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}