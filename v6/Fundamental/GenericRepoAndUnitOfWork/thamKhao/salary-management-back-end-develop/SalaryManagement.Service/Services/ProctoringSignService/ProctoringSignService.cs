using Microsoft.AspNetCore.Http;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Utility.Excel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace SalaryManagement.Services.ProctoringSignService
{
    public class ProctoringSignService : IProctoringSignService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProctoringSignService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Lecturer> GetProctoringSigns()
        {
            List<Lecturer> lecturers = new();

            var lecturerIds = _unitOfWork.ProctoringSign.FindAll().Select(e => e.LecturerId).ToList();

            lecturerIds = lecturerIds.Distinct().ToList();

            foreach (var lecturerId in lecturerIds)
            {
                var lecturer = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(lecturerId), e => e.GeneralUserInfo, e => e.LecturerType).FirstOrDefault();

                lecturers.Add(lecturer);
            }

            lecturers = lecturers.OrderBy(e => e.GeneralUserInfo.UserName).ToList();

            return lecturers;
        }

        public List<dynamic> GetProctoringSignsByDate(DateTime fromDate, DateTime toDate)
        {
            List<dynamic> dataList = new();

            var lecturerIds = _unitOfWork.Lecturer.FindAll().Select(e => e.LecturerId).ToList();

            foreach (var lecturerId in lecturerIds)
            {
                var timeSlots = _unitOfWork.ProctoringSign.FindByCondition(e => e.LecturerId.Equals(lecturerId)
                                    && e.TimeSlot.Date >= fromDate && e.TimeSlot.Date <= toDate)
                                    .Select(e => e.TimeSlot).ToList();

                var lecturer = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(lecturerId), e => e.GeneralUserInfo, e => e.LecturerType).FirstOrDefault();
                if (timeSlots.Count > 0)
                {
                    dynamic data = new ExpandoObject();
                    data.lecturer = lecturer;

                    data.timeSlots = timeSlots;

                    dataList.Add(data);
                }
            }

            return dataList;
        }

        public List<TimeSlot> GetProctoringSignByLecturer(string lecturerId)
        {
            var timeSlots = _unitOfWork.ProctoringSign.FindByCondition(e => e.LecturerId.Equals(lecturerId))
                                .Select(e => e.TimeSlot).OrderByDescending(e => e.EndTime).ToList();

            return timeSlots;
        }

        public List<TimeSlot> GetProctoringSignDateByLecturer(string lecturerId, DateTime fromDate, DateTime toDate)
        {
            var timeSlots = _unitOfWork.ProctoringSign.FindByCondition(e => e.LecturerId.Equals(lecturerId)
                                && e.TimeSlot.Date >= fromDate && e.TimeSlot.Date <= toDate)
                                .Select(e => e.TimeSlot).OrderByDescending(e => e.EndTime).ToList();

            return timeSlots;
        }

        public List<TimeSlot> GetProctoringSignCurrentByLecturer(string lecturerId)
        {
            var timeSlots = _unitOfWork.ProctoringSign.FindByCondition(e => e.LecturerId.Equals(lecturerId)
                                && e.TimeSlot.Date >= DateTime.Now)
                                .Select(e => e.TimeSlot).OrderByDescending(e => e.EndTime).ToList();

            return timeSlots;
        }

        public List<TimeSlot> GetProctoringSignHistoryByLecturer(string lecturerId)
        {
            var timeSlots = _unitOfWork.ProctoringSign.FindByCondition(e => e.LecturerId.Equals(lecturerId)
                                && e.TimeSlot.Date < DateTime.Now)
                                .Select(e => e.TimeSlot).OrderByDescending(e => e.EndTime).ToList();

            return timeSlots;
        }

        public List<object> ReadProtoringSignExcel(IFormFile file)
        {
            List<object> dataList;
            try
            {
                ExcelManage excelManage = new();
                dataList = ExcelManage.ReadTestProctoringSignExcel(file);
            }
            catch (Exception)
            {
                throw;
            }

            return dataList;
        }

        public int CreateProtoringSignExcel(IFormFile file)
        {
            ExcelManage excelManage = new();
            ProctoringSignRequest proctors = ExcelManage.ReadFileProctoringSignExcel(file);

            if (proctors != null)
            {
                //Read AccountFE
                List<string> lecturerIds = new();
                proctors.UserSigns.ForEach(userSign =>
                {
                    if (userSign.AccountFE != null)
                    {
                        var lecturerId = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.GeneralUserInfo.Gmail.ToLower().Contains(userSign.AccountFE.ToLower() + "@"), e => e.GeneralUserInfo).Select(e => e.LecturerId).FirstOrDefault();

                        lecturerIds.Add(lecturerId);
                    }
                });

                //Read data
                for (int i = 0; i < proctors.DateSign.Dates.Count; i++)
                {
                    if (proctors.DateSign.StartDates[i] != null && proctors.DateSign.EndDates[i] != null)
                    {
                        var startTime = (DateTime)proctors.DateSign.StartDates[i];
                        var endTime = (DateTime)proctors.DateSign.EndDates[i];

                        TimeSlot timeSlot = new()
                        {
                            TimeSlotId = Guid.NewGuid().ToString(),
                            Date = startTime.Date,
                            StartTime = startTime,
                            EndTime = endTime,
                            Value = proctors.Value
                        };

                        var tSlot = _unitOfWork.TimeSlot.FindByCondition(e => e.Date == timeSlot.Date
                                        && e.StartTime == timeSlot.StartTime
                                        && e.EndTime == timeSlot.EndTime).FirstOrDefault();

                        if (tSlot == null) _unitOfWork.TimeSlot.Create(timeSlot);
                        else timeSlot = tSlot;

                        var userSigns = proctors.UserSigns;

                        foreach (var item in userSigns.Select((value, i) => new { i, value }))
                        {
                            var userSign = item.value;
                            var index = item.i;

                            if (userSign.AccountFE != null)
                            {
                                var lecturerId = lecturerIds[index];

                                int signSlot = 0;
                                if (userSign.TimeSlots[i] != null)
                                {
                                    if (userSign.TimeSlots[i] == 1)
                                    {
                                        signSlot = 1;
                                    }
                                }

                                if (lecturerId != null && signSlot == 1)
                                {
                                    ProctoringSign proctoringSign = new()
                                    {
                                        ProctoringSignId = Guid.NewGuid().ToString(),
                                        TimeSlotId = timeSlot.TimeSlotId,
                                        LecturerId = lecturerId
                                    };

                                    var pSign = _unitOfWork.ProctoringSign.FindByCondition(e => e.TimeSlotId.Equals(proctoringSign.TimeSlotId)
                                                        && e.LecturerId.Equals(proctoringSign.LecturerId)).FirstOrDefault();

                                    if (pSign == null) _unitOfWork.ProctoringSign.Create(proctoringSign);
                                }
                            }
                        }
                    }
                }
            }

            int created = _unitOfWork.Complete();

            return created;
        }

        public int CreateProtoringSign(ProctoringSignExcelRequest proctors)
        {
            if (proctors != null)
            {
                //Read AccountFE
                List<string> lecturerIds = new();
                proctors.UserSigns.ForEach(userSign =>
                {
                    if (userSign.AccountFE != null)
                    {
                        var lecturerId = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.GeneralUserInfo.Gmail.ToLower().Contains(userSign.AccountFE.ToLower() + "@"), e => e.GeneralUserInfo).Select(e => e.LecturerId).FirstOrDefault();

                        lecturerIds.Add(lecturerId);
                    }
                });

                //Read data
                for (int i = 0; i < proctors.DateProctoringSign.StartDates.Count; i++)
                {
                    if (proctors.DateProctoringSign.StartDates[i] != null && proctors.DateProctoringSign.EndDates[i] != null)
                    {
                        var startTime = (DateTime)proctors.DateProctoringSign.StartDates[i];
                        var endTime = (DateTime)proctors.DateProctoringSign.EndDates[i];

                        TimeSlot timeSlot = new()
                        {
                            TimeSlotId = Guid.NewGuid().ToString(),
                            Date = startTime.Date,
                            StartTime = startTime,
                            EndTime = endTime,
                            Value = proctors.Value
                        };

                        var tSlot = _unitOfWork.TimeSlot.FindByCondition(e => e.Date == timeSlot.Date
                                        && e.StartTime == timeSlot.StartTime
                                        && e.EndTime == timeSlot.EndTime).FirstOrDefault();

                        if (tSlot == null) _unitOfWork.TimeSlot.Create(timeSlot);
                        else timeSlot = tSlot;

                        var userSigns = proctors.UserSigns;

                        foreach (var item in userSigns.Select((value, i) => new { i, value }))
                        {
                            var userSign = item.value;
                            var index = item.i;

                            if (userSign.AccountFE != null)
                            {
                                var lecturerId = lecturerIds[index];

                                int signSlot = 0;
                                if (i < userSign.TimeSlots.Count)
                                {
                                    if (userSign.TimeSlots[i] != null)
                                    {
                                        if (userSign.TimeSlots[i] == 1)
                                        {
                                            signSlot = 1;
                                        }
                                    }
                                }

                                if (lecturerId != null && signSlot == 1)
                                {
                                    ProctoringSign proctoringSign = new()
                                    {
                                        ProctoringSignId = Guid.NewGuid().ToString(),
                                        TimeSlotId = timeSlot.TimeSlotId,
                                        LecturerId = lecturerId
                                    };

                                    var pSign = _unitOfWork.ProctoringSign.FindByCondition(e => e.TimeSlotId.Equals(proctoringSign.TimeSlotId)
                                                        && e.LecturerId.Equals(proctoringSign.LecturerId)).FirstOrDefault();

                                    if (pSign == null) _unitOfWork.ProctoringSign.Create(proctoringSign);
                                }
                            }
                        }
                    }
                }
            }

            int created = _unitOfWork.Complete();

            return created;
        }

        public dynamic GetProctoringSignsInMonth(string lecturerId, int month)
        {
            dynamic data = new ExpandoObject();

            var timeSlots = _unitOfWork.ProctoringSign.FindByCondition(e => e.LecturerId.Equals(lecturerId)
                                && e.TimeSlot.Date.Month == month && e.TimeSlot.Date.Year == DateTime.Now.Year)
                                .Select(e => e.TimeSlot).ToList();

            var pending = timeSlots.Count(e => e.StartTime >= DateTime.Now && e.EndTime >= DateTime.Now);
            var processing = timeSlots.Count(e => e.StartTime <= DateTime.Now && e.EndTime >= DateTime.Now);
            var finished = timeSlots.Count(e => e.StartTime <= DateTime.Now && e.EndTime <= DateTime.Now);

            data.pending = pending;
            data.processing = processing;
            data.finished = finished;

            data.timeSlots = timeSlots;

            return data;
        }

        public GeneralUserInfo GetUser(string userId)
        {
            var user = _unitOfWork.GeneralUserInfo.Find(userId);
            user.Password = null;
            return user;
        }

        public List<string> GetUserIdsOnDate(DateTime date)
        {
            var userIds = _unitOfWork.ProctoringSign.FindIncludeByCondition(e => e.TimeSlot.Date.Date == date.Date,
                                    e => e.TimeSlot, e => e.Lecturer).Select(e => e.Lecturer.GeneralUserInfoId).ToList();
            userIds = userIds.Distinct().ToList();

            return userIds;
        }

        public List<TimeSlot> GetTimeSlotsLecturerSigned(string userId, DateTime date)
        {
            var user = _unitOfWork.GeneralUserInfo.Find(userId);
            if (user == null) throw new Exception("Not found User");

            var timeSlots = _unitOfWork.ProctoringSign.FindByCondition(e => e.Lecturer.GeneralUserInfoId.Equals(userId)
                                    && e.TimeSlot.Date.Date == date.Date).Select(e => e.TimeSlot).ToList();

            return timeSlots;
        }
    }
}
