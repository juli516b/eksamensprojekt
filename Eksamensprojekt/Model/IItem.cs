using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IItem
    {
        string ItemName { get; set; }
        string ItemNo { get; set; }
        double ItemPrice { get; set; }
    }
}
