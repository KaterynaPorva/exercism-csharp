using System;

public class Orm : IDisposable
{
    private readonly Database database;
    private bool disposed = false;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        if (database.DbState != Database.State.Closed)
            throw new InvalidOperationException();

        database.BeginTransaction();
    }

    public void Write(string data)
    {
        if (database.DbState != Database.State.TransactionStarted)
        {
            database.Dispose();
            return;
        }

        try
        {
            database.Write(data);
        }
        catch
        {
            database.Dispose();
            return;
        }
    }

    public void Commit()
    {
        if (database.DbState != Database.State.DataWritten)
        {
            database.Dispose();
            return;
        }

        try
        {
            database.EndTransaction();
        }
        catch
        {
            database.Dispose();
            return;
        }
    }

    public void Dispose()
    {
        if (!disposed)
        {
            database.Dispose();
            disposed = true;
        }
    }
}