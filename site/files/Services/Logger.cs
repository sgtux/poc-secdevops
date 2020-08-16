using System;
using Microsoft.Extensions.Logging;

namespace VWAT.Services
{
  public class Logger : ILogger
  {
    public string Name { get; set; }
    public Logger()
    {
      Name = nameof(Logger);
    }

    public IDisposable BeginScope<TState>(TState state)
    {
      return new LoggerScope();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
      return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
      if (!this.IsEnabled(logLevel))
        return;

      if (formatter == null)
        throw new ArgumentNullException(nameof(formatter));

      string message = formatter(state, exception);
      if (string.IsNullOrEmpty(message) && exception == null)
        return;

      string line = $"{logLevel}: {this.Name}: {message}";

      Console.WriteLine(line);

      if (exception != null)
        Console.WriteLine(exception.ToString());
    }
  }

  public class LoggerScope : IDisposable
  {
    public void Dispose()
    {
    }
  }
}