using ATG.Data.Models;
using ATG.Data.ViewModels;
using ATG.Repositories.Contracts;
using ATG.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATG.Web.Controllers
{
    public class LotController : Controller
    {
        #region Fields
        private readonly ILotService lotService;


        #endregion

        #region  Constructors
        
        public LotController(ILotService _lotService)
        {
            lotService = _lotService;   
        }
        #endregion
        public async Task<IActionResult> IndexAsync()
        {
            int id = 2;
            Lot result = await GetLot(id);
            return View(result);
        }

        public async Task<Lot> GetLot(int id)
        {
            
            bool isLotArchived = false;
            var result = await lotService.GetLotAsync(id, isLotArchived);
            return result;
        }

    }
}
