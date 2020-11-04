using System;
using System.Data;
using Repository.Pattern.DataContext;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;

namespace Repository.Pattern.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDataContextAsync DataContext { get; }
        int SaveChanges();
        int DataContextSaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();

        void Rollback();

        //TransactionScope
        void BeginTransactionScope();
        void EndTransactionScope();
        int SaveBeforeChanges();
        void SaveAfterChanges();
    }
}