using ATG.Repositories;
using ATG.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using ATG.Data.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using ATG.Libraries.TypeHelpers;
using System;
using ATG.Data.ViewModels;

namespace ATG.Services
{
   public class LotService : ILotService
    {
        private readonly ILogger<LotService> _logger;
        ILotRepository _lotRepository;
        IFailoverLotRepository _failoverLotRepository;
        IArchiveLotRepository _archiveRepository;
        IFailoverRepository _failoverRepository;


        public LotService( ILotRepository lotRepository,IFailoverLotRepository failoverLotRepository, IArchiveLotRepository archiveRepository,IFailoverRepository failoverRepository)
        {
            // _logger = logger;
            _lotRepository = lotRepository;
            _failoverLotRepository = failoverLotRepository;
            _archiveRepository = archiveRepository;
            _failoverRepository =  failoverRepository;

        }


        public async Task<Lot> GetLotAsync(int id, bool isLotArchived)
        {

            bool isFailoverModeEnabled = true;
            int MaxFailedRequests = 50;
            Lot lot = new Lot();
            

            var failoverLots = GetFailOverLotEntries();
            var failedRequests = failoverLots
                                            .Where(failoverLotsEntry => DateTimeHelper.IsTimeMorethanTenMinutes(failoverLotsEntry.DateTime, DateTime.Now))
                                            .Count();


            if ((failedRequests > MaxFailedRequests) && isFailoverModeEnabled)
            {
                //var f = new ()
                lot = await _failoverLotRepository.GetLotAsync(id);
            }

            if (lot.IsArchived && isLotArchived)
            {
                return await _archiveRepository.GetLotAsync(id);
            }
            else
            {
                var res= _lotRepository.LoadCustomer(id);
                return res;
            }
        }

        public List<FailoverLot> GetFailOverLotEntries()
        {
            // return all from fail entries from database
            return  _failoverRepository.GetLots()??new List<FailoverLot>();//
                                                          
        }

        
    }
}
