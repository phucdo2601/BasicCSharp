﻿namespace PracticeBackendCRUDApib01.Entities
{
    public class UserRole
    {
        public Guid UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
    }
}
