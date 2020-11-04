using System;
using DataLayer;

namespace LogicLayer
{
    public class ZeroPointAdjustment : IZeroPointAdjustment
    {
        public ITransducer Transducer { get; set; }

        public double GetZeroPoint()
        {
            double readPreassure = Transducer.ReadPreassure();
            double readPreassureInmmHg = convertTommHg(readPreassure);

            return readPreassureInmmHg;
        }

        private double convertTommHg(double meassured)
        {
            throw new NotImplementedException();
        }
    }
}