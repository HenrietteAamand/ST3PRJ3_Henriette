using System.Collections.Generic;
using DTO;


namespace EmilsLejeplads
{
    public interface IUdpBroadCaster
    {
        
        public void RawMeasurement();

        public void AnalizedMeasurement(List<Dto_AnalysisBP> dtoAnalysisBps);


    }
}