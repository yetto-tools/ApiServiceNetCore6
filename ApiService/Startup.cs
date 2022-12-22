using Microsoft.Extensions.DependencyInjection.Extensions;
using ApiService.Domain.AppContext;
using ApiService.Domain.Services.Actions;
using Microsoft.OpenApi.Models;

namespace ApiService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.TryAddSingleton<TesoreriaContext>();
            services.AddAutoMapper(typeof(Startup));
            services.TryAddScoped<IUserServiceAction, UserServiceAction>();
            

            services.AddControllers(options =>
            {
                options.Conventions.Add(new SwaggerByGroupVersion());
            });

            //services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
            //services.AddAuthorization(options => {
            //    options.FallbackPolicy = options.DefaultPolicy;
            //});

            services.AddCors();

            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiService", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "ApiService", Version = "v2" });
                //c.AddSecurityDefinition("Service", new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "UserDto",
                //    In = ParameterLocation.Header
                //});
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthorization();
            //app.UseAuthentication();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwagger();

            // This middleware serves the Swagger documentation UI
            app.UseSwaggerUI(c =>
            {
                { 
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Service V1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "API Service V2");
                }
            });
        }

    }
}
