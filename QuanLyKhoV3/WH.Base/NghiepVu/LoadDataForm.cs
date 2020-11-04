using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WH.Service.Repository.Core;

namespace WH.Base.UI.NghiepVu
{
    public static class LoadDataForm
    {
        public static IUnitOfWorkAsync UnitOfWorkAsync;

        public static void ReloadUnitOfWork()
        {
            if (UnitOfWorkAsync != null)
                UnitOfWorkAsync.Dispose();
            UnitOfWorkAsync = null;
            UnitOfWorkAsync = UnitOfWorkFactory.MakeUnitOfWork();
        }
    }
}
