using System;

namespace ToyotaSpec.Enums
{
    public sealed class VinWalkTableItem
    {
        private readonly String _name;
        public int Value { get; }

        public static readonly VinWalkTableItem Vin = new VinWalkTableItem(0, "VIN");
        public static readonly VinWalkTableItem Year = new VinWalkTableItem(1, "Year");
        public static readonly VinWalkTableItem Make = new VinWalkTableItem(2, "Make");
        public static readonly VinWalkTableItem Model = new VinWalkTableItem(3, "Model");
        public static readonly VinWalkTableItem Trim = new VinWalkTableItem(4, "Trim");
        public static readonly VinWalkTableItem Mmr = new VinWalkTableItem(5, "MMR");
        public static readonly VinWalkTableItem Mileage = new VinWalkTableItem(6, "Mileage");
        public static readonly VinWalkTableItem Location = new VinWalkTableItem(7, "Location");
        public static readonly VinWalkTableItem Condition = new VinWalkTableItem(8, "Condition");
        public static readonly VinWalkTableItem Color = new VinWalkTableItem(9, "Color");
        public static readonly VinWalkTableItem Content = new VinWalkTableItem(10, "Content");
        public static readonly VinWalkTableItem CarFax = new VinWalkTableItem(11, "CarFax");
        public static readonly VinWalkTableItem Structural = new VinWalkTableItem(12, "Structural");
        public static readonly VinWalkTableItem TimesRun = new VinWalkTableItem(13, "Times Run");
        public static readonly VinWalkTableItem SalesChannel = new VinWalkTableItem(14, "Sales Channel");
        public static readonly VinWalkTableItem Misc = new VinWalkTableItem(15, "Misc.");
        public static readonly VinWalkTableItem Manual = new VinWalkTableItem(16, "Manual");
        public static readonly VinWalkTableItem Floor = new VinWalkTableItem(17, "Floor");
        public static readonly VinWalkTableItem Status = new VinWalkTableItem(18, "Status");
        public static readonly VinWalkTableItem SalePrice = new VinWalkTableItem(18, "Sale Price");
        public static readonly VinWalkTableItem SoldDate = new VinWalkTableItem(19, "Sold Date");
        public static readonly VinWalkTableItem PricingRule = new VinWalkTableItem(20, "Pricing Rule");
        public static readonly VinWalkTableItem DatePriced = new VinWalkTableItem(21, "Date Priced");

        private VinWalkTableItem(int value, String name)
        {
            Value = value;
            _name = name;
        }

        public override String ToString()
        {
            return _name;
        }
    }
}
