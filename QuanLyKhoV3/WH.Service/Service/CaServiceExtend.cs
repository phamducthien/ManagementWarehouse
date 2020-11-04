using System.Collections.Generic;
using WH.Entity;

namespace WH.Service
{
    public interface ICAService
    {
        List<CA> FindByUserId(string userId);
    }

    /// <summary>
    ///     Summary description for CA.
    /// </summary>
    public class CAService
    {
        //public List<CA> FindByUserId(string userId)
        //{
        //    return _CARepository.FindByUserId(userId);
        //}
    }
}