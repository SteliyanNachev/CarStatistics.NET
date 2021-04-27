namespace Project.Services.Data.Models.Repairs
{
    using System;
    using System.Collections.Generic;

    using Project.Data.Models;

    public class RepairsOfCarListingServiceModel
    {
        public int Id { get; set; }

        public string CarMakeModel { get; set; }

        public DateTime DateOfRepair { get; set; }

        public decimal CurrentCarKilometers { get; set; }

        public decimal WorkCost { get; set; }

        public decimal Discount { get; set; }

        public decimal RepairTotalCost { get; set; }

        public string Notes { get; set; }

        public string RepairShop { get; set; }

        public decimal PartsTotalCost { get; set; }

        public ICollection<Part> Parts { get; set; }
    }
}
