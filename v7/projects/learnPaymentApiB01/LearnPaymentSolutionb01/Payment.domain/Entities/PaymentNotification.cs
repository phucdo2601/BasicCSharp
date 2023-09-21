using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.domain.Entities
{
    public class PaymentNotification
    {
        public string Id { get; set; } = string.Empty;
        public string? PaymentRefId { get; set; } = string.Empty;
        public DateTime? NotiDate { get; set; }
        public decimal? NotiAmount { get; set; }
        public string? NotiContent { get; set; } = string.Empty;
        public string? NotiMessage { get; set; } = string.Empty;
        public string? NotiSignature { get; set; } = string.Empty;
        public string? PaymentId { get; set; } = string.Empty;
        public string? MerchantId { get; set; } = string.Empty;
        public string? NotiStatus { get; set; } = string.Empty;
        public string? NotiResDate { get; set; } = string.Empty;
        public string? NotiResMessage { get; set; } = string.Empty;
        public string? NotiResHttpCode { get; set; } = string.Empty;
    }
}
