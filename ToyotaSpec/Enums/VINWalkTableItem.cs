using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaSpec.Enums
{
    public sealed class VinWalkTableItem
    {
        private readonly String name;
        public int Value { get; }

        public static readonly VinWalkTableItem VIN = new VinWalkTableItem(0, "VIN");
        public static readonly VinWalkTableItem YEAR = new VinWalkTableItem(1, "Year");

        private VinWalkTableItem(int value, String name)
        {
            this.Value = value;
            this.name = name;
        }

        public override String ToString()
        {
            return name;
        }
    }
}
