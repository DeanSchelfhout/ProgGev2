using GymTestBL.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace GymTestDL.Models
{
    public class MemberEF
    {
        public MemberEF()
        {
        }

        public MemberEF(int memberId, string firstName, string lastName, string email, string address, DateTime birthday, List<string> interests, ICollection<CyclingSessionEF> cyclingSessions, ICollection<RunningSessionMainEF> runningSessions, ICollection<ReservationEF> reservations, ICollection<ProgramModelEF> programs,string memberType)
        {
            MemberId = memberId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            Birthday = birthday;
            Interests = interests;
            CyclingSessions = cyclingSessions;
            RunningSessions = runningSessions;
            Reservations = reservations;
            Programs = programs;
            MemberType = memberType;
        }
        [Key]
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Interests { get; set; }
        public string MemberType { get; set; }

        // Navigation Properties
        public ICollection<CyclingSessionEF> CyclingSessions { get; set; }
        public ICollection<RunningSessionMainEF> RunningSessions { get; set; }
        public ICollection<ReservationEF> Reservations { get; set; }
        public ICollection<ProgramModelEF> Programs { get; set; }
    }

}
