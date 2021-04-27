namespace Project.Services.Data.Models.Repairs
{
    using System;

    using Project.Data.Models;

    public class RepairDetailsServiceModel
    {
        public int Id { get; set; }

        public DateTime DateOfRepair { get; set; }

        public decimal CurrentCarKilometers { get; set; }

        public decimal WorkCost { get; set; }

        public decimal Discount { get; set; }

        public decimal RepairTotalCost { get; set; }

        public string Notes { get; set; }

        public RepairShop RepairShop { get; set; }

        public decimal PartsTotalCost { get; set; }

        public int CarID { get; set; }
    }
}
