namespace Project.Web.ViewModels.Repairs
{
    using System;

    public class CreateRepairViewModel
    {
        public DateTime DateOfRepair { get; set; }

        public decimal CurrentCarKilometers { get; set; }

        public decimal WorkCost { get; set; }

        public decimal Discount { get; set; }

        public string Notes { get; set; }

        public int RepairShop { get; set; }

        public int CarId { get; set; }
    }
}
