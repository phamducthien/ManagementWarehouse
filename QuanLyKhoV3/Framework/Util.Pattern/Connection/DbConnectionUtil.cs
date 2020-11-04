//using System.Data.Entity.Core.EntityClient;

using System;
using System.Data;

namespace Util.Pattern.Connection
{
    public interface IDbConnectionUtil<T> where T : class, IDbConnection
    {
        string Server { get; set; }
        string DbName { get; set; }
        string UserId { get; set; }
        string Password { get; set; }
        string Application { get; set; }
        string ConnectionString { get; }
        T GetConnection();

        bool TryConnect();

        //void CopyFrom(DbConnectionUtil<T> connectionUtil);
        string ToString();
    }

    public abstract class DbConnectionUtil<T> : IDbConnectionUtil<T> where T : class, IDbConnection
    {
        //protected T NestedConnection { get; set; }

        public string Server { get; set; }
        public string DbName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Application { get; set; }

        public string ConnectionString => GetConnectionString();

        public abstract T GetConnection();

        //public virtual void CopyFrom(DbConnectionUtil connectionUtil)
        //{
        //    this.Server = connectionUtil.Server;
        //    this.DbName = connectionUtil.DbName;
        //    this.UserId = connectionUtil.UserId;
        //    this.Password = connectionUtil.Password;
        //}

        public bool TryConnect()
        {
            var res = true;

            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    res = false;
                }
            }

            return res;
        }

        protected abstract string GetConnectionString();
    }
}