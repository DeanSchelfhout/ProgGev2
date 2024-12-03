using System.ComponentModel.DataAnnotations;

namespace GymTestAPI.Models
{
    public class RunningSessionMain
    {
        [Key]
        public int RunningSessionId { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public TimeSpan Duration { get; set; }
        public float AvgSpeed { get; set; }

        // Navigation Properties
        public Member Member { get; set; }
        public ICollection<RunningSessionDetail> Details { get; set; }
    }

}
