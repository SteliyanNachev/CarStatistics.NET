namespace Project.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Project.Data.Common.Repositories;
    using Project.Data.Models;
    using Project.Services.Data;
    using Project.Services.Data.Models.Repairs;

    public class RepairService : IRepairService
    {
        private readonly IDeletableEntityRepository<Repair> repairRepository;
        private readonly IDeletableEntityRepository<Car> carsRepository;

        public RepairService(IDeletableEntityRepository<Repair> repairRepository, IDeletableEntityRepository<Car> carsRepository)
        {
            this.carsRepository = carsRepository;
            this.repairRepository = repairRepository;
        }

        public async Task Create(CreateRepairServiceModel model)
        {
            var repair = new Repair
            {
                DateOfRepair = model.DateOfRepair,
                CurrentCarKilometers = model.CurrentCarKilometers,
                WorkCost = model.WorkCost,
                Discount = model.Discount,
                Notes = model.Notes,
                RepairShopId = model.RepairShop,
                CarID = model.CarId,
            };
            var car = this.carsRepository
                .AllAsNoTracking()
                .FirstOrDefault(c => c.Id == model.CarId);

            car.Kilometers = model.CurrentCarKilometers;
            await this.repairRepository.AddAsync(repair);
            await this.repairRepository.SaveChangesAsync();
        }

        // public async Task<bool> Delete(int id)
        // {
        //     var car = this.carRepository.AllAsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        //     if (car == null)
        //     {
        //         return true;
        //     }
        //
        //     this.carRepository.Delete(car);
        //     await this.carRepository.SaveChangesAsync();
        //     return true;
        // }
        //
        // public IEnumerable<KeyValuePair<string, string>> GetAllUsersWithEmails()
        // {
        //    return this.usersRepository.AllAsNoTracking()
        //         .Select(x => new
        //         {
        //             x.Id,
        //             x.Email,
        //         })
        //         .ToList()
        //         .Select(x => new KeyValuePair<string, string>(x.Id, x.Email));
        // }
        //
        // public async Task Edit(EditCarServiceModel model)
        //  {
        //      var car = this.carRepository
        //         .AllAsNoTracking()
        //         .Where(x => x.Id == model.Id)
        //         .FirstOrDefault();
        //
        //      car.Make = model.Make;
        //      car.Model = model.Model;
        //      car.Type = model.Type;
        //      car.Colour = model.Colour;
        //      car.Kilometers = model.Kilometers;
        //      car.EngineSize = model.EngineSize;
        //      car.Fuel = model.Fuel;
        //
        //      this.carRepository.Update(car);
        //      await this.carRepository.SaveChangesAsync();
        // }
        //
        // public CarDetails GetCarDetails(int carId)
        // {
        //     var car = this.carRepository
        //         .AllAsNoTracking()
        //         .Where(car => car.Id == carId)
        //         .Select(car => new CarDetails
        //         {
        //             Id = car.Id,
        //             Make = car.Make,
        //             Model = car.Model,
        //             Fuel = car.Fuel,
        //             Colour = car.Colour,
        //             Kilometers = car.Kilometers,
        //             FirstRegistration = car.FirstRegistration,
        //             EngineSize = car.EngineSize,
        //             Type = car.Type,
        //
        //            // Repairs=car.Repairs,
        //            // OtherCosts=car.OtherCosts
        //         })
        //         .FirstOrDefault();
        //     return car;
        // }
        //
        // // Should search by ID not by Email
        // public IEnumerable<CarsOfUserListingServiceModel> SearchByUser(string email)
        // {
        //     var cars = this.carRepository
        //         .AllAsNoTracking()
        //         .Where(car => car.User.Email.ToLower() == email)
        //         .Select(car => new CarsOfUserListingServiceModel
        //         {
        //             Id = car.Id,
        //             Make = car.Make,
        //             Model = car.Model,
        //             Fuel = car.Fuel,
        //             Kilometers = car.Kilometers,
        //         })
        //         .ToList();
        //     return cars;
        // }
    }
}
