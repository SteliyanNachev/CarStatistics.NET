namespace Project.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Project.Data.Common.Models;

    public class Repair : BaseDeletableModel<int>
    {
        [Required]
        public DateTime DateOfRepair { get; set; }

        [Required]
        public decimal CurrentCarKilometers { get; set; }

        public decimal WorkCost { get; set; }

        public decimal Discount { get; set; }

        public decimal RepairTotalCost { get; set; }

        public string Notes { get; set; }

        public int RepairShopId { get; set; }

        public RepairShop RepairShop { get; set; }

        public int CarID { get; set; }

        public Car Car { get; set; }

        public ICollection<Part> Parts { get; set; } = new HashSet<Part>();
    }
}
