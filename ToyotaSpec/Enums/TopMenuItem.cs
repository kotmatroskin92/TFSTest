using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaSpec.Enums
{
    public sealed class TopMenuItem
    {
        private readonly String name;
        
        public static readonly TopMenuItem REPORTS = new TopMenuItem(".nav-reports");
        public static readonly TopMenuItem HOME = new TopMenuItem(".nav-dashboard");
        
        private TopMenuItem(String name)
        {
            this.name = name;
        }

        public override String ToString()
        {
            return name;
        }

    }
}
