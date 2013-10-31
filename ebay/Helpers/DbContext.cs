using StructureMap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using MongoRepository;

namespace ebay.Helpers
{
    public static class DbContext <M> where M : Entity
{
    private const string HTTPCONTEXTKEY = "Session.Base.HttpContext.Key";
    private static readonly Hashtable _threads = new Hashtable();

    /// <summary>
    /// Returns a database context or creates one if it doesn't exist.
    /// </summary>
    public static IRepository<M> Current 
    {
        get
        {
            return GetOrCreateSession();
        }
    }

    /// <summary>
    /// Returns true if a database context is open.
    /// </summary>
    public static bool IsOpen
    {
        get
        {
            IRepository<M> session = GetSession();
            return (session != null);
        }
    }

    #region Private Helpers

    private static IRepository<M> GetOrCreateSession() 
    {
        IRepository<M> session = GetSession();
        if (session == null)
        {
            session = ObjectFactory.GetInstance<IRepository<M>>();

            SaveSession(session);
        }

        return session;
    }

    private static IRepository<M> GetSession()
    {
        if (HttpContext.Current != null)
        {
            if (HttpContext.Current.Items.Contains(HTTPCONTEXTKEY))
            {
                return (IRepository<M>)HttpContext.Current.Items[HTTPCONTEXTKEY];
            }

            return null;
        }
        else
        {
            Thread thread = Thread.CurrentThread;
            if (string.IsNullOrEmpty(thread.Name))
            {
                thread.Name = Guid.NewGuid().ToString();
                return null;
            }
            else
            {
                lock (_threads.SyncRoot)
                {
                    return (IRepository<M>)_threads[Thread.CurrentThread.Name];
                }
            }
        }
    }

    private static void SaveSession(IRepository<M> session)
    {
        if (HttpContext.Current != null)
        {
            HttpContext.Current.Items[HTTPCONTEXTKEY] = session;
        }
        else
        {
            lock (_threads.SyncRoot)
            {
                _threads[Thread.CurrentThread.Name] = session;
            }
        }
    }

    #endregion
}
}