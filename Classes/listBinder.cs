using LinqToList.Classes.Lists;
using LinqToList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToList.Classes
{
    public class listBinder : IBinder
    {
        public List<sourceList> bind()
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

    }
}
