using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LogicLayer;
using DTO;

namespace LogicLayer.Test.Unit
{
    class AlarmAnalysis_Test_Unit
    {
        private AlarmAnalysis uut;
        private StaticVariables staticVariables;

        [SetUp]
        public void Setup()
        {
            staticVariables = new StaticVariables();
            uut = new AlarmAnalysis(staticVariables);
        }

        //Syntaks: metodenavn_Scenarie_forventetResultat
        [Test]
        public void GetAarm_addOneFallingMeassurement_returnTrue()
        {
            bool isAlarmOn = false;
            DtoMeassuredDataFs dtoMeassured1 = new DtoMeassuredDataFs();
            dtoMeassured1.MeassureDoubles.AddRange(sinusValue(staticVariables.PersentageFall, 186));
            isAlarmOn = uut.GetAlarm(dtoMeassured1,95);

            double fallingMeassurement = 100 - staticVariables.PersentageFall;
            
            Assert.That(isAlarmOn, Is.True);
        }

        [Test]
        public void GetAarm_addNotFallingMeassurement_returnFalse()
        {
            bool isAlarmOn = false;
            DtoMeassuredDataFs dtoMeassured1 = new DtoMeassuredDataFs();
            dtoMeassured1.MeassureDoubles.AddRange(sinusValue(0, 186));
            isAlarmOn = uut.GetAlarm(dtoMeassured1, 95);

            double fallingMeassurement = 100 - staticVariables.PersentageFall;

            Assert.That(isAlarmOn, Is.False);
        }


        private List<double> sinusValue(double verticalForskydning, int længde)
        {
            List<double> sinusvaerdier = new List<double>();
            for (int i = 0; i < længde; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 0.02 * Math.PI)*15 + 100 - verticalForskydning);
            }
            for (int i = 0; i < længde; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 0.01 * Math.PI) * 15 + 100 - verticalForskydning*2);
            }
            for (int i = 0; i < længde; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 0.01 * Math.PI) * 15 + 100 - verticalForskydning * 3);
            }

            for (int i = 0; i < længde; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 0.01 * Math.PI) * 15 + 100 - verticalForskydning * 4);
            }

            return sinusvaerdier;
        }

    }
}
