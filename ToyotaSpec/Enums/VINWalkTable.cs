using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaSpec.Enums
{
    public sealed class VINWalkTable
    {
        private readonly String name;
        public int Value { get; }

        public static readonly VINWalkTable VIN = new VINWalkTable(0, "VIN");
        public static readonly VINWalkTable YEAR = new VINWalkTable(1, "Year");

        private VINWalkTable(int value, String name)
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
