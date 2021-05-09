namespace Project.Web.ViewModels.Repairs
{
    using System;
    using System.Collections.Generic;

    public class CreateRepairViewModel
    {
        public DateTime DateOfRepair { get; set; }

        public decimal CurrentCarKilometers { get; set; }

        public decimal WorkCost { get; set; }

        public decimal Discount { get; set; }

        public string Notes { get; set; }

        public string RepairShop { get; set; }

        public IEnumerable<KeyValuePair<int, string>> RepairShops { get; set; }

        public int CarId { get; set; }
    }
}
