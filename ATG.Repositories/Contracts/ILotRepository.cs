using ATG.Data.Models;
using System.Threading.Tasks;

namespace ATG.Repositories.Contracts
{
    public interface ILotRepository
    {
        Task<Lot> GetLotAsync(int id);
        Lot LoadCustomer(int id);
    }
}
