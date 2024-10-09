﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PizzaOrderApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Додаємо підтримку контролерів з видом
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Налаштовуємо маршрути
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Order}/{action=Register}/{id?}");
            });
        }
    }
}
