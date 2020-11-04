using System.Collections.Generic;
using System.Data;
using DTO;

namespace LogicLayer
{
    public class PulseAnalysis : IPulseAnalysis
    {
        private List<double> MAPList = new List<double>();
        private List<double> MeassurementsList = new List<double>();
        private double hysteresisLow;
        private double hysteresisHigh;
        private double mAP;
        public StaticVariables StaticVariables { get; set; }
        private int puls = 0;
        

       /*
        * Denne klasse skal beregne pulsen. Jeg vil gerne have data for 10 sekunder at regne på. Derfor skal jeg gemme 10 DTOMeasseredDataFS, og ud fra dette beregne pulsen
        * For at detektere pulsen har jeg brug for at lave digital hysterese, men på tal hvor jeg ikke kender mit normale max..
        * Måske kan man bestemme MAP og ud fra dette sige, at når vi måler 10 mmHG over dette, så må der være en puls, og først når vi er kommet 10 mmHG
        * under MAP kan vi registrere ny puls?
        *
        */

        public int GetPulse(DtoMeassuredDataFs meassuredData)
        {
            bool canRegisterPulse = true;
            puls = 0;
            GetMAP(meassuredData);
            hysteresisLow = mAP - 5;
            hysteresisHigh = mAP + 5;

            //Opdaterer MeassurementList
            if (MeassurementsList.Count >= StaticVariables.SampleFrequense * 10)
            {
                MeassurementsList.RemoveRange(0,120);
            }
            MeassurementsList.AddRange(meassuredData.MeassureDoubles);

            //Finder antal puls - algoritme
            foreach (double meassurement in MeassurementsList)
            {
                if (meassurement > hysteresisHigh && canRegisterPulse == true)
                {
                    canRegisterPulse = false;
                    puls++;
                }

                if (meassurement < hysteresisLow)
                {
                    canRegisterPulse = true;
                }
            }

            //Omregner fra de trregistrerede pulse, til antal pulse pr minut
            puls = puls * 6;

            return puls;
        }

        public double GetMAP(DtoMeassuredDataFs meassuredData)
        {
            //Vi beregner mean arterial bloodpreassure over 10 perioder. De gemmes i en liste
            double singleMAP = 0;

            //Beregner MAP af de nyeste data
            foreach (double bloodPrreassure in meassuredData.MeassureDoubles)
            {
                singleMAP += bloodPrreassure;
            }
            singleMAP = singleMAP / meassuredData.MeassureDoubles.Count;

            //Gemmer det nye MAP i listen
            if (MAPList.Count >= 10)
            {
                MAPList.RemoveAt(0);
            }
            MAPList.Add(singleMAP);

            //Beregner nu MAP for de seneste fire målinger
            mAP = 0;
            foreach (double MAP in MAPList)
            {
                mAP += MAP;
            }

            mAP = mAP / MAPList.Count;

            return mAP;
        }
    }
}