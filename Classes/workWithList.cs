using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToList.Classes.Lists;
using LinqToList.Interfaces;

namespace LinqToList.Classes
{
    public class workWithList : work, workOther<finalList>
    {
        private List<sourceList> taskList = new List<sourceList>();

        public workWithList(List<sourceList> taskList) 
        {
            this.taskList = taskList;
        }


        public IOrderedEnumerable<sourceList> ConditionHigher()
        {
            var selected = from p in taskList
                           where p.quantity >= 10 && p.quantity < 160
                           orderby p.quantity descending
                           select p;
            return selected;
        }

        public IOrderedEnumerable<sourceList> ConditionLower()
        {
            var selected = from p in taskList
                           where p.quantity < 10
                           orderby p.quantity descending
                           select p;
            return selected;
        }


        public void print(List<finalList> higherList, List<finalList> LowerList)
        {
            Console.WriteLine("ID   \t|  Item \t|  Quantity \t|  Cumulative_total");
            Console.WriteLine("-----\t|  -----\t|  ---------\t|  ----------------");

            foreach (var higher in higherList)
            {
                Console.WriteLine($"{higherList.IndexOf(higher)}\t|  {higher.item}\t|  " +
                    $"{higher.quantity}\t\t|  {higher.cumulative_total}");
            }
            foreach (var lower in LowerList)
            {
                Console.WriteLine($"{LowerList.IndexOf(lower)}\t|  {lower.item}\t|  " +
                    $"{lower.quantity}\t\t|  {lower.cumulative_total}");
            }


        }


        public List<finalList> highThan()
        {
            int counter = 0;
            int cumulative_total = 0;
            var finalHigherList = new List<finalList>();
            IOrderedEnumerable<sourceList> selected = ConditionHigher();

            foreach (var item in selected)
            {
                cumulative_total += item.quantity;

                if (cumulative_total < 160)
                    finalHigherList.Add(new finalList(item.item, item.quantity, cumulative_total));


                else if (cumulative_total == 160) continue;
                else
                {
                    counter++;
                    if (counter == 1)
                    {
                        cumulative_total -= item.quantity;
                        finalHigherList.Add(new finalList(item.item, 160 - cumulative_total, 160));
                        break;
                    }
                }

            }

            return finalHigherList;
        }

        public List<finalList> lowerThan()
        {
            int counter = 0;
            int cumulative_total = 0;
            var finalLowerList = new List<finalList>();
            IOrderedEnumerable<sourceList> selected = ConditionLower();

            foreach (var item in selected)
            {
                cumulative_total += item.quantity;

                if (cumulative_total < 40)
                    finalLowerList.Add(new finalList(item.item, item.quantity, cumulative_total));

                else if (cumulative_total > 40) counter++;
                if (counter == 1)
                {
                    cumulative_total -= item.quantity;
                    finalLowerList.Add(new finalList(item.item, 40 - cumulative_total, 40));
                    break;
                }
                else continue;
            }

            return finalLowerList;
        }

    }
}
