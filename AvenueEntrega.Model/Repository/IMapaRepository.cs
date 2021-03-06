﻿using System;
using System.Collections.Generic;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Model.Repository
{
    public interface IMapaRepository : IRepository<Mapa,Guid>
    {
        Mapa FindByName(string name);

        IList<Mapa> FindAllByName(string name);
    }
}