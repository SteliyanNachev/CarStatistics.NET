namespace Project.Web.ViewModels.Repairs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EditRepairViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateOfRepair { get; set; }

        [Required]
        public decimal CurrentCarKilometers { get; set; }

        [Required]
        public decimal WorkCost { get; set; }

        [Required]
        [Display(Name = "Discount in %")]
        public decimal Discount { get; set; }

        public string Notes { get; set; }

        [Required]
        public string RepairShop { get; set; }

        [Required]
        public IEnumerable<KeyValuePair<int, string>> RepairShops { get; set; }

        public int CarId { get; set; }
    }
}
