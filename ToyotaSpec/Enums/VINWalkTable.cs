using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaSpec.Enums
{
    public sealed class VinWalkTable
    {
        private readonly String name;
        public int Value { get; }

        public static readonly VinWalkTable VIN = new VinWalkTable(0, "VIN");
        public static readonly VinWalkTable YEAR = new VinWalkTable(1, "Year");

        private VinWalkTable(int value, String name)
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
