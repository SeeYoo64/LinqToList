using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToList.Classes
{
    public class finalList : sourceList
    {
        public int cumulative_total;
        public finalList(string item, int quantity, int cumulative_total) : base(item, quantity)
        {
            this.cumulative_total = cumulative_total;
        }
    }
}
