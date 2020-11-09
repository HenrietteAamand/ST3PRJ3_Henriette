using System;
using System.Collections.Generic;
using System.Data;
using DTO;

namespace LogicLayer
{
    public class PulseAnalysis : IPulseAnalysis
    {
        private List<double> MAPList = new List<double>();
        private List<double> MeassurementsList = new List<double>();
        private List<double> index = new List<double>();
        private double hysteresisLow;
        private double hysteresisHigh;
        private double MAP;
        private StaticVariables StaticVariables;
        private int puls;
        private double ts;


        public PulseAnalysis(StaticVariables staticVariables)
        {
            StaticVariables = staticVariables;
            ts = 1.0 / staticVariables.SampleFrequense;
        }
        

       /*
        * Denne klasse skal beregne pulsen. Jeg vil gerne have data for 10 sekunder at regne på. Derfor skal jeg gemme 10 DTOMeasseredDataFS, og ud fra dette beregne pulsen
        * For at detektere pulsen har jeg brug for at lave digital hysterese, men på tal hvor jeg ikke kender mit normale max..
        * Måske kan man bestemme MAP og ud fra dette sige, at når vi måler 10 mmHG over dette, så må der være en puls, og først når vi er kommet 10 mmHG
        * under MAP kan vi registrere ny puls?
        *
        */

        public int GetPulse(DtoMeassuredDataFs meassuredData, double map)
        {
            MAP = map;
            bool canRegisterPulse = true;
            puls = 0;
            hysteresisLow = MAP - 5;
            hysteresisHigh = MAP + 5;
            index.Clear();

            //Opdaterer MeassurementList
            if (MeassurementsList.Count >= StaticVariables.SampleFrequense * 10)
            {
                MeassurementsList.RemoveRange(0,120);
            }
            MeassurementsList.AddRange(meassuredData.MeassureDoubles);

            //Finder antal puls - algoritme
            //Det nye er, at jeg gemmer indexet hvor der gemmes højt, og så deler trækker jeg første index fra sidste og 

            for (int i = 0; i < MeassurementsList.Count - 1; i++)
            {
                if (MeassurementsList[i] >= hysteresisHigh && canRegisterPulse == true)
                {
                    canRegisterPulse = false;
                    index.Add(i);
                }
                else if (MeassurementsList[i] <= hysteresisLow)
                {
                    canRegisterPulse = true;
                }
            }

            //Omregner fra de registrerede pulse, til antal pulse pr minut
            double tiden = (index[index.Count - 1] - index[0]) * ts;
            puls = Convert.ToInt32(((index.Count - 1) / tiden) * 60);
            return puls;
        }
    }
}