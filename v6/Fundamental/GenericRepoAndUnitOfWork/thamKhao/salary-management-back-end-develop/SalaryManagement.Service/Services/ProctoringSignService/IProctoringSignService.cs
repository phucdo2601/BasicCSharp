using Microsoft.AspNetCore.Http;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using System;
using System.Collections.Generic;

namespace SalaryManagement.Services.ProctoringSignService
{
    public interface IProctoringSignService
    {
        List<Lecturer> GetProctoringSigns();
        List<dynamic> GetProctoringSignsByDate(DateTime fromDate, DateTime toDate);
        List<TimeSlot> GetProctoringSignByLecturer(string lecturerId);
        List<TimeSlot> GetProctoringSignDateByLecturer(string lecturerId, DateTime fromDate, DateTime toDate);
        List<TimeSlot> GetProctoringSignCurrentByLecturer(string lecturerId);
        List<TimeSlot> GetProctoringSignHistoryByLecturer(string lecturerId);
        List<object> ReadProtoringSignExcel(IFormFile file);
        int CreateProtoringSignExcel(IFormFile file);
        int CreateProtoringSign(ProctoringSignExcelRequest proctors);
        dynamic GetProctoringSignsInMonth(string lecturerId, int month);
        GeneralUserInfo GetUser(string userId);
        List<string> GetUserIdsOnDate(DateTime date);
        List<TimeSlot> GetTimeSlotsLecturerSigned(string userId, DateTime date);
    }
}
