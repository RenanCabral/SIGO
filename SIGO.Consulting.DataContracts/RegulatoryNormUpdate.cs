using System;

namespace SIGO.Consulting.DataContracts
{
    public class RegulatoryNormUpdate
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string ReleaseDate { get; set; }

        public string DueDate { get; set; }

        public string Category { get; set; }

        public bool Updated { get; set; }
    }
}