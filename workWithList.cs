using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToList
{
    public class workWithList
    {

        private static IOrderedEnumerable<Bebra> ConditionHigher(List<Bebra> taskList)
        {
            var selected = from p in taskList
                           where p.quantity >= 10 && p.quantity < 160
                           orderby p.quantity descending
                           select p;
            return selected;
        }

        private static IOrderedEnumerable<Bebra> ConditionLower(List<Bebra> taskList)
        {
            var selected = from p in taskList
                           where p.quantity < 10
                           orderby p.quantity descending
                           select p;
            return selected;
        }


        public static void print(List<FinalBebra> higherList, List<FinalBebra> LowerList)
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


        public static List<FinalBebra> highThan(List<Bebra> taskList)
        {
            int counter = 0;
            int cumulative_total = 0;
            var finalHigherList = new List<FinalBebra>();
            IOrderedEnumerable<Bebra> selected = ConditionHigher(taskList);

            foreach (var item in selected)
            {
                cumulative_total += item.quantity;

                if (cumulative_total <= 160)
                    finalHigherList.Add(new FinalBebra(item.item, item.quantity, cumulative_total));
                
                    
                else
                {
                    counter++;
                    if (counter == 1)
                    {
                        cumulative_total -= item.quantity;
                        finalHigherList.Add(new FinalBebra(item.item, 160 - cumulative_total, 160));
                        counter++;
                    }
                }

            }

            return finalHigherList;
        }

        public static List<FinalBebra> lowerThan(List<Bebra> taskList)
        {
            int counter = 0;
            int cumulative_total = 0;
            var finalLowerList = new List<FinalBebra>();
            IOrderedEnumerable<Bebra> selected = ConditionLower(taskList);

            foreach (var item in selected)
            {
                cumulative_total += item.quantity;

                if (cumulative_total <= 40)
                    finalLowerList.Add(new FinalBebra(item.item, item.quantity, cumulative_total));

                else
                {
                    counter++;
                    if (counter == 1)
                    {
                        cumulative_total -= item.quantity;
                        finalLowerList.Add(new FinalBebra(item.item, 40 - cumulative_total, 40));
                        counter++;
                    }
                }

            }
            return finalLowerList;
        }


    }
}
