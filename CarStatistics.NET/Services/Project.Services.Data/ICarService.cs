namespace Project.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Project.Services.Data.Models.Car;

    public interface ICarService
    {
        Task Create(CreateCarServiceModel model);

        Task Edit(EditCarServiceModel model);

        IEnumerable<CarsOfUserListingServiceModel> SearchByUserId(string id);

        CarDetails GetCarDetails(int carId);

        Task<bool> Delete(int id);

        IEnumerable<KeyValuePair<string, string>> GetAllUsersWithEmails();
    }
}
