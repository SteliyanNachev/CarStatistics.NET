namespace Project.Data.Models
{
    using System;

    using Project.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public string Extention { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        // The content of the picture is in the file system
    }
}
