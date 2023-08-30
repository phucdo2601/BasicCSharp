namespace SalaryManagement.Requests
{
    public class ConfigurationRequest
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ConfigurationUpdateRequest
    {
        public string Value { get; set; }
    }
}
