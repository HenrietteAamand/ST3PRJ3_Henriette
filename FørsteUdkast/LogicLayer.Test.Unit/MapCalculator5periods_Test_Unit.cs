using System;
using System.Collections.Generic;
using NUnit.Framework;
using DTO;

namespace LogicLayer.Test.Unit
{
    class MapCalculator5periods_Test_Unit
    {
        private MapCalculator5Periods uut;
        private StaticVariables staticVariables;

        [SetUp]
        public void Setup()
        {
            staticVariables = new StaticVariables();
            uut = new MapCalculator5Periods();
        }

        //Syntaks: metodenavn_Scenarie_forventetResultat
        [TestCase (80,120)]
        [TestCase(70,81)]
        [TestCase(47,81)]
        [TestCase(0,300)]
        public void calculateMAP_addXandY_returnXplusYtimes0point5(double x, double y)
        {
            double map;
            double expectedMap = (x + y) * 0.5;
            DtoMeassuredDataFs dtoMeassured1 = new DtoMeassuredDataFs();
            dtoMeassured1.MeassureDoubles.AddRange(meangenerator(x, y));
            map = uut.calculateMAP(dtoMeassured1);



            Assert.That(map, Is.EqualTo(expectedMap));
        }

        private List<double> meangenerator(double x, double y)
        {
            List<double> values = new List<double>();
            bool addX = true;
            
            for (int i = 0; i < 120; i++)
            {
                if (addX == true)
                {
                    values.Add(x);
                    addX = false;
                }
                else if(addX == false)
                {
                    values.Add(y);
                    addX = true;
                }
            }

            return values;
        }
    }
}
