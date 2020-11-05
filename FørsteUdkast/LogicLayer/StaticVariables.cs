namespace LogicLayer
{
    public class StaticVariables
    {
        public int SampleFrequense { get; private set; }
        public int DoubleNyquist { get; private set; }

        //Den tid hvormed vi beregner om der er fald i blodtryk
        public int Alarmperiod { get; private set; }
        public double Persentage { get; set; }
        public double PersentageFall { get; set; }
        public int hysteresis { get; set; }

        public StaticVariables()
        {
            DoubleNyquist = 120;
            SampleFrequense = DoubleNyquist* 10; // = 1200
            Alarmperiod = 3;
            PersentageFall = 5;
            Persentage = (100-PersentageFall) / 100;
            hysteresis = 5;
        }
    }
}