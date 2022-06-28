using apitruck;

var build = WebApplication.CreateBuilder(args);
var startup = new StartUp(build.Configuration);
startup.ConfigureServices(build.Services);

var app = build.Build();
startup.Configure(app,app.Environment);
app.Run();






