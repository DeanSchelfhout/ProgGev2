using GymTestBL.Models;
using GymTestDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestDL.Mappers
{
    public class RunningSessionMapper
    {
        public static RunningSessionMain MapToBL(RunningSessionMainEF db)
        {
            try
            {
                return new RunningSessionMain(
                    db.RunningSessionId,
                    db.Date,
                    db.MemberId,
                    db.Duration,
                    db.AvgSpeed,
                    db.Details?.Select(RunningSessionDetailMapper.MapToBL).ToList() ?? new List<RunningSessionDetail>()
                    );
            }
            catch (Exception)
            {
                throw new Exception("MapRunningSession - MapToBL");
            }
        }
        public static RunningSessionMainEF MapToDL(RunningSessionMain r)
        {
            try
            {
                return new RunningSessionMainEF(
                    r.RunningSessionId,
                    r.Date,
                    r.MemberId,
                    r.Duration,
                    r.AvgSpeed,
                    r.Details?.Select(RunningSessionDetailMapper.MapToDL).ToList() ?? new List<RunningSessionDetailEF>()
                   );
            }
            catch (Exception)
            {

                throw new Exception("MapRunningSession - MapToDL");
            }
        }
    }
}
