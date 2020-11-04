using System.ComponentModel.DataAnnotations.Schema;
using Repository.Pattern.Infrastructure;

namespace Repository.Pattern.Ef6
{
    public abstract partial class Entity : IObjectState
    {
        public bool isDelete { get; set; }
        public bool isAdd { get; set; }
        public bool isUpdate { get; set; }
        public bool isLoaded { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}