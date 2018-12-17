using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaSpec.Enums
{
    public sealed class ReportsFormItem
    {
        private readonly String name;

        public static readonly ReportsFormItem VINWALK = new ReportsFormItem("vinwalk");

        private ReportsFormItem(String name)
        {
            this.name = name;
        }

        public override String ToString()
        {
            return name;
        }
    }
}
