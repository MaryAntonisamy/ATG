using ATG.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATG.Repositories.Contracts
{
    public interface IFailoverRepository
    {
        List<FailoverLot> GetLots();
    }
}
