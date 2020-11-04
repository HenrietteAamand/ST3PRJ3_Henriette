using DTO;
using System.Collections.Generic;
using System.Linq;

namespace LogicLayer
{
    public class DiastolicAndSystolicAnalysis : IDiastolicAndSystolicAnalysis
    {

        private List<double> MAPList = new List<double>();
        private List<double> MeassurementsList = new List<double>();
        private List<double> diastolicValues = new List<double>();
        private List<double> systolicValues = new List<double>();

        private double hysteresisLow;
        private double hysteresisHigh;
        private double mAP;

        public StaticVariables StaticVariables { get; set; }
        public double Diastolic { get; set; }
        public double Systolic { get; set; }

        public void GetSysAndDiastolic(DtoMeassuredDataFs meassuredData)
        {
            GetMAP(meassuredData);
            hysteresisLow = mAP - 5;
            hysteresisHigh = mAP + 5;
            Diastolic = mAP;
            Systolic = mAP;

            //Opdaterer MeassurementList.
            //Bruger 3 for at være sikker på, at sekvensen indeholder både en systolisk værdi og en diastolisk værdi
            if (MeassurementsList.Count >= StaticVariables.SampleFrequense * 3)
            {
                MeassurementsList.RemoveRange(0, 120);
            }
            MeassurementsList.AddRange(meassuredData.MeassureDoubles);

            //Finder diastolisk og systolisk værdier - algoritme
            foreach (double meassurement in MeassurementsList)
            {
                if (meassurement < Diastolic)
                {
                    Diastolic = meassurement;
                }

                if (meassurement > hysteresisHigh)
                {
                    diastolicValues.Add(Diastolic);
                    Diastolic = mAP;
                }

                if (meassurement > Systolic)
                {
                    Systolic = meassurement;
                }

                if (meassurement < hysteresisLow)
                {
                    systolicValues.Add(Systolic);
                    Systolic = mAP;
                }
            }

            // tager den sidste værdi og gemmer denne. 
            Systolic = systolicValues.Last();
            Diastolic = diastolicValues.Last();

            // Tømmer listetn
            systolicValues.Clear();
            diastolicValues.Clear();

        }

        public double GetMAP(DtoMeassuredDataFs meassuredData)
        {
            //Vi beregner mean arterial bloodpreassure over 3 perioder. De gemmes i en liste
            double singleMAP = 0;

            //Beregner MAP af de nyeste data
            foreach (double bloodPrreassure in meassuredData.MeassureDoubles)
            {
                singleMAP += bloodPrreassure;
            }
            singleMAP = singleMAP / meassuredData.MeassureDoubles.Count;

            //Gemmer det nye MAP i listen
            if (MAPList.Count >= 3)
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