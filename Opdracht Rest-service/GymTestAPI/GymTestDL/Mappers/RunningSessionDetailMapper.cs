using GymTestBL.Models;
using GymTestDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestDL.Mappers
{
    public static class RunningSessionDetailMapper
    {
        public static RunningSessionDetail MapToBL(RunningSessionDetailEF db)
        {
            try
            {
                return new RunningSessionDetail(
                    db.RunningSessionId,
                    db.SeqNr,
                    db.IntervalTimes,
                    db.IntervalSpeeds
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("RunningSessionDetailMapper - MapToBL",ex);
            }
        }
        public static RunningSessionDetailEF MapToDL(RunningSessionDetail r)
        {
            try
            {
                return new RunningSessionDetailEF(
                    r.RunningSessionId,
                    r.SeqNr,
                    r.IntervalTimes,
                    r.IntervalSpeeds
                   );
            }
            catch (Exception ex)
            {

                throw new Exception("RunningSessionDetailMapper - MapToDL",ex);
            }
        }
    }
}
