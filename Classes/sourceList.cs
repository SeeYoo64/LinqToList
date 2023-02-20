using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToList.Classes
{
    public class sourceList
    {
        public string item { get; set; }
        public int quantity { get; set; }
        public sourceList(string item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }
    }
}
