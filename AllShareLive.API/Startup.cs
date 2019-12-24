using System;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace AllShareLive.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(AboutMe());
                });
            });
        }

        public string AboutMe()
        {
            string myInfo = "Hello World!" + Environment.NewLine;

            myInfo += Environment.NewLine + ":: Env Machine Name :: " + Environment.MachineName;
            myInfo += Environment.NewLine + ":: Env User Name :: " + Environment.UserName;
            myInfo += Environment.NewLine;

            myInfo += Environment.NewLine + ":: Date & Time Now :: " + DateTime.Now;
            myInfo += Environment.NewLine + ":: Date & Time UtcNow :: " + DateTime.UtcNow;
            myInfo += Environment.NewLine;

            myInfo += Environment.NewLine + ":: Env OS Version Platform :: " + Environment.OSVersion.Platform;
            myInfo += Environment.NewLine + ":: Env OS Version Service Pack :: " + Environment.OSVersion.ServicePack;
            myInfo += Environment.NewLine + ":: Env OS Version Version :: " + Environment.OSVersion.VersionString;
            myInfo += Environment.NewLine + ":: Env Version :: " + Environment.Version;
            myInfo += Environment.NewLine;

            myInfo += Environment.NewLine + ":: Env Current Directory :: " + Environment.CurrentDirectory;
            myInfo += Environment.NewLine + ":: Env System Directory :: " + Environment.SystemDirectory;
            myInfo += Environment.NewLine;

            myInfo += Environment.NewLine + ":: Env Processor Count :: " + Environment.ProcessorCount;
            myInfo += Environment.NewLine + ":: Env Working Set :: " + Environment.WorkingSet;            
            myInfo += Environment.NewLine + ":: Env Current Managed Thread Id :: " + Environment.CurrentManagedThreadId;
            myInfo += Environment.NewLine;

            myInfo += Environment.NewLine + ":: Env Command Line :: " + Environment.CommandLine;
            myInfo += Environment.NewLine + ":: Env Get Command Line Arg Count :: " + Environment.GetCommandLineArgs().Count();            
            for (int i = 0; i < Environment.GetCommandLineArgs().Count(); i++)
                myInfo += String.Format(Environment.NewLine + ":: Env Get CmdLine Arg {0} :: {1}", i, Environment.CommandLine[i].ToString());
            myInfo += Environment.NewLine;

            myInfo += Environment.NewLine + ":: Env Get Environment Variables Count :: " + Environment.GetEnvironmentVariables().Count;
            foreach (DictionaryEntry eV in Environment.GetEnvironmentVariables())                
                myInfo += String.Format(Environment.NewLine + ":: Env Get EnvVar {0} :: {1}", eV.Key, eV.Value);
            myInfo += Environment.NewLine;            

            return myInfo;
        }
    }
}
