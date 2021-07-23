using ATG.Data.Models;
using ATG.Data.ViewModels;
using System.Threading.Tasks;

namespace ATG.Services
{

    public interface ILotService
    {
        Task<Lot> GetLotAsync(int id, bool isLotArchived);
        
    }
}
