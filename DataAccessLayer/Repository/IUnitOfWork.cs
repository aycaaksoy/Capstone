﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IUnitOfWork: IDisposable
    {
        IGameRepository Games { get; }
        void Save();
    }
}
