namespace ToyotaSpec.Enums
{
    public sealed class ReportsFormItem
    {
        private readonly string _name;
        public static readonly ReportsFormItem VinWalk = new ReportsFormItem("vinwalk");

        private ReportsFormItem(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
