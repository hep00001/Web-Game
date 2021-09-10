using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class MenuDao
    {
        ShopGameDbContext db = null;
        public MenuDao()
        {
            db = new ShopGameDbContext();
        }
        public List<Menu> ListByGroupId(int groupID)
        {
            return db.Menus.Where(x => x.TypeID == groupID && x.Status==true).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
