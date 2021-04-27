namespace Project.Web.ViewModels.Car
{
    using System;
    using System.Collections.Generic;

    public class CreateCarViewModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public decimal? EngineSize { get; set; }

        public string Fuel { get; set; }

        public string Colour { get; set; }

        public DateTime FirstRegistration { get; set; }

        public decimal Kilometers { get; set; }

        public string? UserId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> UsersEmails { get; set; }
    }
}
