using System.Collections.Generic;

namespace DTO
{
    public class DtoMeassuredDataFs
    {
        public List<double> MeassureDoubles { get; set; }

        public DtoMeassuredDataFs()
        {
            MeassureDoubles = new List<double>();
        }
    }
}