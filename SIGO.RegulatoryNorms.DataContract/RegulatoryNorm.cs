using System;

namespace SIGO.RegulatoryNorms.DataContracts
{
    public class RegulatoryNorm
    {
        public string  Code { get; set; }

        public string Description { get; set; }

        public RegulatoryNormCategory Category { get; set; }

        public DateTime ReleaseDate { get; set; } = DateTime.Parse("02-01-1998");
    }
}
