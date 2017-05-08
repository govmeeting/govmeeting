using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace Backend.AutoTranscription_Test
{
    public class DITest : IDisposable
    {
        IServiceProvider _serviceProvider;
        ILogger<Microsoft.VisualStudio.TestPlatform.TestHost.Program> _logger;
        public DITest()
        {
            //setup our DI
            _serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IFooService, FooService>()
                .AddSingleton<IBarService, BarService>()
                .BuildServiceProvider();

            //configure console logging
            _serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            _logger = _serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Microsoft.VisualStudio.TestPlatform.TestHost.Program>();
            _logger.LogDebug("Starting application");
        }
        public void Dispose()
        {
            // Do we need to clean these up? They have not "dispose" method.
            _serviceProvider = null;
            _logger = null;
        }

        [Fact]
        public void BarTest()
        {
            var bar = _serviceProvider.GetService<IBarService>();
            bar.DoSomeRealWork();

            _logger.LogDebug("All done!");

        }
    }
}

// https://andrewlock.net/using-dependency-injection-in-a-net-core-console-application/
// https://csharp.christiannagel.com/2016/06/04/dependencyinjection/
// https://xunit.github.io/docs/shared-context.html
