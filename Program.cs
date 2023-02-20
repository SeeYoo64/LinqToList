using LinqToList.Classes;

namespace LinqToList
{
    class Program
    {

        static async Task Main(string[] args)
        {

            var taskList = new List<Bebra>()
            {
                new Bebra("139/30", 10),
                new Bebra("167/20", 10),
                new Bebra("167/30", 15),
                new Bebra("23/30", 64),
                new Bebra("232/25", 49), // 5
                new Bebra("236/20", 68),
                new Bebra("236/30", 32),
                new Bebra("237/30", 54),
                new Bebra("238/30", 52),
                new Bebra("241/20", 44), // 10 (9)
                new Bebra("241/30", 34),
                new Bebra("241/40", 8),
                new Bebra("25/30", 6) ,
                new Bebra("251/30", 6) ,
                new Bebra("254/30", 10) , // 15
                new Bebra("270/30", 6) ,
                new Bebra("33/20", 6) ,
                new Bebra("342/40", 6) ,
                new Bebra("35/20", 1) ,
                new Bebra("36/20", 2) , // 20
                new Bebra("38/20", 5) ,
                new Bebra("39/30", 4) ,
                new Bebra("390/30", 4) ,
                new Bebra("390/40", 50) ,
                new Bebra("42/30", 22) , // 25
                new Bebra("44/30", 62) ,
                new Bebra("45/30", 6) ,
                new Bebra("46/30", 14) ,
                new Bebra("54/25", 66) ,
                new Bebra("59/20", 52),  // 30
                new Bebra("68/30", 1) ,
                new Bebra("95/30", 48),
                new Bebra("97/30", 10) , // 33
            };


            var higherList = workWithList.highThan(taskList);

            var LowerList = workWithList.lowerThan(taskList);

            workWithList.print(higherList, LowerList);
            

            Console.Read();
        }
    }
}