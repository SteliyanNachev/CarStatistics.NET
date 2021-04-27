namespace Project.Web.ViewModels.Repairs
{
    using System.Collections.Generic;

    using Project.Services.Data.Models.Repairs;

    public class RepairListingViewModel
    {
        public int CarId { get; set; }

        public IEnumerable<RepairsOfCarListingServiceModel> Repairs { get; set; }
    }
}
