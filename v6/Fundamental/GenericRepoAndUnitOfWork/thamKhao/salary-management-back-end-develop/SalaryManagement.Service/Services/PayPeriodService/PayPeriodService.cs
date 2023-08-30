using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace SalaryManagement.Services.PayPeriodService
{
    public class PayPeriodService : IPayPeriodService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PayPeriodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<PayPeriod> GetPayPeriods()
        {
            var payPeriods = _unitOfWork.PayPeriod.FindInclude(e => e.PayPolicy, e => e.Semester).OrderByDescending(e => e.Semester.EndDate).ToList();
            return payPeriods;
        }

        public PayPeriod GetPayPeriod(string id)
        {
            var payPeriod = _unitOfWork.PayPeriod.FindIncludeByCondition(e => e.PayPeriodId.Equals(id), e => e.PayPolicy, e => e.Semester).FirstOrDefault();

            if (payPeriod == null) throw new Exception("Not found PayPeriod");

            return payPeriod;
        }

        public int CreatePayPeriod(string payPeriodId, PayPeriodRequest payPeriodRequest)
        {
            var payPeriodName = _unitOfWork.PayPeriod.FindByCondition(e => e.PayPeriodName.ToLower().Equals(payPeriodRequest.PayPeriodName.ToLower())).Select(e => e.PayPeriodName).FirstOrDefault();
            if (payPeriodName != null) throw new Exception($"PayPeriodName '{payPeriodName}' already exists");

            var payPolicy = _unitOfWork.PayPolicy.Find(payPeriodRequest.PayPolicyId);
            if (payPolicy == null) throw new Exception("Not found PayPolicy");

            var semester = _unitOfWork.Semester.Find(payPeriodRequest.SemesterId);
            if (semester == null) throw new Exception("Not found Semester");

            var payPeriodCheck = _unitOfWork.PayPeriod.FindByCondition(e => e.SemesterId.Equals(payPeriodRequest.SemesterId)).FirstOrDefault();
            if (payPeriodCheck != null) throw new Exception("Semester is already exists in another PayPeriod");

            PayPeriod payPeriod = new()
            {
                PayPeriodId = payPeriodId,
                PayPeriodName = payPeriodRequest.PayPeriodName,
                CreateDate = DateTime.Now,
                PayPolicyId = payPeriodRequest.PayPolicyId,
                SemesterId = payPeriodRequest.SemesterId
            };

            _unitOfWork.PayPeriod.Create(payPeriod);

            int created = _unitOfWork.Complete();

            return created;
        }

        public int UpdatePayPeriod(string payPeriodId, PayPeriodRequest payPeriodRequest)
        {
            int update = -1;

            var payPeriod = _unitOfWork.PayPeriod.Find(payPeriodId);
            if (payPeriod == null) throw new Exception("Not found PayPeriod");

            var payPolicy = _unitOfWork.PayPolicy.Find(payPeriodRequest.PayPolicyId);
            if (payPolicy == null) throw new Exception("Not found PayPolicy");

            var semester = _unitOfWork.Semester.Find(payPeriodRequest.SemesterId);
            if (semester == null) throw new Exception("Not found Semester");

            var payPeriodCheck = _unitOfWork.PayPeriod.FindByCondition(e => e.SemesterId.Equals(payPeriodRequest.SemesterId) && !e.SemesterId.Equals(payPeriod.SemesterId)).FirstOrDefault();
            if (payPeriodCheck != null) throw new Exception("Semester is already exists in another PayPeriod");

            if (payPeriod != null)
            {
                var payPeriodName = _unitOfWork.PayPeriod.FindByCondition(e => !e.PayPeriodId.Equals(payPeriod.PayPeriodId) && e.PayPeriodName.ToLower().Equals(payPeriodRequest.PayPeriodName.ToLower())).Select(e => e.PayPeriodName).FirstOrDefault();
                if (payPeriodName != null) throw new Exception($"PayPeriodName '{payPeriodName}' already exists");

                if (_unitOfWork.PaySlip.FindAll().Any(e => e.PayPeriodId.Equals(payPeriod.PayPeriodId)))
                    throw new Exception($"PayPeriod '{payPeriod.PayPeriodName}' already existing in PaySlip");

                payPeriod.PayPeriodName = payPeriodRequest.PayPeriodName;
                payPeriod.PayPolicyId = payPeriodRequest.PayPolicyId;
                payPeriod.SemesterId = payPeriodRequest.SemesterId;

                _unitOfWork.PayPeriod.Update(payPeriod);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public object GetPayMonthsPeriods(PayPeriodMonthsRequest payPeriodRequest)
        {
            var payPeriod = _unitOfWork.PayPeriod.FindIncludeByCondition(e => e.PayPeriodId.Equals(payPeriodRequest.PayPeriodId), e => e.Semester).FirstOrDefault();
            if (payPeriod == null) throw new Exception("Not found PayPolicy");

            var lecturer = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(payPeriodRequest.LecturerId), e => e.LecturerType).FirstOrDefault();
            if (lecturer == null) throw new Exception("Not found Lecturer");

            dynamic data = new ExpandoObject();

            //if (payPeriod.Semester.StartDate != null && payPeriod.Semester.EndDate != null){}

            var startDate = (DateTime)payPeriod.Semester.StartDate;
            var endDate = (DateTime)payPeriod.Semester.EndDate;

            List<int> months = new();
            while (startDate <= endDate)
            {
                if (!_unitOfWork.PaySlip.FindAll().Any(e => e.EndDate.Month == startDate.Month
                    && e.PayPeriodId.Equals(payPeriod.PayPeriodId) && e.LecturerId.Equals(lecturer.LecturerId)))
                {
                    months.Add(startDate.Month);
                }
                startDate = startDate.AddMonths(1);
            }

            data.months = months;
            data.year = endDate.Year;
            data.statisticsStartDay = lecturer.LecturerType.StatisticsStartDay;
            data.statisticsEndDay = lecturer.LecturerType.StatisticsEndDay;

            return data;
        }
    }
}
