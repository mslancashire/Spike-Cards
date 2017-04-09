using Microsoft.Extensions.Logging;
using System;

namespace Cards.API.Tests.TestHelpers
{
    public class MockServiceProvider : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(ILoggerFactory))
                return new LoggerFactory();
            else
                throw new ArgumentException();
        }
    }
}
