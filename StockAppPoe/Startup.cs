/* Group:      8
   References: Liu, F (2021) Full C# Project: Supermarket Management System | ASP.NET Core Blazor, EF Core, SQL Server, Identity source code (Version 16) [Source code]. https://www.youtube.com/watch?v=DWrH7br4DsM&t=140s

 */

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using NightingaleWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases;
using UseCases.DataStorePluginInterfaces;

namespace NightingaleWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            services.AddDbContext<MarketContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
                options.AddPolicy("CashierOnly", p => p.RequireClaim("Position", "Cashier"));
            });

            /*//Dependency Injection for In-Memory Data Store
            services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
            services.AddScoped<IProductRepository, ProductInMemoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionInMemoryRepository>();
            services.AddScoped<IVehicleRepository, VehicleInMemoryRepository>();
            services.AddScoped<IStockRepository, StockInMemoryRepository>();*/


            //Dependency Injection for Entity Framework Core Data Store for SQL
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IStockRepository, StockRepository>();

            //Dependency Injection for Use Cases and Repositories
            services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
            services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
            services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
            services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
            services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
            services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
            services.AddTransient<IAddProductUseCase, AddProductUseCase>();
            services.AddTransient<IEditProductUseCase, EditProductUseCase>();
            services.AddTransient<IGetProductByIdUseCase, GetProductByIdUseCase>();
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddTransient<IViewProductsByCategoryId, ViewProductsByCategoryId>();
            services.AddTransient<ISellProductUseCase, SellProductUseCase>();
            services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
            services.AddTransient<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>();
            services.AddTransient<IGetTransactionsUseCase, GetTransactionsUseCase>();
            
            // Vehicles Use Cases
            services.AddTransient<IViewVehiclesUseCase, ViewVehiclesUseCase>();
            services.AddTransient<IAddVehicleUseCase, AddVehicleUseCase>();
            services.AddTransient<IEditVehicleUseCase, EditVehicleUseCase>();
            services.AddTransient<IGetVehicleByIdUseCase, GetVehicleByIdUseCase>();
            services.AddTransient<IDeleteVehicleUseCase, DeleteVehicleUseCase>();

            // Stocks Use Cases
            services.AddTransient<IViewStocksUseCase, ViewStocksUseCase>();
            services.AddTransient<IAddStockUseCase, AddStockUseCase>();
            services.AddTransient<IEditStockUseCase, EditStockUseCase>();
            services.AddTransient<IGetStockByIdUseCase, GetStockByIdUseCase>();
            services.AddTransient<IDeleteStockUseCase, DeleteStockUseCase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
