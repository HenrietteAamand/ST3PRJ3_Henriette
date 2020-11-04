using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace LogicLayer
{
    public interface IDiastolicAndSystolicAnalysis
    {
        public StaticVariables StaticVariables { get; set; }
        public double Diastolic { get; set; }
        public double Systolic { get; set; }
        public void GetSysAndDiastolic(DtoMeassuredDataFs meassuredData);
    }
}
