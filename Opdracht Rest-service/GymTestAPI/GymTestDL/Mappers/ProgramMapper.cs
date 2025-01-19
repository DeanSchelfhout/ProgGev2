using GymTestBL.Models;
using GymTestDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestDL.Mappers
{
    public static class ProgramMapper
    {
        public static ProgramModel MapToBL(ProgramModelEF db)
        {
            try
            {
                return new ProgramModel(
                    db.ProgramCode,
                    db.Name,
                    db.Target,
                    db.StartDate,
                    db.MaxMembers
                    );
            }
            catch (Exception)
            {
                throw new Exception("MapProgramModel - MapToBL");
            }
        }
        public static ProgramModelEF MapToDL(ProgramModel p)
        {
            try
            {
                return new ProgramModelEF(
                    p.ProgramCode,
                    p.Name,
                    p.Target,
                    p.StartDate,
                    p.MaxMembers
                   );
            }
            catch (Exception)
            {

                throw new Exception("MapProgramModel - MapToDL");
            }
        }
    }
}
