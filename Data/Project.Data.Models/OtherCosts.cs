namespace Project.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Project.Data.Common.Models;

    using static DataValidations.OtherCosts;

    public class OtherCosts : BaseDeletableModel<int>
    {
        public OtherCostType Type { get; set; }

        public DateTime IssueDate { get; set; }

        public int NumberOfContributins { get; set; }

        public decimal Price { get; set; }

        public DateTime EndDate { get; set; }

        public bool Payed { get; set; }

        [MaxLength(NotesMaxLenght)]
        public string Notes { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}
