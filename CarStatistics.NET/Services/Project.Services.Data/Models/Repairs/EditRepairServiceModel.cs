namespace Project.Services.Data.Models.Repairs
{
    using System;
    using System.Collections.Generic;

    using Project.Data.Models;

    public class EditRepairServiceModel
    {
        public int Id { get; set; }

        public DateTime DateOfRepair { get; set; }

        public decimal CurrentCarKilometers { get; set; }

        public decimal WorkCost { get; set; }

        public decimal Discount { get; set; }

        public string Notes { get; set; }

        public int RepairShop { get; set; }

        public int CarId { get; set; }

    }
}
