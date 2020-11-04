using System.Collections.Generic;
using DTO;

namespace LogicLayer
{
    public class AlarmAnalysis : IAlarmAnalysis
    {
        private List<DtoMeassuredDataFs> periodOfData = new List<DtoMeassuredDataFs>();
        public StaticVariables StaticVariables { get; set; }
        public double MAP { get; set; }
        private double newMAP;
        private bool isFall;
        private double persentage;


        public AlarmAnalysis()
        {
            MAP = 0;
            persentage = (100 - StaticVariables.Alarmperiod) / 100;
        }

        // Tilføjer et sekunds måledata.
        public bool GetAlarm(DtoMeassuredDataFs _meassuredData)
        {
            if (periodOfData.Count >= StaticVariables.Alarmperiod) //Sørger for at der altid er fx 10 sekunders målin i periodOfData listen
            {
                periodOfData.RemoveAt(0);
            }
            periodOfData.Add(_meassuredData);

            isFallDetected();

            // Vi mangler her at detektere, at der har været fald tre gange i streg. Hvordan gør jeg det hurtigst og smartest?

            return isFallDetected();
        }

        //Denne metode er public udelukkende for at vi kan teste den
        public bool isFallDetected()
        {

            newMAP = 0;
            
            //Beregner gennemsnittet
            foreach (DtoMeassuredDataFs meassuredData in periodOfData)
            {
                foreach (int meassurement in meassuredData.MeassureDoubles)
                {
                    newMAP += meassurement;
                }
                newMAP = newMAP / meassuredData.MeassureDoubles.Count;
            }

            //Detekterer om der er fald
            isFall = false;
            if (newMAP <= MAP * persentage)
            {
                isFall = true;
            }
            
            MAP = newMAP;
            return isFall;
        }
    }
}