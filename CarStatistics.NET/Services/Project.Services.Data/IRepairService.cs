namespace Project.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Project.Services.Data.Models.Repairs;

    public interface IRepairService
    {
        Task Create(CreateRepairServiceModel model);

        Task Edit(EditRepairServiceModel model);

        IEnumerable<RepairsOfCarListingServiceModel> SearchByCarId(int carId);

        RepairDetailsServiceModel GetRepairDetails(int repairId);

        // Task<bool> Delete(int id);
        IEnumerable<KeyValuePair<int, string>> GetAllRepairShops();
    }
}
