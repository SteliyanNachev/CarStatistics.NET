namespace Project.Web.ViewModels.Car
{
    using System.Collections.Generic;

    using Project.Services.Data.Models.Car;

    public class CarListingViewModel
    {
        public IEnumerable<CarsOfUserListingServiceModel> Cars { get; set; }
    }
}
