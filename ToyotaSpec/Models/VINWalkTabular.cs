using System.Collections.Generic;
using System.Linq;

namespace ToyotaSpec.Models
{
    public class VinWalkTabular
    {
        private static readonly List<string> _propertyNames = typeof(VinWalkTabular).GetProperties().Select(f => f.Name).ToList();
        private string _pricingRule;

        public string VIN { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string MMR { get; set; }
        public string Mileage { get; set; }
        public string Location { get; set; }
        public string Condition { get; set; }
        public string Color { get; set; }
        public string Content { get; set; }
        public string CarFax { get; set; }
        public string Structural { get; set; }
        public string TimesRun { get; set; }
        public string SalesChannel { get; set; }
        public string Misc { get; set; }
        public string Manual { get; set; }
        public string Floor { get; set; }
        public string Status { get; set; }
        public string SalePrice { get; set; }
        public string SoldDate { get; set; }
        public string PricingRule
        {
            get => _pricingRule.Replace(";", string.Empty).Replace("\r\n", " ");
            set => _pricingRule = value;
        }

        public string DatePriced { get; set; }
        protected object this[string propertyName]
        {
            get => this.GetType().GetProperty(propertyName).GetValue(this, null);
            set => this.GetType().GetProperty(propertyName).SetValue(this, value, null);
        }

        public VinWalkTabular(string vin, int year, string make, string model, string trim, string mmr, string mileage, string location, string condition, string color, string content, string carFax, string structural, string timesRun, string salesChannel, string misc, string manual, string floor, string status, string salePrice, string soldDate, string pricingRule, string datePriced)
        {
            VIN = vin;
            Year = year;
            Make = make;
            Model = model;
            Trim = trim;
            MMR = mmr;
            Mileage = mileage;
            Location = location;
            Condition = condition;
            Color = color;
            Content = content;
            CarFax = carFax;
            Structural = structural;
            TimesRun = timesRun;
            SalesChannel = salesChannel;
            Misc = misc;
            Manual = manual;
            Floor = floor;
            Status = status;
            SalePrice = salePrice;
            SoldDate = soldDate;
            PricingRule = pricingRule;
            DatePriced = datePriced;
        }

        public VinWalkTabular()
        {
        }

        public bool Equals(VinWalkTabular obj)
        {
            foreach (var name in _propertyNames)
            {
                //var isNull = this[name] is null && obj[name] is null;
                if (!this[name].ToString().Contains(obj[name].ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
