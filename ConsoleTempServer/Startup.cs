using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.IO;

[assembly: OwinStartup(typeof(ConsoleTempServer.Startup))]
namespace ConsoleTempServer
{
    class Startup
    {
        static Random rnd = new Random((int)DateTime.Now.Ticks);

        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage(new Microsoft.Owin.Diagnostics.WelcomePageOptions()
            {
                Path = new PathString("/welcome")
            });

            app.Run(context =>
            {
                string output = "error";

                if (context.Request.Path.StartsWithSegments(new PathString("/temperature")))
                {
                    context.Response.ContentType = "application/json";

                    output = string.Format("{{ \"temperature\": {0} }}", rnd.Next(63,79));
                }
                else if (context.Request.Path.StartsWithSegments(new PathString("/os")))
                {
                    context.Response.ContentType = "text/plain";

                    output = string.Format("I'm running on {0}\nFrom Assembly {1}\nRequest {2}",
                        Environment.OSVersion,
                        System.Reflection.Assembly.GetEntryAssembly().FullName,
                        context.Request.Path);
                }
                else
                {
                    context.Response.ContentType = "text/html";
                    string filename = context.Request.Path.ToString().Substring(1);
                    if (File.Exists(filename))
                    {
                        output = File.ReadAllText(filename);
                        if (Path.GetExtension(filename).ToLower() == "js")
                            context.Response.ContentType = "application/javascript";
                    }
                    else
                    {
                        output = "<html><head><title>Error</title></head><body>index.html not found</body></html>";
                    }
                }
                return context.Response.WriteAsync(output);
            });

        }
    }
}
