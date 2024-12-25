using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAPI_CRUD.Logger
{
    public interface IMyLogger
    {
        void Log(string message);
    }
}