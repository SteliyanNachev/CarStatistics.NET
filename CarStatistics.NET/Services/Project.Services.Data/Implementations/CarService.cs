namespace Project.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Project.Data.Common.Repositories;
    using Project.Data.Models;
    using Project.Services.Data;
    using Project.Services.Data.Models.Car;

    public class CarService : ICarService
    {
        private readonly IDeletableEntityRepository<Car> carRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public CarService(IDeletableEntityRepository<Car> carRepository, IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
            this.carRepository = carRepository;
        }

        public async Task Create(CreateCarServiceModel model)
        {
            var car = new Car
            {
                Make = model.Make,
                Model = model.Model,
                FirstRegistration = model.FirstRegistration,
                Fuel = model.Fuel,
                EngineSize = model.EngineSize,
                Colour = model.Colour,
                Kilometers = model.Kilometers,
                Type = model.Type,
                UserId = model.UserId,
            };
            await this.carRepository.AddAsync(car);
            await this.carRepository.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var car = this.carRepository.AllAsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            if (car == null)
            {
                return true;
            }

            this.carRepository.Delete(car);
            await this.carRepository.SaveChangesAsync();
            return true;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllUsersWithEmails()
        {
           return this.usersRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Email,
                })
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id, x.Email));
        }

        public async Task Edit(EditCarServiceModel model)
         {
             var car = this.carRepository
                .AllAsNoTracking()
                .Where(x => x.Id == model.Id)
                .FirstOrDefault();

             car.Make = model.Make;
             car.Model = model.Model;
             car.Type = model.Type;
             car.Colour = model.Colour;
             car.Kilometers = model.Kilometers;
             car.EngineSize = model.EngineSize;
             car.Fuel = model.Fuel;

             this.carRepository.Update(car);
             await this.carRepository.SaveChangesAsync();
        }

        public CarDetails GetCarDetails(int carId)
        {
            var car = this.carRepository
                .AllAsNoTracking()
                .Where(car => car.Id == carId)
                .Select(car => new CarDetails
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    Fuel = car.Fuel,
                    Colour = car.Colour,
                    Kilometers = car.Kilometers,
                    FirstRegistration = car.FirstRegistration,
                    EngineSize = car.EngineSize,
                    Type = car.Type,
                    Repairs = car.Repairs,
                   // OtherCosts=car.OtherCosts
                })
                .FirstOrDefault();
            return car;
        }

        // Should search by ID not by Email
        public IEnumerable<CarsOfUserListingServiceModel> SearchByUserId(string id)
        {
            var cars = this.carRepository
                .AllAsNoTracking()
                .Where(car => car.User.Id == id)
                .Select(car => new CarsOfUserListingServiceModel
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    Fuel = car.Fuel,
                    Kilometers = car.Kilometers,
                })
                .ToList();
            return cars;
        }
    }
}
