using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaSpec.Enums
{
    public sealed class TopMenuItem
    {
        private readonly String name;
        private readonly int value;

        public static readonly TopMenuItem REPORTS = new TopMenuItem(1, ".nav-reports");
        public static readonly TopMenuItem HOME = new TopMenuItem(2, ".nav-dashboard");

        private TopMenuItem(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }

    }
}
