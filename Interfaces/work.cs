using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToList.Classes.Lists;

namespace LinqToList.Interfaces
{
    public interface work
    {
        public abstract List<finalList> lowerThan();

        public abstract IOrderedEnumerable<sourceList> ConditionHigher();

        public abstract IOrderedEnumerable<sourceList> ConditionLower();

        public abstract List<finalList> highThan();

    }
}
