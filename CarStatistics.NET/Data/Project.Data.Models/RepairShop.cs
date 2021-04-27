namespace Project.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Project.Data.Common.Models;

    using static DataValidations.RepairShop;

    public class RepairShop : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(TownMaxLenght)]
        public string Town { get; set; }

        public ICollection<Repair> Repairs { get; set; } = new HashSet<Repair>();
    }
}
