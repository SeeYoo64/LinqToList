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
                           where p.quantity > 10 && p.quantity < 160
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

        public static void print()
        {
            Console.WriteLine("ID   \t|  Item \t|  Quantity \t|  Cumulative_total");
            Console.WriteLine("-----\t|  -----\t|  ---------\t|  ----------------");

        }

        public static void highThan(List<Bebra> taskList)
        {
            int counter = 0;
            int cumulative_total = 0;

            IOrderedEnumerable<Bebra> selected = ConditionHigher(taskList);

            foreach (var item in selected)
            {
                cumulative_total += item.quantity;

                if (cumulative_total <= 160)

                    Console.WriteLine(taskList.IndexOf(item) + "\t|  " + item.item + "\t|  "
                                    + item.quantity + "\t\t|  " + cumulative_total + "\t|  ");
                else
                {
                    counter++;
                    if (counter == 1)
                    {
                        cumulative_total -= item.quantity;
                        Console.WriteLine($"{taskList.IndexOf(item)}\t|  {taskList[taskList.IndexOf(item)].item}\t|  " +
                                          $"{160 - cumulative_total}\t\t|  {160}\t|  ");
                        counter++;
                    }
                }

            }
        }

        public static void lowerThan(List<Bebra> taskList)
        {
            int counter = 0;
            int cumulative_total = 0;

            IOrderedEnumerable<Bebra> selected = ConditionLower(taskList);

            foreach (var item2 in selected)
            {
                cumulative_total += item2.quantity;

                if (cumulative_total <= 40)

                    Console.WriteLine(taskList.IndexOf(item2) + "\t|  " + item2.item + "\t|  "
                                    + item2.quantity + "\t\t|  " + cumulative_total + "\t|  ");
                else
                {
                    counter++;
                    if (counter == 1)
                    {
                        cumulative_total -= item2.quantity;
                        Console.WriteLine($"{taskList.IndexOf(item2)}\t|  {taskList[taskList.IndexOf(item2)].item}\t|  " +
                                          $"{40 - cumulative_total}\t\t|  {40}\t|  ");
                        counter++;
                    }
                }

            }
        }


    }
}
