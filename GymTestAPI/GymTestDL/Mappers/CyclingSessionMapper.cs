using GymTestBL.Models;
using GymTestDL.Models;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestDL.Mappers
{
    public class CyclingSessionMapper
    {
        public static CyclingSession MapToBL(CyclingSessionEF db)
        {
            try
            {
                return new CyclingSession(
                    db.CyclingSessionId,
                    db.Date,
                    db.Duration,
                    db.AvgWatt,
                    db.MaxWatt,
                    db.AvgCadence,
                    db.MaxCadence,
                    db.TrainingType,
                    db.Comment,
                    db.MemberId
                    );
            }
            catch (Exception)
            {
                throw new Exception("MapCyclingSession - MapToBL");
            }
        }
        public static CyclingSessionEF MapToDL(CyclingSession s)
        {
            try
            {
                return new CyclingSessionEF(
                    s.CyclingSessionId,
                    s.Date,
                    s.Duration,
                    s.AvgWatt,
                    s.MaxWatt,
                    s.AvgCadence,
                    s.MaxCadence,
                    s.TrainingType,
                    s.Comment,
                    s.MemberId
                   );
            }
            catch (Exception)
            {

                throw new Exception("MapCyclingSession - MapToDL");
            }
        }
    }
}
