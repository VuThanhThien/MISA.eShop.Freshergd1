using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MISA.eSHOP.Common.Enum;
using MISA.eSHOP.Common.Model;
using MISA.eSHOP.DataLayer;
using MISA.eSHOP.DataLayer.Context;
using MISA.eSHOP.DataLayer.EntityDL;
using MISA.eSHOP.DataLayer.Interface;
using MISA.eSHOP.Service;
using MISA.eSHOP.Service.Entity;
using MISA.eSHOP.Service.Interface;

namespace MISA.eSHOP.API
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
            

            services.AddControllers().AddNewtonsoftJson(); ;

            //sửa lỗi cors
            services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.eSHOP.API", Version = "v1" });
            });

            //Gọi các interface ở đây
            //base
            services.AddScoped(typeof(IBaseDL<>), typeof(BaseDLQuery<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IDbContext<>), typeof(OnlineDbContext<>));

            //Datalayer
            services.AddScoped<IRestaurantDL, RestaurantDL>();
            services.AddScoped<INationDL, NationDL>();
            services.AddScoped<ICityDL, CityDL>();
            services.AddScoped<IDistrictDL, DistrictDL>();
            services.AddScoped<ICommuneDL, CommuneDL>();
            services.AddScoped<IStreetDL, StreetDL>();

            //Service
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<INationService, NationService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<ICommuneService, CommuneService>();
            services.AddScoped<IStreetService, StreetService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.eSHOP.API v1"));
            }

            app.UseHttpsRedirection();

            //Sửa lỗi cors
            app.UseRouting();
            app.UseCors("AllowOrigin");
            app.UseAuthorization();

            // xử lý exception chung
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                var errorMsg = new Error();
                errorMsg.DevMsg = exception.Message;
                errorMsg.UserMsg = UserMsgEnum.DefaultUserMsg;
                await context.Response.WriteAsJsonAsync(errorMsg);
                //await context.Response.WriteAsJsonAsync(new { error = exception.Message });
            }));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
