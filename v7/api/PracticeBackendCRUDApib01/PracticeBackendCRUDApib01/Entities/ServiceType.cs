﻿using System.ComponentModel.DataAnnotations;

namespace PracticeBackendCRUDApib01.Entities
{
    public class ServiceType
    {
        [Key]
        public Guid ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public DateTime CreateDate { get; set; }

        public List<Service> Services { get; set; }
    }
}