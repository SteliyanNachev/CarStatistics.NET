namespace Project.Services.Data.Models.Car
{
    using System;
    using System.Collections.Generic;

    using Project.Data.Models;

    public class CarDetails
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public decimal? EngineSize { get; set; }

        public string Fuel { get; set; }

        public string Colour { get; set; }

        public DateTime FirstRegistration { get; set; }

        public decimal Kilometers { get; set; }

        public ICollection<Repair> Repairs { get; set; }

       // public ICollection<CarStatistics.Models.OtherCosts> OtherCosts { get; set; }
    }
}
