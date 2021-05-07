namespace Project.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Project.Data.Models;
    using Project.Services.Data;
    using Project.Services.Data.Models.Car;
    using Project.Web.ViewModels.Car;

    public class CarController : BaseController
    {
        private readonly ICarService carService;
        private readonly UserManager<ApplicationUser> userManager;

        public CarController(ICarService carService, UserManager<ApplicationUser> userManager)
        {
            this.carService = carService;
            this.userManager = userManager;
        }

        public IActionResult CarDetails(int id)
        {
            var carDetails = this.carService.GetCarDetails(id);
            var model = new CarDetailsViewModel { CarDetails = carDetails };
            return this.View(model);
        }

        public IActionResult All()
        {
            var userID = this.userManager.GetUserId(this.User);
            var allCars = this.carService.SearchByUserId(userID);
            var model = new CarListingViewModel { Cars = allCars };
            return this.View(model);
        }

        public IActionResult Create()
        {
            var model = new CreateCarViewModel();
            model.UsersEmails = this.carService.GetAllUsersWithEmails();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarViewModel input)
        {
            var userID = this.userManager.GetUserId(this.User);

            if (!this.ModelState.IsValid)
            {
                // input.UsersEmails=
                return this.View(input);
            }

            var carServiceModel = new CreateCarServiceModel()
            {
                Make = input.Make,
                Model = input.Model,
                FirstRegistration = input.FirstRegistration,
                Fuel = input.Fuel,
                EngineSize = input.EngineSize,
                Colour = input.Colour,
                Kilometers = input.Kilometers,
                Type = input.Type,
                UserId = userID,
            };
            await this.carService.Create(carServiceModel);
            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Delete(int id)
        {
            var carDetails = this.carService.GetCarDetails(id);
            var model = new CarDetailsViewModel { CarDetails = carDetails };
            if (carDetails == null)
            {
                return this.BadRequest();
            }

            return this.View(model);
        }

        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var deleted = await this.carService.Delete(id);
            if (!deleted)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Edit(int id)
        {
            var car = this.carService.GetCarDetails(id);
            if (car == null)
            {
                return this.BadRequest();
            }

            var model = new EditCarViewModel()
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                FirstRegistration = car.FirstRegistration,
                Fuel = car.Fuel,
                EngineSize = car.EngineSize,
                Colour = car.Colour,
                Kilometers = car.Kilometers,
                Type = car.Type,
            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarViewModel carModel)
        {
            var editCarServiceModel = new EditCarServiceModel
            {
                Id = carModel.Id,
                Make = carModel.Make,
                Model = carModel.Model,
                FirstRegistration = carModel.FirstRegistration,
                Fuel = carModel.Fuel,
                EngineSize = carModel.EngineSize,
                Colour = carModel.Colour,
                Kilometers = carModel.Kilometers,
                Type = carModel.Type,
            };
            await this.carService.Edit(editCarServiceModel);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
