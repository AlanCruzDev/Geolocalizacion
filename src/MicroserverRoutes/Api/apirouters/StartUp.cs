using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using apirouters.Core.IConfiguration;
using apirouters.Data;
using apirouters.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace apipackages;

public class StartUp
{

  public StartUp(IConfiguration configuration)
  {
    // PARA LIMPIAR CAMPOS
    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
    Configuration = configuration;
  }
  public IConfiguration Configuration { get; }


  public void ConfigureServices(IServiceCollection services)
  {
    services.AddControllers().AddJsonOptions(x =>
                 x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles).AddNewtonsoftJson();

    string conection2 = "Server=host.docker.internal,1433;Database=DbRoutes;User=sa;Password=Alancruz1998.;MultipleActiveResultSets=True;";

    // cadaena de conexion
    services.AddDbContext<ApplicationDbContext>(options =>
    {

      Console.WriteLine("Server is  " + conection2);

      options.UseSqlServer(conection2);
    });

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type= ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

    // Estamos configuracion la autenticacion
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(opciones => opciones.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = false,
          ValidateAudience = false,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Configuration["llavejwt"])),
          ClockSkew = TimeSpan.Zero
        });

    // activamos el servicio de proteccion de datos
    services.AddDataProtection();

    // configuracion del mapeo automatico
    services.AddAutoMapper(typeof(StartUp));

    // API URLS
    services.Configure<ApiUrls>(opts => Configuration.GetSection("ApiUrls").Bind(opts));

    // Proxies
    services.AddHttpClient<IRoutesProxy,RoutesProxy>();

    ServicePointManager.ServerCertificateValidationCallback = delegate {return true;};


    // configuando cors
    services.AddCors(opciones =>
    {
        opciones.AddPolicy("ClientPermission",policy =>{
          policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:4200")
            .AllowCredentials();
        });
    });
    // configuracion de sigler
   services.AddSignalR(options =>{
     options.KeepAliveInterval = TimeSpan.FromMinutes(1);
   });

    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;


    services.AddScoped<IUnitOfWork, UnitOfWork>();
  }

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      //app.UseHttpsRedirection();
    }
    app.UseRouting();
    app.UseCors("ClientPermission");
    app.UseAuthorization();
    app.UseEndpoints(endopoints =>
    {
      endopoints.MapControllers();
      endopoints.MapHub<RealTime>("/src/MicroserverRoutes/Api/apirouters/Services/RealTime");
    });
  }
}