using ATG.Data.Models;
using ATG.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATG.Repositories
{
    public class FailoverLotRepository : GenericRepository<FailoverContext, Lot>, IFailoverLotRepository
    {
        private readonly ILogger<FailoverLotRepository> _logger;
        private FailoverContext _dbContext;

        public FailoverLotRepository(ILogger<FailoverLotRepository> logger, FailoverContext dbContext) : base(new FailoverContext())
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        

        public List<Lot> GetLots()
        {
            return GetList();
        }

        public async Task<Lot> GetLotAsync(int id)
        {
            var r= await GetSingleAsync(id);
            return r;
        }
    }
}
