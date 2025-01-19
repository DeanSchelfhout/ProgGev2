using static GymTestBL.Models.Member;

namespace GymTestAPI.DTO
{
    public class MemberDTO
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Interests { get; set; }
        public memberType MemberType { get; set; }
    }
}
