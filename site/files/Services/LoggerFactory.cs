using System;
using Microsoft.Extensions.Logging;

namespace VWAT.Services
{
  public class LoggerFactory : ILoggerFactory
  {
    public void AddProvider(ILoggerProvider provider)
    {
      
    }

    public ILogger CreateLogger(string categoryName)
    {
      return new Logger();
    }

    public void Dispose()
    {
      
    }
  }
}