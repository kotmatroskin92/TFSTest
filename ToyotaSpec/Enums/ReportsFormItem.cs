using System;

namespace ToyotaSpec.Enums
{
    public sealed class ReportsFormItem
    {
        private readonly String _name;

        public static readonly ReportsFormItem VIN_WALK = new ReportsFormItem("vinwalk");

        private ReportsFormItem(String name)
        {
            _name = name;
        }

        public override String ToString()
        {
            return _name;
        }
    }
}
