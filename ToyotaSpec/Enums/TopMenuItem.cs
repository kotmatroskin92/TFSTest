using System;

namespace ToyotaSpec.Enums
{
    public sealed class TopMenuItem
    {
        private readonly String _name;
        
        public static readonly TopMenuItem REPORTS = new TopMenuItem(".nav-reports");
        public static readonly TopMenuItem HOME = new TopMenuItem(".nav-dashboard");
        
        private TopMenuItem(String name)
        {
            _name = name;
        }

        public override String ToString()
        {
            return _name;
        }
    }
}
