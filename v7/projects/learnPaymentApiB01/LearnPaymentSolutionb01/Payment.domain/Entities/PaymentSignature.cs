﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.domain.Entities
{
    public class PaymentSignature
    {
        public string Id { get; set; } = string.Empty;
        public string? SignValue { get; set; } = string.Empty;
        public string? SignAlgo { get; set; } = string.Empty;
        public DateTime? SignDate { get; set; }
        public string? SignOwn { get; set; } = string.Empty;
        public string? PaymentId { get; set; } = string.Empty;
        private bool IsValid { get; set; }
    }
}