namespace Project.Web.ViewModels.Repairs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateRepairViewModel
    {
        [Required]
        public DateTime DateOfRepair { get; set; }

        [Required]
        public decimal CurrentCarKilometers { get; set; }

        [Required]
        public decimal WorkCost { get; set; }

        [Required]
        [Display(Name = "Discount in %")]
        public decimal Discount { get; set; }

        [Required]
        public string Notes { get; set; }

        public string RepairShop { get; set; }

        public string RepairShopNewName { get; set; }

        public string RepairShopNewTown { get; set; }

        public IEnumerable<KeyValuePair<int, string>> RepairShops { get; set; }

        public int CarId { get; set; }
    }
}
