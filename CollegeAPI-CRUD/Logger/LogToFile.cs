using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAPI_CRUD.Logger
{
    public class LogToFile : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}