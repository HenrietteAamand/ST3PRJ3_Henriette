using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LogicLayer;
using DTO;

namespace LogicLayer.Test.Unit
{
    class DiastolicAndSystolicAnalysis_Test_Unit
    {
        private DiastolicAndSystolicAnalysis uut;
        private StaticVariables staticVariables;

        [SetUp]
        public void Setup()
        {
            staticVariables = new StaticVariables();
            uut = new DiastolicAndSystolicAnalysis(staticVariables);
        }
        
        //Syntaks: metodenavn_Scenarie_forventetResultat
        [Test]
        public void GetSysAndDiastolic_addMeassurementWithThreePeriods_return10OverMinus10()
        {
            double systolic = 0;
            double diastolic = 0;
            double map = 0;
            DtoMeassuredDataFs dtoMeassured1 = new DtoMeassuredDataFs();
            dtoMeassured1.MeassureDoubles.AddRange(ThreePeriods(10));
            uut.GetSysAndDiastolic(dtoMeassured1, map);

            systolic = uut.Systolic;
            diastolic = uut.Diastolic;

            Assert.That(systolic, Is.EqualTo(10));
            Assert.That(diastolic, Is.EqualTo(-10));
        }
        
        
        // Denne metode genererer et signal man kan bruge til at teste metoden
        private List<double> ThreePeriods(double systolic)
        {
            double limitOne = systolic + 2;
            double limitTwo = systolic + 1;

            List<double> vaerdier = new List<double>();
            int i = 0;


            // Første del
            while (i < limitOne)
            {
                vaerdier.Add(i);
                i++;
            }

            while (i > (-1 * limitOne))
            {
                vaerdier.Add(i);
                i--;
            }

            while (i <= 0)
            {
                vaerdier.Add(i);
                i++;
            }

            // Anden del
            while (i < limitTwo)
            {
                vaerdier.Add(i);
                i++;
            }

            while (i > (-1 * limitTwo))
            {
                vaerdier.Add(i);
                i--;
            }

            while (i <= 0)
            {
                vaerdier.Add(i);
                i++;
            }

            //Sidste del
            while (i < systolic)
            {
                vaerdier.Add(i);
                i++;
            }

            while (i > (-1 * systolic))
            {
                vaerdier.Add(i);
                i--;
            }

            while (i <= 0)
            {
                vaerdier.Add(i);
                i++;
            }




            return vaerdier;
        }

    }
}
