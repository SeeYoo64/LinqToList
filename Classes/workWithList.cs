using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToList.Interfaces;

namespace LinqToList.Classes
{
    public class workWithList : IBinder
    {
        public static List<sourceList> bind()
        {
            var taskList = new List<sourceList>()
            {
                new sourceList("139/30", 10),
                new sourceList("167/20", 10),
                new sourceList("167/30", 15),
                new sourceList("23/30", 64),
                new sourceList("232/25", 49), // 5
                new sourceList("236/20", 68),
                new sourceList("236/30", 32),
                new sourceList("237/30", 54),
                new sourceList("238/30", 52),
                new sourceList("241/20", 44), // 10 (9)
                new sourceList("241/30", 34),
                new sourceList("241/40", 8),
                new sourceList("25/30", 6) ,
                new sourceList("251/30", 6) ,
                new sourceList("254/30", 10) , // 15
                new sourceList("270/30", 6) ,
                new sourceList("33/20", 6) ,
                new sourceList("342/40", 6) ,
                new sourceList("35/20", 1) ,
                new sourceList("36/20", 2) , // 20
                new sourceList("38/20", 5) ,
                new sourceList("39/30", 4) ,
                new sourceList("390/30", 4) ,
                new sourceList("390/40", 50) ,
                new sourceList("42/30", 22) , // 25
                new sourceList("44/30", 62) ,
                new sourceList("45/30", 6) ,
                new sourceList("46/30", 14) ,
                new sourceList("54/25", 66) ,
                new sourceList("59/20", 52),  // 30
                new sourceList("68/30", 1) ,
                new sourceList("95/30", 48),
                new sourceList("97/30", 10) , // 33
            };
            return taskList;
        }

        private static IOrderedEnumerable<sourceList> ConditionHigher(List<sourceList> taskList)
        {
            var selected = from p in taskList
                           where p.quantity >= 10 && p.quantity < 160
                           orderby p.quantity descending
                           select p;
            return selected;
        }

        private static IOrderedEnumerable<sourceList> ConditionLower(List<sourceList> taskList)
        {
            var selected = from p in taskList
                           where p.quantity < 10
                           orderby p.quantity descending
                           select p;
            return selected;
        }


        public static void print(List<finalList> higherList, List<finalList> LowerList)
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


        public static List<finalList> highThan(List<sourceList> taskList)
        {
            int counter = 0;
            int cumulative_total = 0;
            var finalHigherList = new List<finalList>();
            IOrderedEnumerable<sourceList> selected = ConditionHigher(taskList);

            foreach (var item in selected)
            {
                cumulative_total += item.quantity;

                if (cumulative_total <= 160)
                    finalHigherList.Add(new finalList(item.item, item.quantity, cumulative_total));


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

        public static List<finalList> lowerThan(List<sourceList> taskList)
        {
            int counter = 0;
            int cumulative_total = 0;
            var finalLowerList = new List<finalList>();
            IOrderedEnumerable<sourceList> selected = ConditionLower(taskList);

            foreach (var item in selected)
            {
                cumulative_total += item.quantity;

                if (cumulative_total <= 40)
                    finalLowerList.Add(new finalList(item.item, item.quantity, cumulative_total));

                else
                {
                    counter++;
                    if (counter == 1)
                    {
                        cumulative_total -= item.quantity;
                        finalLowerList.Add(new finalList(item.item, 40 - cumulative_total, 40));
                        break;
                    }
                }

            }
            return finalLowerList;
        }


    }
}
