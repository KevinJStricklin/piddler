﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ConsoleTempServer.Startup))]
namespace ConsoleTempServer
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage();
        }
    }
}
