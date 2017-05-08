using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;


namespace Backend.AutoTranscription_Test
{
    class foobar
    {
    }
    public interface IFooService
    {
        void DoThing(int number);
    }

    public interface IBarService
    {
        void DoSomeRealWork();
    }

    public class BarService : IBarService
    {
        private readonly IFooService _fooService;
        public BarService(IFooService fooService)
        {
            _fooService = fooService;
        }

        public void DoSomeRealWork()
        {
            for (int i = 0; i < 10; i++)
            {
                _fooService.DoThing(i);
            }
        }
    }

    public class FooService : IFooService
    {
        private readonly ILogger<FooService> _logger;
        public FooService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FooService>();
        }

        public void DoThing(int number)
        {
            _logger.LogInformation($"Doing the thing {number}");
        }
    }

    public class FooService_Stub : IFooService
    {
        private readonly ILogger<FooService> _logger;
        public FooService_Stub(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FooService>();
        }

        public void DoThing(int number)
        {
            _logger.LogInformation($"Doing the stub thing {number}");
        }
    }
}

