using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Transducer : ITransducer
    {
        public IADC adc { get; set; }

        //Dette er de konstanter, som vi beregner efter LSS under kalibreringen
        public double hældning { get; set; }
        public double skæring { get; set; }

        public double ReadPreassure()
        {
            double meassured = adc.ReadPressure();
            return convertTommHg(meassured);
        }

        
        //Dette kunne godt være et potentielt svagt punkt i forhold til OCP
        // - skulle måske flyttes ud som interfaces, hvor man kan ændre hvivlken type udvikling man bruger (lineær, eksponentiel osv.
        private double convertTommHg(double meassured)
        {
            double bloodpeassure = hældning * meassured + skæring;
            return bloodpeassure;
        }

        public double ReadElectricalSize()
        {
            double meassured = adc.ReadPressure();
            return meassured;
        }
    }
}
