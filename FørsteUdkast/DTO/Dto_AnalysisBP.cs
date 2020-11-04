using System;

namespace DTO
{
    public class Dto_AnalysisBP
    {
        public double Systolic { get; set; }
        public double Diastolic { get; set; }
        public int Pulse { get; set; }
        public bool Alarm { get; set; }
        public double MAP { get; set; }
        public DateTime Date { get; set; }
        public Dto_AnalysisBP(double systolic, double diastolic, int pulse, bool alarm, double map, DateTime date)
        {
            Systolic = systolic;
            Diastolic = diastolic;
            Pulse = pulse;
            Alarm = alarm;
            Date = date;

        }
    }
}