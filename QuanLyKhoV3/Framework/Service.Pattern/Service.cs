using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Text;
using Repository.Pattern.DataContext;
using Repository.Pattern.UnitOfWork;

namespace Service.Pattern
{
    public interface IService : IErrorProvider
    {
    }

    public abstract class Service : ErrorProvider, IService
    {
        #region Private Fields

        protected IUnitOfWorkAsync _unitOfWork;

        #endregion Private Fields

        #region Properties

        public IDataContextAsync _dataContext => _unitOfWork.DataContext;

        #endregion

        protected Exception HandleDbUpdateException(DbUpdateException dbu)
        {
            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

            try
            {
                builder.Append(dbu.Message);
                foreach (var result in dbu.Entries)
                    builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e);
            }

            var message = builder.ToString();
            return new Exception(message, dbu);
        }

        protected Exception HandleDbEntityValidationException(DbEntityValidationException dbu)
        {
            var builder = new StringBuilder("DbEntityValidationException :\n");
            foreach (var eve in dbu.EntityValidationErrors)
            {
                builder.Append("Entity of type \"" + eve.Entry.Entity.GetType().Name + "\" in state \"" +
                               eve.Entry.State +
                               "\" has the following validation errors:");
                try
                {
                    foreach (var ve in eve.ValidationErrors)
                        //builder.AppendFormat("Type: {0} was part of the problem. ", ve.GetType().Name);
                        builder.Append("\n - Property: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage +
                                       "\"");
                }
                catch (Exception e)
                {
                    builder.Append("Error parsing DbEntityValidationException: " + e);
                }
            }

            var message = builder.ToString();
            return new Exception(message, dbu);
        }

        #region Constructor

        protected Service(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitRepositories();
        }

        protected abstract void InitRepositories();

        protected virtual int SaveChanges()
        {
            return _unitOfWork.SaveChanges();
        }

        protected virtual int SaveBeforeChanges()
        {
            return _unitOfWork.SaveBeforeChanges();
        }

        protected virtual void SaveAfterChanges()
        {
            _unitOfWork.SaveAfterChanges();
        }

        #endregion Constructor
    }
}