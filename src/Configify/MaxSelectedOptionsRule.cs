namespace Configify
{
    public class MaxSelectedOptionsRule : IConfigurationRule
    {
        public int Count { get; set; }

        public string Name => "MaxSelectedOptionsRule";
    }
}