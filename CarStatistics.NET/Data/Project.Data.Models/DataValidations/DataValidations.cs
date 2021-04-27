using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Models
{
    public static class DataValidations
    {
        public static class User
        {
            public const int NameMaxLenght = 30;
        }

        public static class Car
        {
            public const int NameMaxLenght = 30;
            public const int ModelMaxLenght = 30;
            public const int TypeMaxLenght = 30;
            public const int FuelMaxLenght = 15;
            public const int ColourMaxLenght = 20;
        }

        public static class Repair
        {

        }

        public static class RepairShop
        {
            public const int NameMaxLenght = 100;
            public const int TownMaxLenght = 20;
        }

        public static class Part
        {
            public const int TypeMaxLenght = 100;
            public const int SupplyerMaxLenght = 100;
            public const int ResellerMaxLenght = 100;
            public const int MakeMaxLenght = 30;
            public const int ModelMaxLenght = 30; 
            public const int NotesMaxLenght = 10000; 
        }

        public static class OtherCosts
        {
            public const int NotesMaxLenght = 5000;
        }
    }
}
