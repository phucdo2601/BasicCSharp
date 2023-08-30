using System;

namespace SalaryManagement.Requests
{
    public class TaskAssignerRequest
    {
        public string AssignerId { get; set; }
        public string StatusId { get; set; }
    }

    public class TaskLecturerRequest
    {
        public string LecturerId { get; set; }
        public string StatusId { get; set; }
    }

    public class TaskRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public DateTime? PlanStartDate { get; set; }
        public DateTime? PlanEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public string StatusId { get; set; }
    }

    public class ActivityRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public string TaskInfoId { get; set; }
        public string AssignerId { get; set; }
        public string LecturerId { get; set; }
    }

    public class StatusActivityRequest
    {
        public string StatusId { get; set; }
    }

    public class StatusTaskRequest
    {
        public string StatusId { get; set; }
    }
}
