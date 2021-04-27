namespace Project.Services.Data.Models.Car
{
    using System;

    public class EditCarServiceModel
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
    }
}
