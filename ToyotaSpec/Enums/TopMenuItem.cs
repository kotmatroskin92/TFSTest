namespace ToyotaSpec.Enums
{
    public sealed class TopMenuItem
    {
        private readonly string _name;
        public static readonly TopMenuItem Reports = new TopMenuItem(".nav-reports");
        public static readonly TopMenuItem Home = new TopMenuItem(".nav-dashboard");
        
        private TopMenuItem(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
