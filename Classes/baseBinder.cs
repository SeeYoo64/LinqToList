using LinqToList.Classes.Lists;
using LinqToList.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToList.Classes
{
    public class baseBinder : IBinder
    {
        private static readonly string connectionString = "Data Source=HOME-PC;Initial Catalog=Linq;" +
            "Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

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

    }
}
