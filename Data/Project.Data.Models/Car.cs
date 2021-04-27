namespace Project.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Project.Data.Common.Models;

    using static DataValidations.Car;

    public class Car : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(NameMaxLenght)]
        public string Make { get; set; }

        [Required]
        [MaxLength(ModelMaxLenght)]
        public string Model { get; set; }

        [MaxLength(TypeMaxLenght)]
        public string Type { get; set; }

        public decimal? EngineSize { get; set; }

        [MaxLength(FuelMaxLenght)]
        public string Fuel { get; set; }

        [MaxLength(ColourMaxLenght)]
        public string Colour { get; set; }

        [Required]
        public DateTime FirstRegistration { get; set; }

        [Required]
        public decimal Kilometers { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Repair> Repairs { get; set; } = new HashSet<Repair>();

        public ICollection<OtherCosts> OtherCosts { get; set; } = new HashSet<OtherCosts>();

        public ICollection<Image> Images { get; set; } = new HashSet<Image>();
    }
}
