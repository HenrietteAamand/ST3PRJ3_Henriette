using System;
using System.Collections.Generic;
using NUnit.Framework;
using DTO;

namespace LogicLayer.Test.Unit
{
    class PulseAnalyses_Test_Unit
    {

        private PulseAnalysis uut;
        private StaticVariables staticVariables;

        [SetUp]
        public void Setup()
        {
            staticVariables = new StaticVariables();
            uut = new PulseAnalysis(staticVariables);
        }

        //Syntaks: metodenavn_Scenarie_forventetResultat
        [Test]
        public void GetPulse_addSignalWithPuls90AndMAP100_returnpuls90()
        {
            int pulse;
            DtoMeassuredDataFs dtoMeassured1 = new DtoMeassuredDataFs();
            dtoMeassured1.MeassureDoubles.AddRange(sinusValue(90,100));
            pulse = uut.GetPulse(dtoMeassured1, 100);

            Assert.That(pulse, Is.EqualTo(90));
        }

        private List<double> sinusValue(double wishedPuls, double map)
        {
            double constant = wishedPuls / 60;
            double ts = 1.0 / staticVariables.SampleFrequense;

            List<double> sinusvaerdier = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 2* Math.PI*ts*constant ) * 15 + 100);
            }
            
            return sinusvaerdier;
        }
    }
}
