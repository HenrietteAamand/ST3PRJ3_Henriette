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
            uut = new AlarmAnalysis();
            uut.StaticVariables = staticVariables;
        }

        //Syntaks: metodenavn_Scenarie_forventetResultat
        [Test]
        public void GetAarm_addOneFallingMeassurement_returnTrue()
        {
            bool isAlarmOn = false;
            DtoMeassuredDataFs dtoMeassured = new DtoMeassuredDataFs();
            dtoMeassured.MeassureDoubles.Add(100);
            uut.GetAlarm(dtoMeassured);

            double fallingMeassurement = 100 - staticVariables.PersentageFall;

            dtoMeassured.MeassureDoubles.Add(fallingMeassurement);
            isAlarmOn = uut.GetAlarm(dtoMeassured);

            Assert.That(isAlarmOn, Is.True);
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
