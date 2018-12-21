using System;

namespace ToyotaSpec.Enums
{
    public sealed class TopMenuItem
    {
        private readonly String _name;
        public static readonly TopMenuItem Reports = new TopMenuItem(".nav-reports");
        public static readonly TopMenuItem Home = new TopMenuItem(".nav-dashboard");
        
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
