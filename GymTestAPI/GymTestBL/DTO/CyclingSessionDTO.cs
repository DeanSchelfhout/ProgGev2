﻿namespace GymTestBL.DTO
{
    public class CyclingSessionDTO
    {
        public int CyclingSessionId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public float AvgWatt { get; set; }
        public float MaxWatt { get; set; }
        public float AvgCadence { get; set; }
        public float MaxCadence { get; set; }
        public string TrainingType { get; set; }
        public string Comment { get; set; }
        public int MemberId { get; set; }
        public string Impact {  get; set; }
    }
}
