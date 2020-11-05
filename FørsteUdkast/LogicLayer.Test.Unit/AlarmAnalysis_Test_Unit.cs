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
            dtoMeassured1.MeassureDoubles.AddRange(sinusValue(100, 186));
            uut.GetAlarm(dtoMeassured1);

            double fallingMeassurement = 100 - staticVariables.PersentageFall;

            DtoMeassuredDataFs dtoMeassured2 = new DtoMeassuredDataFs();
            dtoMeassured2.MeassureDoubles.AddRange(sinusValue(94, 186));
            isAlarmOn = uut.GetAlarm(dtoMeassured2);

            Assert.That(isAlarmOn, Is.True);
        }


        private List<double> sinusValue(int verticalForskydning, int længde)
        {
            List<double> sinusvaerdier = new List<double>();
            for (int i = 0; i < længde; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 0.02 * Math.PI)*15 + verticalForskydning);
            }




            return sinusvaerdier;
        }

    }

    //public class DtoMeassuredDataFs
    //{
    //    public List<double> MeassureDoubles { get; set; }

    //    public void FillListWithMeassurement(double meassured)
    //    {
    //        for (int i = 0; i < 120; i++)
    //        {
    //            MeassureDoubles.Add(meassured);
    //        }
    //    }
    //}

}
