using RiseFoodServiceWork.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiseFoodServiceWork.Services.LocalDatabase
{
    public interface ILocalDatabaseService
    {
       Task<IEnumerable<Supplie>> GetAllSupplies();
    }
}
