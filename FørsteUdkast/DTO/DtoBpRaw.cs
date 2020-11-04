using System;
using System.Collections.Generic;

namespace DTO
{
    public class DtoBpRaw
    {
        public List<double> Measurement { get; set; }
        public DateTime Date { get; set; }

        public DtoBpRaw(List<double> measurement, DateTime date)
        {
            Measurement = measurement;
            Date = date;

        }
    }
}
