using LinqToList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace LinqToList.Classes
{
    public class workWithBaseData : work, IBinder
    {
        private static readonly string connectionString = "Data Source=HOME-PC;Initial Catalog=Linq;Integrated " +
        "Security=True;Encrypt=True;TrustServerCertificate=True";

        public List<sourceList> bind()
        {
            string sqlExpression = "Select * FROM Task";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();   // открываем подключение

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<sourceList> dataBaseListSource = new List<sourceList>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataBaseListSource.Add(new sourceList((string)reader.GetValue(0), (int)reader.GetValue(1)));
                    }

                }
                return dataBaseListSource;
            }
        }

        public override IOrderedEnumerable<sourceList> ConditionHigher(List<sourceList> taskList)
        {
            var selected = from p in taskList
                           where p.quantity >= 10 && p.quantity < 160
                           orderby p.quantity descending
                           select p;
            return selected;
        }

        public override IOrderedEnumerable<sourceList> ConditionLower(List<sourceList> taskList)
        {
            var selected = from p in taskList
                           where p.quantity < 10
                           orderby p.quantity descending
                           select p;
            return selected;
        }


        public override void print(List<finalList> higherList, List<finalList> LowerList)
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


        public override List<finalList> highThan(List<sourceList> taskList)
        {
            int counter = 0;
            int cumulative_total = 0;
            var finalHigherList = new List<finalList>();
            IOrderedEnumerable<sourceList> selected = ConditionHigher(taskList);

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

        public override List<finalList> lowerThan(List<sourceList> taskList)
        {
            int counter = 0;
            int cumulative_total = 0;
            var finalLowerList = new List<finalList>();
            IOrderedEnumerable<sourceList> selected = ConditionLower(taskList);

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
