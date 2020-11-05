using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using DTO;

namespace LogicLayer
{
    public class AlarmAnalysis : IAlarmAnalysis
    {
        private List<double> LastSavedMeassurements = new List<double>();
        private List<double> map = new List<double>();
        private List<double> oldMAP = new List<double>();
        private List<double> ioverskud = new List<double>();
        public double MAP { get; set; }
        
        private double newMAP;
        private bool isFall;
        private double persentage;

        private bool isOverHys = false;
        private StaticVariables staticVariables;
        
        // Variabler der afhænger af staticVariables;
        private double hysteresisLow;
        private double hysteresisHigh;
        private int alarmperiod;
        private int hysteresisSpring;

        public AlarmAnalysis(StaticVariables _staticVariables)
        {
            MAP = 0;
            staticVariables = _staticVariables;
            alarmperiod = staticVariables.Alarmperiod;
            hysteresisSpring = staticVariables.hysteresis;
            persentage = staticVariables.Persentage;

        }

        // Tilføjer et sekunds måledata til min lange liste.
        public bool GetAlarm(DtoMeassuredDataFs _meassuredData)
        {
            //Sørger for at der kun gemmes 3 målinger/3 sekunder ad gangen. Jeg kopierer dem over i en liste med målinger:
            if (LastSavedMeassurements.Count >= _meassuredData.MeassureDoubles.Count * alarmperiod)
            {
                LastSavedMeassurements.RemoveRange(0, _meassuredData.MeassureDoubles.Count - 1);
            }

            LastSavedMeassurements.AddRange(_meassuredData.MeassureDoubles);

            {
                //Bestem MAB ud fra hvad jeg har i listen - kunne måske være en idé at give med som parameter i metoden i stedet?
                MAP = 0;
                foreach (double bloodpreassure in LastSavedMeassurements)
                {
                    MAP += bloodpreassure;
                }

                MAP = MAP / LastSavedMeassurements.Count;
            }

            
            hysteresisHigh = MAP + hysteresisSpring;
            hysteresisLow = MAP - hysteresisSpring;

            List<int> index = new List<int>();

            isOverHys = false;
            //Her bestemmes ved hvilke index vi registrerer høj
            for (int i = 0; i < LastSavedMeassurements.Count; i++)
            {
                if (LastSavedMeassurements[i] >= hysteresisHigh && isOverHys == false)
                {
                    index.Add(i);
                    isOverHys = true;
                }

                else if (LastSavedMeassurements[i] <= hysteresisLow && isOverHys == true)
                {
                    isOverHys = false;
                }
            }

            MAP = 0;
            //Beregner nu MAP for de nyeste målinger
            double forHowlong = index[index.Count - 1];
            int counter = 1;
            for (int i = index[0]; i < index[index.Count - 1]; i++)
            {
                MAP += LastSavedMeassurements[i];
                if (i == index[counter])
                {
                    MAP = MAP / (index[counter] - index[counter - 1]);
                    if (oldMAP.Count >= alarmperiod)
                    {
                        oldMAP.RemoveAt(0);
                    }
                    oldMAP.Add(MAP);
                    MAP = 0;
                    counter++;
                }
            }

            isFall = false;
            double oldMap = oldMAP[0];
            
            foreach (double map in oldMAP)
            {
                if (map <= oldMap * persentage)
                {
                    isFall = true;
                }

                else
                {
                    isFall = false;
                }

                oldMap = map;
            }

            return isFall;
        }

    }
}