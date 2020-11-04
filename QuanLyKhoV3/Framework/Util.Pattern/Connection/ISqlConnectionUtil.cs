using System.Collections.Generic;
using System.Data;

namespace Util.Pattern.Connection
{
    public interface ISqlConnectionUtil<T> : IDbConnectionUtil<T> where T : class, IDbConnection
    {
        List<string> EnumerateServers();
        List<string> EnumerateDatabases();
    }
}