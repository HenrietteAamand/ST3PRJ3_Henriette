using System;
using System.Collections.Generic;
using DTO;

namespace LogicLayer
{
    public class MapCalculator5Periods : IMapCalculater
    {
        private double MAP;
        private  List<double> old5meassurements = new List<double>();

        public double calculateMAP(DtoMeassuredDataFs meassuredDataFs)
        {
            MAP = 0;

            //Tilføjer den nyeste måling til old5meassurements 
            if (old5meassurements.Count >= meassuredDataFs.MeassureDoubles.Count * 5)
            {
                old5meassurements.RemoveRange(0,meassuredDataFs.MeassureDoubles.Count-1);
            }
            old5meassurements.AddRange(meassuredDataFs.MeassureDoubles);

            //Bestem MAB ud fra hvad jeg har i listen
            foreach (double bloodpreassure in old5meassurements)
            {
                MAP += bloodpreassure;
            }

            MAP = MAP / old5meassurements.Count;

            return MAP;
        }
    }
}