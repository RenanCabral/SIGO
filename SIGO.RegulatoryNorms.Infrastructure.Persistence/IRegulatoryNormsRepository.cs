﻿using SIGO.RegulatoryNorms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Infrastructure.Persistence
{
    public interface IRegulatoryNormsRepository : IDisposable
    {
        Task<List<RegulatoryNorm>> GetAllAsync();
    }
}
