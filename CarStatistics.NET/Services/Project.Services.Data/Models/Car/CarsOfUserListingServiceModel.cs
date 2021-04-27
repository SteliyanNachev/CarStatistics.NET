namespace Project.Services.Data.Models.Car
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CarsOfUserListingServiceModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Fuel { get; set; }

        public decimal Kilometers { get; set; }
    }
}
