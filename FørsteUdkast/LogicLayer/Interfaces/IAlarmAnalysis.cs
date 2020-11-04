using DTO;

namespace LogicLayer
{
    public interface IAlarmAnalysis
    {
        public double MAP { get; set; }

        public bool GetAlarm(DtoMeassuredDataFs _meassuredData);

        public bool isFallDetected();
    }
}