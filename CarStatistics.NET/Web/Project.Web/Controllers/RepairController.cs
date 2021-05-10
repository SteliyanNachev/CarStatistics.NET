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

        public IActionResult All(int id)
       {
           var allRepairs = this.repairService.SearchByCarId(id);
           var model = new RepairListingViewModel { Repairs = allRepairs, CarId = id };
           return this.View(model);
       }

        public IActionResult Create(int carId)
       {
           var model = new CreateRepairViewModel();
           model.RepairShops = this.repairService.GetAllRepairShops();
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
               RepairShop = int.Parse(input.RepairShop),
               CarId = id,
           };
           await this.repairService.Create(repairServiceModel);
           return this.RedirectToAction(nameof(this.All), new { id = id });
       }

        public IActionResult Delete(int id)
       {
            var repair = this.repairService.GetRepairDetails(id);

            if (repair == null)
           {
               return this.BadRequest();
           }

            var model = new EditRepairViewModel
            {
                Id = id,
                CarId = repair.CarID,
                CurrentCarKilometers = repair.CurrentCarKilometers,
                DateOfRepair = repair.DateOfRepair,
                WorkCost = repair.WorkCost,
                Notes = repair.Notes,
                Discount = repair.Discount,
            };
            return this.View(model);
       }

        public async Task<IActionResult> ConfirmDelete(int id)
       {
            var repair = this.repairService.GetRepairDetails(id);
            var deleted = await this.repairService.Delete(id);
            if (!deleted)
           {
               return this.BadRequest();
           }

            return this.RedirectToAction(nameof(this.All), new { id = repair.CarID });
       }

        public IActionResult Edit(int id)
      {
          var repair = this.repairService.GetRepairDetails(id);
          if (repair == null)
          {
              return this.BadRequest();
          }

          var model = new EditRepairViewModel();
          model.RepairShops = this.repairService.GetAllRepairShops();
          model.CurrentCarKilometers = repair.CurrentCarKilometers;
          model.DateOfRepair = repair.DateOfRepair;
          model.WorkCost = repair.WorkCost;
          model.Notes = repair.Notes;
          model.Discount = repair.Discount;
          return this.View(model);
      }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRepairViewModel repairModel)
      {
            var repair = this.repairService.GetRepairDetails(id);

            var editRepairServiceModel = new EditRepairServiceModel
          {
              Id = id,
              DateOfRepair = repairModel.DateOfRepair,
              CurrentCarKilometers = repairModel.CurrentCarKilometers,
              WorkCost = repairModel.WorkCost,
              Discount = repairModel.Discount,
              Notes = repairModel.Notes,
              RepairShop = int.Parse(repairModel.RepairShop),
              CarId = repair.CarID,
          };
            await this.repairService.Edit(editRepairServiceModel);
            return this.RedirectToAction(nameof(this.All), new { id = repair.CarID });
        }
    }
}
