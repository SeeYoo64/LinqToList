using LinqToList.Classes;

namespace LinqToList
{
    class Program
    {

        static async Task Main(string[] args)
        {

            var taskList = workWithList.bind();

            var higherList = workWithList.highThan(taskList);

            var LowerList = workWithList.lowerThan(taskList);

            workWithList.print(higherList, LowerList);
            

            Console.Read();
        }
    }
}