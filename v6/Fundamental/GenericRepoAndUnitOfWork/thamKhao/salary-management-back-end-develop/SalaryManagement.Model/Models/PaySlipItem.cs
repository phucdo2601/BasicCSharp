using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class PaySlipItem
    {
        public string PaySlipItemId { get; set; }
        public string PaySlipItemName { get; set; }
        public string Attribute { get; set; }
        [JsonIgnore]
        [Encrypted]
        public string ValueEncrypt { get; set; }
        [JsonIgnore]
        [Encrypted]
        public string QuantityEncrypt { get; set; }
        public string FormulaAttributeId { get; set; }
        public string PaySlipId { get; set; }

        [NotMapped]
        public double Value
        {
            get { return double.Parse(ValueEncrypt); }
            set { }
        }

        [NotMapped]
        public double Quantity
        {
            get { return double.Parse(QuantityEncrypt); }
            set { }
        }

        public virtual FormulaAttribute FormulaAttribute { get; set; }
        public virtual PaySlip PaySlip { get; set; }
    }
}
