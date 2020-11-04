namespace LogicLayer
{
    public class StaticVariables
    {
        public int SampleFrequense { get; private set; }
        public int DoubleNyquist { get; private set; }

        //Den tid hvormed vi beregner om der er fald i blodtryk
        public int Alarmperiod { get; private set; }

        public int PersentageFall { get; set; }


        public StaticVariables()
        {
            DoubleNyquist = 120;
            SampleFrequense = DoubleNyquist* 10; // = 1200
            Alarmperiod = 5;
            PersentageFall = 5;

        }
    }
}