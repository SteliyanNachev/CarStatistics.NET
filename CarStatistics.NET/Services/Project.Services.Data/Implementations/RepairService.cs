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
            this.carsRepository.Update(car);
            await this.repairRepository.AddAsync(repair);
            await this.repairRepository.SaveChangesAsync();
        }

        public RepairDetailsServiceModel GetRepairDetails(int repairId)
        {
            var repair = this.repairRepository
               .AllAsNoTracking()
               .Where(r => r.Id == repairId)
               .Select(r => new RepairDetailsServiceModel
               {
                   Id = r.Id,
                   DateOfRepair = r.DateOfRepair,
                   CurrentCarKilometers = r.CurrentCarKilometers,
                   WorkCost = r.WorkCost,
                   Discount = r.Discount,
                   RepairTotalCost = r.RepairTotalCost,
                   Notes = r.Notes,
                   RepairShop = r.RepairShop,
                   CarID = r.CarID,
               }).FirstOrDefault();

            return repair;
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
        public async Task Edit(EditRepairServiceModel model)
         {
            var repair = this.repairRepository
                .AllAsNoTracking()
                .Where(x => x.Id == model.Id)
                .FirstOrDefault();

            repair.DateOfRepair = model.DateOfRepair;
            repair.CarID = model.CarId;
            repair.RepairShopId = model.RepairShop;
            repair.Notes = model.Notes;
            repair.Discount = model.Discount;
            repair.WorkCost = model.WorkCost;
            repair.CurrentCarKilometers = model.CurrentCarKilometers;

            var car = this.carsRepository
                .AllAsNoTracking()
                .FirstOrDefault(c => c.Id == model.CarId);

            car.Kilometers = model.CurrentCarKilometers;
            this.carsRepository.Update(car);
            this.repairRepository.Update(repair);
            await this.repairRepository.SaveChangesAsync();
        }

        // Should search by ID not by Email
        public IEnumerable<RepairsOfCarListingServiceModel> SearchByCarId(int carId)
        {
            var cars = this.repairRepository
                .AllAsNoTracking()
                .Where(repair => repair.CarID == carId)
                .Select(r => new RepairsOfCarListingServiceModel
                {
                    Id = r.Id,
                    CarMakeModel = $"{r.Car.Make} {r.Car.Model}",
                    DateOfRepair = r.DateOfRepair,
                    CurrentCarKilometers = r.Car.Kilometers,
                    WorkCost = r.WorkCost,
                    Discount = r.Discount,
                    RepairTotalCost = (r.WorkCost - (r.Discount / 100 * r.WorkCost)) + r.Parts
                       .Select(p => p.TotalPrice)
                       .Sum(),
                    Notes = r.Notes,
                    RepairShop = r.RepairShop.Name,
                    Parts = r.Parts
                       .ToList(),
                    PartsTotalCost = r.Parts
                       .Select(p => p.TotalPrice)
                       .Sum(),
                })
                .ToList();
            return cars;
        }
    }
}
