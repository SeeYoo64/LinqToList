using LinqToList.Classes;


namespace LinqToList
{
    class Program
    {


        static void Main(string[] args)
        {
            workWithBaseData DataBase = new workWithBaseData();

            Console.WriteLine("============== DATA BASE ==============");

            var taskListBaseData = DataBase.bind();

            var higherListBaseData = DataBase.highThan(taskListBaseData);

            var LowerListBaseData = DataBase.lowerThan(taskListBaseData);

            DataBase.print(higherListBaseData, LowerListBaseData);


            Console.WriteLine("\n============== LIST ==============\n");


            listBinder ListBind = new listBinder();

            workWithList ListBase = new workWithList(ListBind.bind());


            ListBase.print(ListBase.highThan(), ListBase.lowerThan());


            Console.Read();

        }
    }
}

//1. Сделать отдельный класс для Биндера + Принт, потому что не вписываются в основной фнкционал.

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