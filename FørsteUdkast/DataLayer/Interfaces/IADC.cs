namespace DataLayer
{
    public interface IADC
    {
        public double ReadPressure();
        public double ReadBatteryLevel();
    }
}