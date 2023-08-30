using SalaryManagement.Models;
using SalaryManagement.Requests;
using System.Collections.Generic;

namespace SalaryManagement.Services.PaySlipService
{
    public interface IPaySlipService
    {
        dynamic GetFormulaLecturer(string lecturerId);
        dynamic GetFormulaUpdateLecturer(string lecturerId);
        int CreatePaySlip(string paySlipId, PaySlipRequest paySlipRequest);
        int CreatePaySlipItem(PaySlipDetailRequest paySlipRequest);
        List<PayPeriod> GetPayPeriods(string lecturerId);
        List<dynamic> GetPaySlipsInPayPeriods(string lecturerId);
        List<dynamic> GetPayPeriods1Year(PaySlip1YearRequest paySlipRequest);
        List<PaySlip> GetPaySlipsByLecturer(string lecturerId);
        List<PaySlip> GetPaySlipsMonthsByLecturer(PaySlipByMonthRequest paySlipRequest);
        List<PaySlip> GetPaySlipsInPayPeriod(string payPeriodId, string lecturerId);
        dynamic GetPaySlip(string paySlipId);
        dynamic GetPaySlipByGroup(string paySlipId);
        List<PayPeriod> GetAllPayPeriod();
        List<dynamic> GetPaySlips();
        object PostCheckSalary(PaySlipCheckRequest paySlipCheckRequest);
        object CheckSalaryFull(PaySlipCheckRequest paySlipCheckRequest);
        List<TeachingSummary> GetTeachingSummaries();
        object GetTeachingSummary(string teachingSummaryId);
        object GetTeachingSummaryByPaySlip(string paySlipId);
        int CreateTeachingSummary(string teachingSummaryId, TeachingSummaryRequest teachingSummaryRequest);
        int UpdatePaySlip(string paySlipId, PaySlipRequest paySlipRequest);
        int UpdatePaySlipItem(PaySlipDetailRequest paySlipRequest);
        dynamic GetHoursProctoringSign(string paySlipId);
        List<PaySlip> GetPaySlipsInYear(string lecturerId, int year);
        dynamic GetFormulaTax();
        object CheckSalaryTax(PaySlipCheckTax paySlipCheckRequest);
    }
}
