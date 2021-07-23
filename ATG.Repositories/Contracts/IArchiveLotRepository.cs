using ATG.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATG.Repositories.Contracts
{
    public interface IArchiveLotRepository
    {
        Task<Lot> GetLotAsync(int id);
        Lot GetLot(int id);
    }
}
