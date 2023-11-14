﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeBackendCRUDApib01.Entities
{
    public class Service
    {
        [Key]
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string MainContent { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public float? DiscountPercent { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid StatusId { get; set; }
        public Guid ServiceTypeId { get; set; }

        [ForeignKey("ServiceTypeId")]
        public ServiceType ServiceType { get; set; }

        public List<ProductService> ProductServices { get; set; }


    }
}