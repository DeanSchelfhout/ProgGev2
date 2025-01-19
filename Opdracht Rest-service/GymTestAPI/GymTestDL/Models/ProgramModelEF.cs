using System.ComponentModel.DataAnnotations;

namespace GymTestDL.Models
{
    public class ProgramModelEF
    {
        public ProgramModelEF()
        {
        }

        public ProgramModelEF(int programCode, string name, string target, DateTime startDate, int maxMembers)
        {
            ProgramCode = programCode;
            Name = name;
            Target = target;
            StartDate = startDate;
            MaxMembers = maxMembers;
        }

        [Key]
        public int ProgramCode { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
        public DateTime StartDate { get; set; }
        public int MaxMembers { get; set; }

        // Navigation Properties
        public ICollection<MemberEF> Members{ get; set; }
    }

}
