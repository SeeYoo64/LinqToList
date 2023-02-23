using LinqToList.Classes;


namespace LinqToList
{
    class Program
    {


        static void Main(string[] args)
        {
            workWithBaseData bsed = new workWithBaseData();

            Console.WriteLine("============== DATA BASE ==============");

            var taskListBaseData = bsed.bind();

            var higherListBaseData = workWithBaseData.highThan(taskListBaseData);

            var LowerListBaseData = workWithBaseData.lowerThan(taskListBaseData);

            workWithBaseData.print(higherListBaseData, LowerListBaseData);


            Console.WriteLine("\n============== LIST ==============\n");

            workWithList sad = new workWithList();

            var taskList = sad.bind();

            var higherList = sad.highThan(taskList);

            var LowerList = sad.lowerThan(taskList);

            sad.print(higherList, LowerList);


            Console.Read();

        }
    }
}

/*
 * 
 * ExecuteNonQuery()/ExecuteNonQueryAsync(): просто выполняет sql-выражение и возвращает количество измененных записей. 
 * Подходит для sql-выражений INSERT, UPDATE, DELETE, CREATE.

ExecuteReader()/ExecuteReaderAsync(): выполняет sql-выражение и возвращает строки из таблицы. 
Подходит для sql-выражения SELECT.

ExecuteScalar()/ExecuteScalarAsync(): выполняет sql-выражение и возвращает одно скалярное значение, например, число. 
Подходит для sql-выражения SELECT в паре с одной из встроенных функций SQL, как например, Min, Max, Sum, Count.
 * 
 * 
 */