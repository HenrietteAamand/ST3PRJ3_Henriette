using DTO;

namespace EmilsLejeplads
{
    public interface IPatientInfo
    {
        public object GetPatientInfo();
        public string GetSSR(string ambulanceID);
        public int GetAmbulanceNr(string ambulanceID);

    }
}