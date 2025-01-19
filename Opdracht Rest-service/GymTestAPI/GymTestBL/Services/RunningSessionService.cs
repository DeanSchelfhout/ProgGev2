using GymTestBL.Interfaces;
using GymTestBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestBL.Services
{
    public class RunningSessionService
    {
        private IRunningSessionRepository _runningSessionRepository;
        public RunningSessionService(IRunningSessionRepository runningSessionRepository)
        {
            this._runningSessionRepository = runningSessionRepository;
        }
        public RunningSessionMain GetRunningSession(int id)
        {
            try
            {
                return _runningSessionRepository.GetRunningSession(id);
            }
            catch (Exception ex)
            {

                throw new Exception("GetRunningSession", ex);
            }
        }
    }
}
