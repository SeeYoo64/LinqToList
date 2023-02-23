using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToList.Classes
{
     public abstract class work
    {
        public abstract List<finalList> lowerThan(List<sourceList> taskList);

        public abstract IOrderedEnumerable<sourceList> ConditionHigher(List<sourceList> taskList);

        public abstract IOrderedEnumerable<sourceList> ConditionLower(List<sourceList> taskList);


        public abstract void print(List<finalList> higherList, List<finalList> LowerList);


        public abstract List<finalList> highThan(List<sourceList> taskList);

    }
}
