namespace GymTestBL.Models
{
    public class Member
    {
        public enum memberType
        {
            Bronze,
            Silver,
            Gold
        }
        public Member(int? memberId, string firstName, string lastName, string email, string address, DateTime birthday, List<string> interests, List<CyclingSession> cyclingSessions, List<RunningSessionMain> runningSessions, List<Reservation> reservations, List<ProgramModel> programs, memberType memberType)
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

        public Member(int? memberId, string firstName, string lastName, string email, string address, DateTime birthday, List<string> interests, memberType memberType)
        {
            MemberId = memberId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            Birthday = birthday;
            Interests = interests;
            MemberType = memberType;
        }

        public int? MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Interests { get; set; }
        public memberType MemberType { get; set; }

        // Navigation Properties
        public List<CyclingSession> CyclingSessions { get; set; }
        public List<RunningSessionMain> RunningSessions { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<ProgramModel> Programs { get; set; }
    }

}
