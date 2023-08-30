using SalaryManagement.Models;
using SalaryManagement.Requests;
using System.Collections.Generic;

namespace SalaryManagement.Services.PayPeriodService
{
    public interface IPayPeriodService
    {
        List<PayPeriod> GetPayPeriods();
        PayPeriod GetPayPeriod(string id);
        int CreatePayPeriod(string payPeriodId, PayPeriodRequest payPeriodRequest);
        int UpdatePayPeriod(string payPeriodId, PayPeriodRequest payPeriodRequest);
        object GetPayMonthsPeriods(PayPeriodMonthsRequest payPeriodRequest);
    }
}
