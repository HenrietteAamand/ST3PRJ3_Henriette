using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics;

namespace LogicLayer
{
    public class ClaibrationCalculator
    {
        public double haeldning { get; set; }
        public double skaerning { get; set; }
        public List<double> FromLastCalibration { get; set; }
        //Disse blodtryk skal der kalibreres efter
        private List<double> justToAddList = new List<double>{0,30,60,150,240,300,-30};


        public ClaibrationCalculator()
        {
            FromLastCalibration.AddRange(justToAddList);
        }

        public void CalculateCoefficients(List<double> meassuredValues)
        {

        }

    }
}
