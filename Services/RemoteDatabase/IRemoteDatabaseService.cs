using RiseFoodServiceWork.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RiseFoodServiceWork.Services.RemoteDatabase
{
    public interface IRemoteDatabaseService
    {
        Task SaveSupplie(Supplie supplie);
        bool IsCollectionExist();
    }
}
