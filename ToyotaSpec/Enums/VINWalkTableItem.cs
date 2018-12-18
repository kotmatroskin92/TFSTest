using System;

namespace ToyotaSpec.Enums
{
    public sealed class VinWalkTableItem
    {
        private readonly String _name;
        public int Value { get; }

        public static readonly VinWalkTableItem VIN = new VinWalkTableItem(0, "VIN");
        public static readonly VinWalkTableItem YEAR = new VinWalkTableItem(1, "Year");

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
