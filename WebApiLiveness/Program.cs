using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace WebApiLiveness
{
    public class Program
    {
        private static int _port = 80;
        private static TimeSpan _kaTimeout = TimeSpan.FromSeconds(1);

        public static void Main(string[] args)
        {
            CreateAndRunHost(args);
        }

        public static void CreateAndRunHost(string[] args)
        {
            var host = Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel(options => 
                        {
                            options.ListenAnyIP(_port);
                            options.Limits.KeepAliveTimeout = _kaTimeout;
                        })
                        .UseStartup<Startup>();
                })
                .Build();

            host.Run();
        }
    }
}
