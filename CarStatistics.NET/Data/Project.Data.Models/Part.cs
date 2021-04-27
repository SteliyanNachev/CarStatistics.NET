namespace Project.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Project.Data.Common.Models;

    using static DataValidations.Part;

    public class Part : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(TypeMaxLenght)]
        public string Type { get; set; }

        [Required]
        [MaxLength(ResellerMaxLenght)]
        public string ResellerName { get; set; }

        [Required]
        [MaxLength(SupplyerMaxLenght)]
        public string SupplierName { get; set; }

        [Required]
        [MaxLength(MakeMaxLenght)]
        public string Make { get; set; }

        [Required]
        [MaxLength(ModelMaxLenght)]
        public string Model { get; set; }

        public decimal Price { get; set; }

        public decimal VAT { get; set; }

        public int Quantity { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }

        [Required]
        [MaxLength(NotesMaxLenght)]
        public string Notes { get; set; }

        public int RepairId { get; set; }

        public Repair Repair { get; set; }
    }
}
