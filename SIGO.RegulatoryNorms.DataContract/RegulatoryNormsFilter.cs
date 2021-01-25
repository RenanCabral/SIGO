using System;

namespace SIGO.RegulatoryNorms.DataContracts
{
    public class RegulatoryNormsFilter
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
