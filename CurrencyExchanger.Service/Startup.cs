using System;
using CurrencyExchanger.Modules.Api;
using CurrencyExchanger.Modules.Api.Factories;
using CurrencyExchanger.Modules.Repository;
using CurrencyExchanger.Modules.Repository.Factories;
using CurrencyExchanger.Modules.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CurrencyExchanger.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<CurrencyExchangerStorage>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                    mySqlOptions =>
                    {
                        mySqlOptions.EnableRetryOnFailure(15,
                            TimeSpan.FromMilliseconds(2000), null!);
                    }), ServiceLifetime.Transient);
            services.AddTransient(typeof(IHistoryItemContractReconstructionFactory),
                typeof(HistoryItemContractReconstructionFactory));
            services.AddTransient(typeof(IHistoryItemModelMapper), typeof(HistoryItemModelMapper));
            services.AddTransient(typeof(IHistoryItemStorageMapper), typeof(HistoryItemStorageMapper));
            services.AddTransient(typeof(IHistoryItemReconstructionFactory),
                typeof(HistoryItemReconstructionFactory));

            services.AddTransient(typeof(ICurrencyExchangerApi), typeof(CurrencyExchangerApi));
            services.AddTransient(typeof(ICurrencyExchangerRepository), typeof(CurrencyExchangerRepository));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
