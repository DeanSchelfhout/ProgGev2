using System.ComponentModel.DataAnnotations;

namespace GymTestDL.Models
{
    public class CyclingSessionEF
    {
        public CyclingSessionEF(int cyclingSessionId, DateTime date, TimeSpan duration, float avgWatt, float maxWatt, float avgCadence, float maxCadence, string trainingType, string comment, int memberId)
        {
            CyclingSessionId = cyclingSessionId;
            Date = date;
            Duration = duration;
            AvgWatt = avgWatt;
            MaxWatt = maxWatt;
            AvgCadence = avgCadence;
            MaxCadence = maxCadence;
            TrainingType = trainingType;
            Comment = comment;
            MemberId = memberId;
        }

        [Key]
        public int CyclingSessionId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public float AvgWatt { get; set; }
        public float MaxWatt { get; set; }
        public float AvgCadence { get; set; }
        public float MaxCadence { get; set; }
        public string TrainingType { get; set; }
        public string? Comment { get; set; }
        public int MemberId { get; set; }

        // Navigation Properties
        public MemberEF Member { get; set; }
    }

}
