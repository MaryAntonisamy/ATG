using ATG.Data.Models;
using ATG.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ATG.Repositories
{
    public class ArchiveLotRepository : GenericRepository<ArchiveContext,Lot>, IArchiveLotRepository
    {
        private readonly ILogger<ArchiveLotRepository> _logger;
        private ArchiveContext _dbContext;


        public ArchiveLotRepository(ILogger<ArchiveLotRepository> logger, ArchiveContext dbContext): base(new ArchiveContext())
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Lot GetLot(int id)
        {
            return GetLot(id);
        }

        public async Task<Lot> GetLotAsync(int id)
        {
            return await GetSingleAsync(id);
        }
    }
}
