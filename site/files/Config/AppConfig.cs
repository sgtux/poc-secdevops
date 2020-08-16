using System;

namespace VWAT.Config
{
  public class AppConfig
  {
    public AppConfig()
    {
      JwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
      ConnectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
    }

    public string JwtKey { get; private set; }

    public string ConnectionString { get; private set; }
  }
}