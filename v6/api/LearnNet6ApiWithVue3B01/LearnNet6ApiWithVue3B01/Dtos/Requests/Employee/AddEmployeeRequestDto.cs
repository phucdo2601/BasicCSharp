namespace LearnNet6ApiWithVue3B01.Dtos.Requests.Employee
{
    public class AddEmployeeRequestDto
    {
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }
    }
}
