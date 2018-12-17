using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaSpec.Enums
{
    public sealed class ReportName
    {
        private readonly String name;

        public static readonly ReportName VINWALK = new ReportName("VIN Walk");

        private ReportName(String name)
        {
            this.name = name;
        }

        public override String ToString()
        {
            return name;
        }
    }
}
