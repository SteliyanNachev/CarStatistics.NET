namespace Project.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Project.Data.Common.Repositories;
    using Project.Data.Models;
    using Project.Services.Data;
    using Project.Services.Data.Models.Repairs;
    using Project.Web.ViewModels.Repairs;
    using Project.Web.ViewModels.Settings;

    public class RepairController : BaseController
    {
        private readonly IRepairService repairService;

        public RepairController(IRepairService repairService)
        {
            this.repairService = repairService;
        }

      // public IActionResult CarDetails(int id)
      // {
      //     var carDetails = this.carService.GetCarDetails(id);
      //     var model = new CarDetailsViewModel { CarDetails = carDetails };
      //     return this.View(model);
      // }
      //
        public IActionResult All(int id)
       {
           var allRepairs = this.repairService.SearchByCarId(id);
           var model = new RepairListingViewModel { Repairs = allRepairs, CarId = id };
           return this.View(model);
       }

        public IActionResult Create(int carId)
       {
           var model = new CreateRepairViewModel();
           model.CarId = carId;
           return this.View(model);
       }

        [HttpPost]
        public async Task<IActionResult> Create(int carId, CreateRepairViewModel input)
       {
           if (!this.ModelState.IsValid)
           {
               // input.UsersEmails=
               return this.View(input);
           }

           var repairServiceModel = new CreateRepairServiceModel()
           {
               DateOfRepair = input.DateOfRepair,
               CurrentCarKilometers = input.CurrentCarKilometers,
               WorkCost = input.WorkCost,
               Discount = input.Discount,
               Notes = input.Notes,
               RepairShop = input.RepairShop,
               CarId = input.CarId,
           };
           await this.repairService.Create(repairServiceModel);
           return this.RedirectToAction(nameof(this.All), new { id = input.CarId });
       }
      
      // public IActionResult Delete(int id)
      // {
      //     var carDetails = this.carService.GetCarDetails(id);
      //     var model = new CarDetailsViewModel { CarDetails = carDetails };
      //     if (carDetails == null)
      //     {
      //         return this.BadRequest();
      //     }
      //
      //     return this.View(model);
      // }
      //
      // public async Task<IActionResult> ConfirmDelete(int id)
      // {
      //     var deleted = await this.carService.Delete(id);
      //     if (!deleted)
      //     {
      //         return this.BadRequest();
      //     }
      //
      //     return this.RedirectToAction(nameof(this.All));
      // }
      //
      // public IActionResult Edit(int id)
      // {
      //     var car = this.carService.GetCarDetails(id);
      //     if (car == null)
      //     {
      //         return this.BadRequest();
      //     }
      //
      //     var model = new EditCarViewModel()
      //     {
      //         Id = car.Id,
      //         Make = car.Make,
      //         Model = car.Model,
      //         FirstRegistration = car.FirstRegistration,
      //         Fuel = car.Fuel,
      //         EngineSize = car.EngineSize,
      //         Colour = car.Colour,
      //         Kilometers = car.Kilometers,
      //         Type = car.Type,
      //     };
      //     return this.View(model);
      // }
      //
      // [HttpPost]
      // public async Task<IActionResult> Edit(EditCarViewModel carModel)
      // {
      //     var editCarServiceModel = new EditCarServiceModel
      //     {
      //         Id = carModel.Id,
      //         Make = carModel.Make,
      //         Model = carModel.Model,
      //         FirstRegistration = carModel.FirstRegistration,
      //         Fuel = carModel.Fuel,
      //         EngineSize = carModel.EngineSize,
      //         Colour = carModel.Colour,
      //         Kilometers = carModel.Kilometers,
      //         Type = carModel.Type,
      //     };
      //     await this.carService.Edit(editCarServiceModel);
      //     return this.RedirectToAction(nameof(this.All));
      // }
    }
}
