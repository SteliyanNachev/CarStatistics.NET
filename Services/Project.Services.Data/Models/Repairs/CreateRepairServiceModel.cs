namespace Project.Services.Data.Models.Repairs
{
    using System;
    using System.Collections.Generic;

    public class CreateRepairServiceModel
    {
        public DateTime DateOfRepair { get; set; }

        public decimal CurrentCarKilometers { get; set; }

        public decimal WorkCost { get; set; }

        public decimal Discount { get; set; }

        public string Notes { get; set; }

        public int RepairShop { get; set; }

        public int CarId { get; set; }

        // public ICollection<Part> Parts { get; set; }
    }
}
