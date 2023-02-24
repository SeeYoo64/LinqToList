using LinqToList.Classes.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToList.Interfaces
{
    public interface workOther<T>
    {
        public void print(List<T> higherList, List<T> LowerList);
    }
}
