#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Practices.ServiceLocation;
using Repository.Pattern.DataContext;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using IsolationLevel = System.Data.IsolationLevel;

#endregion

namespace Repository.Pattern.Ef6
{
    public class UnitOfWork : IUnitOfWorkAsync
    {
        #region Properties

        public IDataContextAsync DataContext { get; private set; }

        #endregion

        public int SaveChanges()
        {
            return _objectContext.SaveChanges();
        }

        public int DataContextSaveChanges()
        {
            return DataContext.SaveChanges();
        }

        public int SaveBeforeChanges()
        {
            // return _objectContext.SaveChanges();
            return _objectContext.SaveChanges(SaveOptions.DetectChangesBeforeSave);
        }

        public void SaveAfterChanges()
        {
            _objectContext.AcceptAllChanges();
            _transaction?.Dispose();
            _transactionScope?.Dispose();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState
        {
            if (ServiceLocator.IsLocationProviderSet) return ServiceLocator.Current.GetInstance<IRepository<TEntity>>();

            return RepositoryAsync<TEntity>();
        }

        public Task<int> SaveChangesAsync()
        {
            return DataContext.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return DataContext.SaveChangesAsync(cancellationToken);
        }

        public IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState
        {
            if (ServiceLocator.IsLocationProviderSet)
                return ServiceLocator.Current.GetInstance<IRepositoryAsync<TEntity>>();

            if (_repositories == null) _repositories = new Dictionary<string, dynamic>();

            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type)) return (IRepositoryAsync<TEntity>) _repositories[type];

            var repositoryType = typeof(Repository<>);

            _repositories.Add(type,
                Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), DataContext, this));

            return _repositories[type];
        }

        #region Private Fields

        private bool _disposed;
        private ObjectContext _objectContext;
        private DbTransaction _transaction;
        private TransactionScope _transactionScope;
        private Dictionary<string, dynamic> _repositories;

        #endregion Private Fields

        #region Constuctor/Dispose

        public UnitOfWork(IDataContextAsync dataContext)
        {
            DataContext = dataContext;
            // _objectContext = ((IObjectContextAdapter)_dataContext).ObjectContext;
            _repositories = new Dictionary<string, dynamic>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // free other managed objects that implement
                // IDisposable only
                try
                {
                    if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
                        _objectContext.Connection.Close();
                }
                catch (ObjectDisposedException)
                {
                    // do nothing, the objectContext has already been disposed
                }

                if (DataContext != null)
                {
                    DataContext.Dispose();
                    DataContext = null;
                }

                _transaction?.Dispose();
                _transactionScope?.Dispose();
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }

        #endregion Constuctor/Dispose

        #region Unit of Work Transactions

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            _objectContext = ((IObjectContextAdapter) DataContext).ObjectContext;
            if (_objectContext.Connection.State != ConnectionState.Open) _objectContext.Connection.Open();
            _transaction = _objectContext.Connection.BeginTransaction(isolationLevel);
        }

        public void BeginTransactionScope()
        {
            _objectContext = ((IObjectContextAdapter) DataContext).ObjectContext;
            if (_objectContext.Connection.State != ConnectionState.Open) _objectContext.Connection.Open();

            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };

            _transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }

        public void EndTransactionScope()
        {
            _transactionScope?.Complete();
            _transactionScope?.Dispose();
        }

        public bool Commit()
        {
            _transaction?.Commit();
            _transaction?.Dispose();
            _objectContext.AcceptAllChanges();
            return true;
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
            DataContext.SyncObjectsStatePostCommit();
        }

        #endregion
    }
}