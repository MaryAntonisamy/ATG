using ATG.Data.Models;
using ATG.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATG.Repositories
{
    public class FailoverRepository : GenericRepository<FailoverContext, FailoverLot>, IFailoverRepository
    {
        private readonly ILogger<FailoverLotRepository> _logger;
        private FailoverContext _dbContext;

        public FailoverRepository(ILogger<FailoverLotRepository> logger, FailoverContext dbContext) : base(new FailoverContext())
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public List<FailoverLot> GetLots()
        {
            return GetList();
        }

    }
}
