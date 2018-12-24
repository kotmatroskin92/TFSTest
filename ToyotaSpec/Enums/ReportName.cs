namespace ToyotaSpec.Enums
{
    public sealed class ReportName
    {
        private readonly string _name;
        public static readonly ReportName VinWalk = new ReportName("VIN Walk");

        private ReportName(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
