using GymTestBL.Models;
using GymTestDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static GymTestBL.Models.Member;

namespace GymTestDL.Mappers
{
    public static class MapMember
    {
        public static Member MapToBL(MemberEF db)
        {
			try
			{
				return new Member(
					db.MemberId,
					db.FirstName,
					db.LastName,
					db.Email,
					db.Address,
					db.Birthday,
					db.Interests ?? new List<string>(),
					db.CyclingSessions?.Select(CyclingSessionMapper.MapToBL).ToList()??new List<CyclingSession>(),
					db.RunningSessions?.Select(RunningSessionMapper.MapToBL).ToList()??new List<RunningSessionMain>(),
					db.Reservations?.Select(ReservationMapper.MapToBL).ToList() ?? new List<Reservation>(),
					db.Programs?.Select(ProgramMapper.MapToBL).ToList()?? new List<ProgramModel>(),
                    Enum.Parse<memberType>(db.MemberType));
			}
            catch (Exception)
			{
                throw new Exception("MapMember - MapToBL");
			}
        }
		public static MemberEF MapToDL(Member m)
		{
			try
			{
				return new MemberEF(
					m.MemberId,
					m.FirstName,
					m.LastName,
					m.Email,
					m.Address,
					m.Birthday,
					m.Interests ?? new List<string>(),
					m.CyclingSessions?.Select(CyclingSessionMapper.MapToDL).ToList() ?? new List<CyclingSessionEF>(),
					m.RunningSessions?.Select(RunningSessionMapper.MapToDL).ToList() ?? new List<RunningSessionMainEF>(),
					m.Reservations?.Select(ReservationMapper.MapToDL).ToList() ?? new List<ReservationEF>(),
					m.Programs?.Select(ProgramMapper.MapToDL).ToList() ?? new List<ProgramModelEF>(),
                    m.MemberType.ToString());
			}
			catch (Exception)
			{

				throw new Exception("MapMember - MapToDL");
			}
		}
    }
}
