using System;
using System.Collections.Concurrent;
using System.Threading;
using DTO;

namespace LogicLayer
{
    public class Analyse : IAnalyse
    {

        private BlockingCollection<DtoBpRaw> _dataQueue2;
        private BlockingCollection<Dto_AnalysisBP> _dataQueue3;
        private DtoMeassuredDataFs OneSecondOfData;

        //Alle analysemetoderne
        public IAlarmAnalysis Alarmanalysis { get; set; }
        public IPulseAnalysis PulseAnalysis { get; set; }
        public IDiastolicAndSystolicAnalysis DiaAndSystolicAnalysis { get; set; }
        private Dto_AnalysisBP readingAnalysis;

        private int pulse;
        private double systolic;
        private double diastolic;
        private bool alarm;
        private double MAP;
        
        public StaticVariables StaticVariables { get; set; }

        public Analyse(BlockingCollection<DtoBpRaw> dataQueue2, BlockingCollection<Dto_AnalysisBP> dataQueue3)
        {
            _dataQueue2 = dataQueue2;
            _dataQueue3 = dataQueue3;
            OneSecondOfData = new DtoMeassuredDataFs();
            PulseAnalysis = new PulseAnalysis();

        }
        public void AnalyseMeasurement()
        {
            while (!_dataQueue2.IsCompleted)
            {
                try
                {

                    var container =  _dataQueue2.Take(); // .Take Tager måske alle DTO objekterne og fjerner dem fra listen.

                    foreach (var measurement in container.Measurement)
                    {
                        OneSecondOfData.MeassureDoubles.Add(measurement);
                    }

                    if (OneSecondOfData.MeassureDoubles.Count >= StaticVariables.SampleFrequense)
                    {
                        alarm = Alarmanalysis.GetAlarm(OneSecondOfData);
                        pulse = PulseAnalysis.GetPulse(OneSecondOfData);
                        DiaAndSystolicAnalysis.GetSysAndDiastolic(OneSecondOfData);
                        diastolic = DiaAndSystolicAnalysis.Diastolic;
                        systolic = DiaAndSystolicAnalysis.Systolic;
                        MAP = Alarmanalysis.MAP;

                        //Opdaterer readingAnalysis DTO'en
                        readingAnalysis = new Dto_AnalysisBP(systolic, diastolic, pulse, alarm, MAP, DateTime.Now);
                        // DEN SKAL BÅDE VÆRE Producer OG CONSUMER
                        //DEN FÅR SIN DATA SOM CONSUMER fra EN PRODUCER; MEN DEN GIVER DET VIDERE SOM EN PRODUCER, JA DET ER GODT TÆNKT; ELLER MÅSKE MEGET DUMT

                        _dataQueue3.Add(readingAnalysis);
                        _dataQueue3.CompleteAdding();

                        //Tømmer mit ene sekund så dette er klar til at blive fyldt op igen
                        OneSecondOfData.MeassureDoubles.Clear();
                    }
                }
                catch (InvalidOperationException)
                {

                }

                Thread.Sleep(10);

            }
        }

    }
}
