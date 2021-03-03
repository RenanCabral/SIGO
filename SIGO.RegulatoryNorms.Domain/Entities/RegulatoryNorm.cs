using SIGO.RegulatoryNorms.Domain.Enums;
using System;

namespace SIGO.RegulatoryNorms.Domain.Entities
{
    public class RegulatoryNorm
    {
        public int RegulatoryNormId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public bool IsApplied { get; set; }

        public DateTime ReleaseDate { get; set; }

        public RegulatoryNormCategory Category { get; set; }
    }
}
