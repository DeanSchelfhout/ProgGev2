using GymTestBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestBL.Interfaces
{
    public interface IRunningSessionRepository
    {
        public RunningSessionMain GetRunningSession(int id);
    }
}
