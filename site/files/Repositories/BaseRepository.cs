using VWAT.Config;
using VWAT.Models;
using Dapper;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using static System.Console;
using System;

namespace VWAT.Repositories
{
  public abstract class BaseRepository<T> where T : BaseEntity
  {
    private readonly IDbConnection _conn;

    protected readonly string TableName;

    public IDbTransaction Transaction { get; private set; }

    protected BaseRepository(AppConfig config)
    {
      _conn = new NpgsqlConnection(config.ConnectionString);
      TableName = (Activator.CreateInstance(typeof(T)) as T).EntityName;
    }

    protected void Execute(string query, object parameters = null)
    {
      try
      {
        Log(query);
        _conn.Execute(query, parameters);
      }
      catch (Exception ex)
      {
        WriteLine(ex.Message);
        throw;
      }
    }

    protected U ExecuteScalar<U>(string query, object parameters = null)
    {
      try
      {
        Log(query);
        return _conn.ExecuteScalar<U>(query, parameters);
      }
      catch (Exception ex)
      {
        WriteLine(ex.Message);
        throw;
      }
    }

    protected T FirstOrDefault(string query, object parameters = null)
    {
      try
      {
        Log(query);
        return _conn.QuerySingleOrDefault<T>(query, parameters);
      }
      catch (Exception ex)
      {
        WriteLine(ex.Message);
        throw;
      }
    }

    protected IEnumerable<T> Query(string query, object parameters = null)
    {
      try
      {
        Log(query);
        return _conn.Query<T>(query, parameters);
      }
      catch (Exception ex)
      {
        WriteLine(ex.Message);
        throw;
      }
    }

    public bool Exists(T entity)
    {
      try
      {
        var query = $"SELECT COUNT(1) FROM \"{TableName}\" WHERE \"Id\" = @Id";
        Log(query);
        return _conn.ExecuteScalar<long>(query, new { Id = entity.Id }) > 0;
      }
      catch (Exception ex)
      {
        WriteLine(ex.Message);
        throw;
      }
    }

    public void Remove(long id) => Execute($"DELETE FROM \"{TableName}\" WHERE \"Id\" = @Id", new { Id = id });

    public long CurrentId(T entity)
    {
      try
      {
        var query = $"SELECT MAX(\"Id\") FROM \"{entity.EntityName}\"";
        Log(query);
        return _conn.ExecuteScalar<long>(query);
      }
      catch (Exception ex)
      {
        WriteLine(ex.Message);
        throw;
      }
    }

    private void Log(string query)
    {
      WriteLine("");
      WriteLine("");
      WriteLine($"Query:{query}");
      WriteLine("");
      WriteLine("");
    }
  }
}