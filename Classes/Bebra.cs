using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToList.Classes
{
    public class Bebra
    {
        public string item { get; set; }
        public int quantity { get; set; }
        public Bebra(string item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }
    }
}
