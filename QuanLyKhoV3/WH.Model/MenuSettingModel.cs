using WH.Entity;

namespace WH.Model
{
    public class MenuSettingModel
    {
        public MenuSettingModel(CHUCNANG menusetting)
        {
            UsergroupMenu = menusetting;
        }

        public MenuSettingModel()
        {
        }

        public CHUCNANG UsergroupMenu { get; set; }

        public int Id => UsergroupMenu.MACHUCNANG;

        public string Tag => UsergroupMenu.TENCHUCNANG;

        public bool IsDisabled => false;

        public bool IsVisibled => true;
    }
}