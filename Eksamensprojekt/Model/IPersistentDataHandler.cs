using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPersistentDataHandler
    {
        IList<IItem> GetAll(IList<IItem> items);
        //bool SaveType();
        //bool UpdateType();
        //bool DeleteType();
    }
}
