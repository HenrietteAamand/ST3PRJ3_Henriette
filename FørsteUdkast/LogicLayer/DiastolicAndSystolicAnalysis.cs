using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;

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
        private bool canAddDiastolic = false;
        private bool canAddSystolic = false;
        private int diastolicIndex;
        private int systolicIndex;

        private StaticVariables StaticVariables;
        public double Diastolic { get; set; }
        public double Systolic { get; set; }

        public DiastolicAndSystolicAnalysis(StaticVariables staticVariables)
        {
            StaticVariables = staticVariables;
        }

        public void GetSysAndDiastolic(DtoMeassuredDataFs meassuredData, double map)
        {
            mAP = map;
            hysteresisLow = mAP - 5;
            hysteresisHigh = mAP + 5;
            Diastolic = mAP;
            Systolic = mAP;


            //Opdaterer MeassurementList.
            //Bruger 3 for at være sikker på, at sekvensen indeholder både en systolisk værdi og en diastolisk værdi
            if (MeassurementsList.Count >= StaticVariables.SampleFrequense * 3)
            {
                MeassurementsList.RemoveRange(0, meassuredData.MeassureDoubles.Count-1);
            }
            MeassurementsList.AddRange(meassuredData.MeassureDoubles);

            //Finder diastolisk og systolisk værdier - algoritme
            for (int i = 0; i < MeassurementsList.Count; i++)
            {
                if (MeassurementsList[i] < Diastolic)
                {
                    Diastolic = MeassurementsList[i];
                    diastolicIndex = i;
                    canAddDiastolic = true;
                }

                else if (MeassurementsList[i] > hysteresisHigh && canAddDiastolic == true)
                {
                    diastolicValues.Add(Diastolic);
                    canAddDiastolic = false;
                    Diastolic = mAP;
                }

                else if (MeassurementsList[i] > Systolic)
                {
                    Systolic = MeassurementsList[i];
                    systolicIndex = i;
                    canAddSystolic = true;
                }

                else if (MeassurementsList[i] < hysteresisLow && canAddSystolic == true)
                {
                    systolicValues.Add(Systolic);
                    Systolic = mAP;
                    canAddSystolic = false;
                }

            }

            if (MeassurementsList.Count >= systolicIndex + 3 && MeassurementsList.Count >= diastolicIndex + 3)
            {
                //Tjekker om jeg er har at gøre med en diastolisk værdi, men ikke er kommet over min øvre hysteresegrænse endnu
                if (Diastolic != diastolicValues.Last() && Diastolic < MeassurementsList[diastolicIndex+3])
                {
                    diastolicValues.Add(Diastolic);
                }

                if (Systolic != systolicValues.Last() && Systolic > MeassurementsList[systolicIndex + 3])
                {
                    systolicValues.Add(Systolic);
                }
            }


            // tager den sidste værdi og gemmer denne. 
            Systolic = systolicValues.Last();
            Diastolic = diastolicValues.Last();

            // Tømmer listetn
            systolicValues.Clear();
            diastolicValues.Clear();

        }
    }
}