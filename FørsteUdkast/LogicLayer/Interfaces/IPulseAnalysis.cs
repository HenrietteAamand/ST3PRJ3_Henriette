using DTO;

namespace LogicLayer
{
    public interface IPulseAnalysis
    {
        public int GetPulse(DtoMeassuredDataFs meassuredData);
    }
}