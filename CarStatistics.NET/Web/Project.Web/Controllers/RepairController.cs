namespace Project.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Project.Services.Data;
    using Project.Services.Data.Models.Repairs;
    using Project.Web.ViewModels.Repairs;

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
        public async Task<IActionResult> Create(int id, CreateRepairViewModel input)
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
               CarId = id,
           };
           await this.repairService.Create(repairServiceModel);
           return this.RedirectToAction(nameof(this.All), new { id = id });
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
        public IActionResult Edit(int id)
      {
          var repair = this.repairService.GetRepairDetails(id);
          if (repair == null)
          {
              return this.BadRequest();
          }

          var model = new EditRepairViewModel();
          model.CarId = id;
          return this.View(model);
      }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, int carId, EditRepairViewModel repairModel)
      {
          var editRepairServiceModel = new EditRepairServiceModel
          {
              Id = id,
              DateOfRepair = repairModel.DateOfRepair,
              CurrentCarKilometers = repairModel.CurrentCarKilometers,
              WorkCost = repairModel.WorkCost,
              Discount = repairModel.Discount,
              Notes = repairModel.Notes,
              RepairShop = repairModel.RepairShop,
              CarId = carId,
          };
          await this.repairService.Edit(editRepairServiceModel);
          return this.RedirectToAction(nameof(this.All), new { id = id });
        }
    }
}
