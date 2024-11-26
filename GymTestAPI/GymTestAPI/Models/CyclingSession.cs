namespace GymTestAPI.Models
{
    public class CyclingSession
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AvgWatt { get; set; }
        public int MaxWatt { get; set; }
        public int AvgCadence { get; set; }
        public int MaxCadence { get; set; }
        public string TrainingType { get; set; }
        public string Comment { get; set; }
        public int MemberId { get; set; }

        public Member Member { get; set; 
    }
}
