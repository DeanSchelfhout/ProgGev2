namespace GymTestAPI.Models
{
    public class RunningSessionMain
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public float AvgSpeed { get; set; }

        public Member Member { get; set; }
        public ICollection<RunningSessionDetail> RunningSessionDetails { get; set; }
    }
}
