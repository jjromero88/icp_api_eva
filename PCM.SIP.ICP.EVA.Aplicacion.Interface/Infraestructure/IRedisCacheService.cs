﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure
{
    public interface IRedisCacheService
    {
        Task SetAsync<T>(string key, T value, int absoluteExpiration, int slidingExpiration);
        Task<T> GetAsync<T>(string key);
    }
}
