using ATG.Data.Models;
using ATG.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATG.Repositories
{
    public class LotRepository : GenericRepository<ApplicationDbContext,Lot>, ILotRepository
    {
        private readonly ILogger<LotRepository> _logger;
        private ApplicationDbContext _dbContext;


        public LotRepository(ILogger<LotRepository> logger,ApplicationDbContext dbContext) : base(new ApplicationDbContext())
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        //public LotRepository(ApplicationDbContext dbContext) : base(new ApplicationDbContext())
        //{
            
        //    _dbContext = dbContext;
        //}
        public async Task<Lot> GetLotAsync(int id)
        {
            return await GetSingleAsync(id);
        }

        public Lot LoadCustomer(int id)
        {
            return GetSingle(id)??new Lot();
        }

        
    }
}
