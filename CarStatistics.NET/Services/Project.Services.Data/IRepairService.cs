namespace Project.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Project.Services.Data.Models.Repairs;

    public interface IRepairService
    {
        Task Create(CreateRepairServiceModel model);

        // Task Edit(EditCarServiceModel model);

        // IEnumerable<CarsOfUserListingServiceModel> SearchByUser(string UserName);

        // CarDetails GetCarDetails(int carId);

        // Task<bool> Delete(int id);

        // IEnumerable<KeyValuePair<string, string>> GetAllUsersWithEmails();
    }
}
