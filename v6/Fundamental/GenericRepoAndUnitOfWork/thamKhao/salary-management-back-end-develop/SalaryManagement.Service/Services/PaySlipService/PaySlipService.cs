using org.matheval;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryManagement.Services.PaySlipService
{
    public class PaySlipService : IPaySlipService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaySlipService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public dynamic GetFormulaLecturer(string lecturerId)
        {
            var lecturer = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(lecturerId), e => e.LecturerType).FirstOrDefault();

            if (lecturer == null) throw new Exception("Not found Lecturer.");

            if (lecturer.LecturerType == null) throw new Exception("Not found LecturerType of Lecturer.");

            if (lecturer.LecturerType.FormulaId == null) throw new Exception("Not found Formula of Lecturer.");

            string formulaId = lecturer.LecturerType.FormulaId;

            var formula = _unitOfWork.Formula.Find(formulaId);

            dynamic data = new ExpandoObject();
            data.formula = formula;

            var formulaAttributes = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(formulaId)
                                            && ((e.FormulaAttribute.FormulaAttributeType == null && e.FormulaAttribute.Value == null)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)), e => e.FormulaAttribute.FormulaAttributeType, e => e.FormulaAttribute.GroupAttribute)
                                            .Select(e => e.FormulaAttribute).OrderBy(e => e.Attribute).ToList();

            formulaAttributes.ForEach(formulaAttribute =>
            {
                var departments = _unitOfWork.FormulaAttributeDepartment.FindByCondition(e => e.FormulaAttributeId.Equals(formulaAttribute.FormulaAttributeId)).Select(e => e.Department).ToList();
                formulaAttribute.Departments = departments;
            });

            data.formulaAttributes = formulaAttributes;

            return data;
        }

        public dynamic GetFormulaUpdateLecturer(string paySlipId)
        {
            var paySlip = _unitOfWork.PaySlip.Find(paySlipId);
            if (paySlip == null) throw new Exception("Not found PaySlip");

            var lecturer = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlip.LecturerId), e => e.LecturerType).FirstOrDefault();
            if (lecturer == null) throw new Exception("Not found Lecturer.");
            if (lecturer.LecturerType == null) throw new Exception("Not found LecturerType of Lecturer.");
            if (lecturer.LecturerType.FormulaId == null) throw new Exception("Not found Formula of Lecturer.");

            string formulaId = lecturer.LecturerType.FormulaId;

            var formula = _unitOfWork.Formula.Find(formulaId);

            dynamic data = new ExpandoObject();
            data.formula = formula;

            var formulaAttributes = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(formulaId)
                                            && ((e.FormulaAttribute.FormulaAttributeType == null && e.FormulaAttribute.Value == null)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)), e => e.FormulaAttribute.FormulaAttributeType, e => e.FormulaAttribute.GroupAttribute)
                                            .Select(e => e.FormulaAttribute).OrderBy(e => e.Attribute).ToList();

            var paySlipItems = _unitOfWork.PaySlipItem.FindIncludeByCondition(e => e.PaySlipId.Equals(paySlipId), e => e.FormulaAttribute.FormulaAttributeType, e => e.FormulaAttribute.GroupAttribute).ToList();

            List<dynamic> dataAttributes = new();

            formulaAttributes.ForEach(formulaAttribute =>
            {
                double value = 0;

                var paySlipItem = paySlipItems.Where(e => e.FormulaAttributeId.Equals(formulaAttribute.FormulaAttributeId)).FirstOrDefault();
                if (paySlipItem != null)
                {
                    var typeAttr = paySlipItem.FormulaAttribute.FormulaAttributeType;
                    if (typeAttr == null) value = (double)paySlipItem.Value;
                    else if (typeAttr.Type.Equals(AttributeSalary.T_Quantity) || typeAttr.Type.Equals(AttributeSalary.T_Fi))
                    {
                        value = (double)paySlipItem.Quantity;
                    }
                }

                var departments = _unitOfWork.FormulaAttributeDepartment.FindByCondition(e => e.FormulaAttributeId.Equals(formulaAttribute.FormulaAttributeId)).Select(e => e.Department).ToList();
                formulaAttribute.Departments = departments;

                dynamic attr = new ExpandoObject();
                attr.value = value;
                attr.formulaAttribute = formulaAttribute;

                dataAttributes.Add(attr);
            });

            data.formulaAttributes = dataAttributes;

            return data;
        }

        public int CreatePaySlip(string paySlipId, PaySlipRequest paySlipRequest)
        {
            var payPeriod = _unitOfWork.PayPeriod.Find(paySlipRequest.PayPeriodId);
            if (payPeriod == null) throw new Exception("Not found PayPeriod");

            var semester = _unitOfWork.Semester.Find(payPeriod.SemesterId);
            if (semester == null) throw new Exception("Not found Semester in PayPeriod");

            var payPolicy = _unitOfWork.PayPolicy.Find(payPeriod.PayPolicyId);
            if (payPolicy == null) throw new Exception("Not found PayPolicy in PayPeriod");

            var lecturer = _unitOfWork.Lecturer.Find(paySlipRequest.LecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var lecturerType = _unitOfWork.LecturerType.Find(lecturer.LecturerTypeId);
            if (lecturerType == null) throw new Exception("Not found LecturerType of Lecturer.");

            if (lecturerType.FormulaId == null) throw new Exception("Not found Formula of Lecturer.");

            if (paySlipRequest.StartDate.Day != lecturerType.StatisticsStartDay)
            {
                throw new Exception($"StartDate must be {lecturerType.StatisticsStartDay}");
            }

            if (paySlipRequest.EndDate.Day != lecturerType.StatisticsEndDay)
            {
                throw new Exception($"StartDate must be {lecturerType.StatisticsEndDay}");
            }

            if (paySlipRequest.StartDate > paySlipRequest.EndDate)
            {
                throw new Exception("StartDate must be less than EndDate");
            }

            var startDate = paySlipRequest.StartDate.Month;

            if (paySlipRequest.StartDate.Month == 12) startDate = 1;

            if (startDate < semester.StartDate.Month - 1 || semester.EndDate.Month < startDate
                || paySlipRequest.EndDate.Month < semester.StartDate.Month || semester.EndDate.Month < paySlipRequest.EndDate.Month)
            {
                throw new Exception($"Month of StartDate, EndDate must be from {semester.StartDate.Month - 1} to {semester.EndDate.Month} (Semester {semester.SemesterName})");
            }

            string payPeriodId = payPeriod.PayPeriodId;

            var paySlips = _unitOfWork.PaySlip.FindByCondition(e => e.PayPeriodId.Equals(payPeriodId) && e.LecturerId.Equals(paySlipRequest.LecturerId)).ToList();
            paySlips.ForEach(paySlip =>
            {
                if ((paySlip.StartDate <= paySlipRequest.StartDate && paySlipRequest.StartDate <= paySlip.EndDate)
                      || (paySlip.StartDate <= paySlipRequest.EndDate && paySlipRequest.EndDate <= paySlip.EndDate)
                      || (paySlipRequest.StartDate <= paySlip.StartDate && paySlip.StartDate <= paySlipRequest.EndDate)
                      || (paySlipRequest.StartDate <= paySlip.EndDate && paySlip.EndDate <= paySlipRequest.EndDate))
                {
                    throw new Exception("StartDate or EndDate already exists for another time on another PaySlip.");
                }
            });

            var formula = _unitOfWork.Formula.Find(lecturerType.FormulaId);

            PaySlip paySlip = new()
            {
                PaySlipId = paySlipId,
                PaySlipName = "Pay Slip " + paySlipRequest.EndDate.ToString("MMMMMMMMM"),
                CalculationFormula = formula.CalculationFormula,
                TotalEncrypt = "0",
                StartDate = paySlipRequest.StartDate,
                EndDate = paySlipRequest.EndDate,
                CreateDate = DateTime.Now,
                FormulaId = lecturerType.FormulaId,
                PayPeriodId = payPeriodId,
                LecturerId = lecturer.LecturerId
            };

            _unitOfWork.PaySlip.Create(paySlip);

            int created = _unitOfWork.Complete();

            return created;
        }

        public int UpdatePaySlip(string paySlipId, PaySlipRequest paySlipRequest)
        {
            var payPeriod = _unitOfWork.PayPeriod.Find(paySlipRequest.PayPeriodId);
            if (payPeriod == null) throw new Exception("Not found PayPeriod");

            var semester = _unitOfWork.Semester.Find(payPeriod.SemesterId);
            if (semester == null) throw new Exception("Not found Semester in PayPeriod");

            var payPolicy = _unitOfWork.PayPolicy.Find(payPeriod.PayPolicyId);
            if (payPolicy == null) throw new Exception("Not found PayPolicy in PayPeriod");

            var lecturer = _unitOfWork.Lecturer.Find(paySlipRequest.LecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var lecturerType = _unitOfWork.LecturerType.Find(lecturer.LecturerTypeId);
            if (lecturerType == null) throw new Exception("Not found LecturerType of Lecturer.");

            if (lecturerType.FormulaId == null) throw new Exception("Not found Formula of Lecturer.");

            var paySlip = _unitOfWork.PaySlip.Find(paySlipId);
            if (paySlip == null) throw new Exception("Not found PaySlip");

            if (paySlipRequest.StartDate.Day != lecturerType.StatisticsStartDay)
            {
                throw new Exception($"StartDate must be {lecturerType.StatisticsStartDay}");
            }

            if (paySlipRequest.EndDate.Day != lecturerType.StatisticsEndDay)
            {
                throw new Exception($"StartDate must be {lecturerType.StatisticsEndDay}");
            }

            if (paySlipRequest.StartDate > paySlipRequest.EndDate)
            {
                throw new Exception("StartDate must be less than EndDate");
            }

            var startDate = paySlipRequest.StartDate.Month;

            if (paySlipRequest.StartDate.Month == 12) startDate = 1;

            if (startDate < semester.StartDate.Month - 1 || semester.EndDate.Month < startDate
                || paySlipRequest.EndDate.Month < semester.StartDate.Month || semester.EndDate.Month < paySlipRequest.EndDate.Month)
            {
                throw new Exception($"Month of StartDate, EndDate must be from {semester.StartDate.Month - 1} to {semester.EndDate.Month} (Semester {semester.SemesterName})");
            }

            string payPeriodId = payPeriod.PayPeriodId;

            var paySlips = _unitOfWork.PaySlip.FindByCondition(e => e.PayPeriodId.Equals(payPeriodId) &&
                                                !e.PaySlipId.Equals(paySlipId) && e.LecturerId.Equals(paySlipRequest.LecturerId)).ToList();
            paySlips.ForEach(paySlip =>
            {
                if ((paySlip.StartDate <= paySlipRequest.StartDate && paySlipRequest.StartDate <= paySlip.EndDate)
                      || (paySlip.StartDate <= paySlipRequest.EndDate && paySlipRequest.EndDate <= paySlip.EndDate)
                      || (paySlipRequest.StartDate <= paySlip.StartDate && paySlip.StartDate <= paySlipRequest.EndDate)
                      || (paySlipRequest.StartDate <= paySlip.EndDate && paySlip.EndDate <= paySlipRequest.EndDate))
                {
                    throw new Exception("StartDate or EndDate already exists for another time on another PaySlip.");
                }
            });

            var formula = _unitOfWork.Formula.Find(lecturerType.FormulaId);

            if (paySlip != null)
            {
                paySlip.PaySlipName = "Pay Slip " + paySlipRequest.EndDate.ToString("MMMMMMMMM");
                paySlip.CalculationFormula = formula.CalculationFormula;
                paySlip.StartDate = paySlipRequest.StartDate;
                paySlip.EndDate = paySlipRequest.EndDate;
                paySlip.FormulaId = lecturerType.FormulaId;
                paySlip.PayPeriodId = payPeriodId;
                paySlip.LecturerId = lecturer.LecturerId;
            };

            var teachingSummary = _unitOfWork.TeachingSummary.FindByCondition(e => e.PaySlipId.Equals(paySlipId)).FirstOrDefault();

            if (teachingSummary != null)
            {
                //Remove TeachingSummaryDetail
                _unitOfWork.TeachingSummaryDetail.RemoveRange(_unitOfWork.TeachingSummaryDetail.FindByCondition(e => e.TeachingSummaryId.Equals(teachingSummary.TeachingSummaryId)));

                _unitOfWork.TeachingSummary.Remove(teachingSummary);
            }

            _unitOfWork.PaySlip.Update(paySlip);

            int update = _unitOfWork.Complete();

            return update;
        }

        public int CreatePaySlipItem(PaySlipDetailRequest paySlipRequest)
        {
            var paySlip = _unitOfWork.PaySlip.Find(paySlipRequest.PaySlipId);
            if (paySlip == null) throw new Exception("Not found PaySlip");

            var lecturer = _unitOfWork.Lecturer.Find(paySlip.LecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var lecturerType = _unitOfWork.LecturerType.Find(lecturer.LecturerTypeId);
            if (lecturerType == null) throw new Exception("Not found LecturerType of Lecturer.");

            if (lecturerType.FormulaId == null) throw new Exception("Not found Formula of Lecturer.");

            var formula = _unitOfWork.Formula.Find(lecturerType.FormulaId);

            List<string> attrInFormula = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(lecturerType.FormulaId)
                                            && ((e.FormulaAttribute.FormulaAttributeType == null && e.FormulaAttribute.Value == null)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)), e => e.FormulaAttribute.FormulaAttributeType)
                                            .Select(e => e.FormulaAttribute.Attribute).ToList();

            if (paySlipRequest.Attributes.Count > attrInFormula.Count) throw new Exception("Some attribute are not in the formula.");

            paySlipRequest.Attributes.ForEach(attribute =>
            {
                attrInFormula.Remove(attribute.Attribute);
            });

            if (attrInFormula.Count > 0)
            {
                throw new Exception("Some of the attribute are missing: " + string.Join(", ", attrInFormula));
            }

            var formulaAttributes = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(lecturerType.FormulaId),
                                    e => e.FormulaAttribute.FormulaAttributeType).Select(e => e.FormulaAttribute).ToList();

            //var values = new Dictionary<string, object>();
            Expression expression = new();

            formulaAttributes.ForEach(formulaAttribute =>
            {
                double value = 0;
                double quantity = 0;

                var attr = paySlipRequest.Attributes.Where(e => e.Attribute.Equals(formulaAttribute.Attribute)).FirstOrDefault();

                if (formulaAttribute.FormulaAttributeTypeId != null)
                {
                    if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.BASIC))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlip.LecturerId)).FirstOrDefault();
                        var basicSalary = _unitOfWork.BasicSalary.Find(lec.BasicSalaryId);
                        //if (basicSalary.Salary == null) throw new Exception("Not found Salary of Lecturer.");
                        value = (double)basicSalary.Salary;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.TIMELIMIT))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlip.LecturerId)).FirstOrDefault();
                        var basicSalary = _unitOfWork.BasicSalary.Find(lec.BasicSalaryId);
                        //if (basicSalary.TimeLearningLimit == null) throw new Exception("Not found TimeLearningLimit of Lecturer.");
                        value = (double)basicSalary.TimeLearningLimit;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.E))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlip.LecturerId)).FirstOrDefault();
                        var fESalary = _unitOfWork.FESalary.Find(lec.FesalaryId);
                        //if (fESalary.Salary == null) throw new Exception("Not found FESalary of Lecturer.");
                        value = (double)fESalary.Salary;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.F))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlip.LecturerId)).FirstOrDefault();
                        var fESalary = _unitOfWork.FESalary.Find(lec.FesalaryId);
                        //if (fESalary.Salary == null) throw new Exception("Not found FESalary of Lecturer.");

                        if (fESalary.FesalaryCode[..1].Equals("E")) // Tinh theo luong F mac du luong dung la E. Chú thích: FesalaryCode.Substring(0, 1)
                        {
                            string eSalary = fESalary.FesalaryCode;
                            string fSalary = "F" + eSalary[1..];

                            var fESalaryF = _unitOfWork.FESalary.FindByCondition(e => e.FesalaryCode.Equals(fSalary)).FirstOrDefault();
                            if (fESalaryF == null) throw new Exception("Not found F Salary corresponding to E Salary of Lecturer.");
                            value = (double)fESalaryF.Salary;
                        }
                        else
                        {
                            value = (double)fESalary.Salary;
                        }
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity))
                    {
                        value = (double)formulaAttribute.Value;
                        quantity = attr.Value;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlip.LecturerId)).FirstOrDefault();
                        var fESalary = _unitOfWork.FESalary.Find(lec.FesalaryId);
                        //if (fESalary.Salary == null) throw new Exception("Not found FESalary of Lecturer.");

                        if (fESalary.FesalaryCode[..1].Equals("E")) // Tinh theo luong F mac du luong dung la E. Chú thích: FesalaryCode.Substring(0, 1)
                        {
                            string eSalary = fESalary.FesalaryCode;
                            string fSalary = "F" + eSalary[1..];

                            var fESalaryF = _unitOfWork.FESalary.FindByCondition(e => e.FesalaryCode.Equals(fSalary)).FirstOrDefault();
                            if (fESalaryF == null) throw new Exception("Not found F Salary corresponding to E Salary of Lecturer.");
                            value = (double)fESalaryF.Salary;
                        }
                        else
                        {
                            value = (double)fESalary.Salary;
                        }

                        //value = (double)fESalary.Salary;
                        quantity = attr.Value;
                    }
                }

                if (formulaAttribute.Value != null) value = (double)formulaAttribute.Value;

                PaySlipItem paySlipItem = null;

                if (formulaAttribute.FormulaAttributeTypeId != null
                    && (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                    || formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)))
                {
                    expression.Bind(formulaAttribute.Attribute, value * quantity);
                    if (quantity != 0)
                    {
                        paySlipItem = new PaySlipItem()
                        {
                            PaySlipItemId = Guid.NewGuid().ToString(),
                            PaySlipItemName = formulaAttribute.AttributeName,
                            Attribute = formulaAttribute.Attribute,
                            ValueEncrypt = (value != 0 ? value : attr.Value).ToString(),
                            QuantityEncrypt = quantity.ToString(),
                            FormulaAttributeId = formulaAttribute.FormulaAttributeId,
                            PaySlipId = paySlipRequest.PaySlipId
                        };
                    }
                }
                else
                {
                    paySlipItem = new PaySlipItem()
                    {
                        PaySlipItemId = Guid.NewGuid().ToString(),
                        PaySlipItemName = formulaAttribute.AttributeName,
                        Attribute = formulaAttribute.Attribute,
                        ValueEncrypt = (value != 0 ? value : attr.Value).ToString(),
                        QuantityEncrypt = quantity.ToString(),
                        FormulaAttributeId = formulaAttribute.FormulaAttributeId,
                        PaySlipId = paySlipRequest.PaySlipId
                    };
                    expression.Bind(formulaAttribute.Attribute, paySlipItem.Value);
                }

                //values.Add(paySlipItem.PaySlipItemName, paySlipItem.Value);

                if (paySlipItem != null) _unitOfWork.PaySlipItem.Create(paySlipItem);
            });

            // float result = Eval.Execute<float>(formula.CalculationFormula, values);
            expression.SetFomular(formula.CalculationFormula);
            float result = (float)expression.Eval<Decimal>();

            paySlip.CalculationFormula = formula.CalculationFormula;
            paySlip.TotalEncrypt = result.ToString();
            paySlip.FormulaId = formula.FormulaId;

            _unitOfWork.PaySlip.Update(paySlip);

            int created = _unitOfWork.Complete();

            return created;
        }

        public int UpdatePaySlipItem(PaySlipDetailRequest paySlipRequest)
        {
            var paySlip = _unitOfWork.PaySlip.Find(paySlipRequest.PaySlipId);
            if (paySlip == null) throw new Exception("Not found PaySlip");

            //Remove all PaySlipItem of PaySlip
            _unitOfWork.PaySlipItem.RemoveRange(_unitOfWork.PaySlipItem.FindByCondition(e => e.PaySlipId.Equals(paySlipRequest.PaySlipId)));

            var lecturer = _unitOfWork.Lecturer.Find(paySlip.LecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var lecturerType = _unitOfWork.LecturerType.Find(lecturer.LecturerTypeId);
            if (lecturerType == null) throw new Exception("Not found LecturerType of Lecturer.");

            if (lecturerType.FormulaId == null) throw new Exception("Not found Formula of Lecturer.");

            var formula = _unitOfWork.Formula.Find(lecturerType.FormulaId);

            List<string> attrInFormula = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(lecturerType.FormulaId)
                                            && ((e.FormulaAttribute.FormulaAttributeType == null && e.FormulaAttribute.Value == null)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)), e => e.FormulaAttribute.FormulaAttributeType)
                                            .Select(e => e.FormulaAttribute.Attribute).ToList();

            if (paySlipRequest.Attributes.Count > attrInFormula.Count) throw new Exception("Some attribute are not in the formula.");

            paySlipRequest.Attributes.ForEach(attribute =>
            {
                attrInFormula.Remove(attribute.Attribute);
            });

            if (attrInFormula.Count > 0)
            {
                throw new Exception("Some of the attribute are missing: " + string.Join(", ", attrInFormula));
            }

            var formulaAttributes = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(lecturerType.FormulaId),
                                    e => e.FormulaAttribute.FormulaAttributeType).Select(e => e.FormulaAttribute).ToList();

            //var values = new Dictionary<string, object>();
            Expression expression = new();

            formulaAttributes.ForEach(formulaAttribute =>
            {
                double value = 0;
                double quantity = 0;

                var attr = paySlipRequest.Attributes.Where(e => e.Attribute.Equals(formulaAttribute.Attribute)).FirstOrDefault();

                if (formulaAttribute.FormulaAttributeTypeId != null)
                {
                    if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.BASIC))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlip.LecturerId)).FirstOrDefault();
                        var basicSalary = _unitOfWork.BasicSalary.Find(lec.BasicSalaryId);
                        //if (basicSalary.Salary == null) throw new Exception("Not found Salary of Lecturer.");
                        value = (double)basicSalary.Salary;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.TIMELIMIT))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlip.LecturerId)).FirstOrDefault();
                        var basicSalary = _unitOfWork.BasicSalary.Find(lec.BasicSalaryId);
                        //if (basicSalary.TimeLearningLimit == null) throw new Exception("Not found TimeLearningLimit of Lecturer.");
                        value = (double)basicSalary.TimeLearningLimit;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.E))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlip.LecturerId)).FirstOrDefault();
                        var fESalary = _unitOfWork.FESalary.Find(lec.FesalaryId);
                        //if (fESalary.Salary == null) throw new Exception("Not found FESalary of Lecturer.");
                        value = (double)fESalary.Salary;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.F))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlip.LecturerId)).FirstOrDefault();
                        var fESalary = _unitOfWork.FESalary.Find(lec.FesalaryId);
                        //if (fESalary.Salary == null) throw new Exception("Not found FESalary of Lecturer.");

                        if (fESalary.FesalaryCode[..1].Equals("E")) // Tinh theo luong F mac du luong dung la E. Chú thích: FesalaryCode.Substring(0, 1)
                        {
                            string eSalary = fESalary.FesalaryCode;
                            string fSalary = "F" + eSalary[1..]; //eSalary.Substring(1, eSalary.Length - 1);

                            var fESalaryF = _unitOfWork.FESalary.FindByCondition(e => e.FesalaryCode.Equals(fSalary)).FirstOrDefault();
                            if (fESalaryF == null) throw new Exception("Not found F Salary corresponding to E Salary of Lecturer.");
                            value = (double)fESalaryF.Salary;
                        }
                        else
                        {
                            value = (double)fESalary.Salary;
                        }
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity))
                    {
                        value = (double)formulaAttribute.Value;
                        quantity = attr.Value;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlip.LecturerId)).FirstOrDefault();
                        var fESalary = _unitOfWork.FESalary.Find(lec.FesalaryId);
                        //if (fESalary.Salary == null) throw new Exception("Not found FESalary of Lecturer.");

                        if (fESalary.FesalaryCode[..1].Equals("E")) // Tinh theo luong F mac du luong dung la E. Chú thích: FesalaryCode.Substring(0, 1)
                        {
                            string eSalary = fESalary.FesalaryCode;
                            string fSalary = "F" + eSalary[1..];

                            var fESalaryF = _unitOfWork.FESalary.FindByCondition(e => e.FesalaryCode.Equals(fSalary)).FirstOrDefault();
                            if (fESalaryF == null) throw new Exception("Not found F Salary corresponding to E Salary of Lecturer.");
                            value = (double)fESalaryF.Salary;
                        }
                        else
                        {
                            value = (double)fESalary.Salary;
                        }

                        //value = (double)fESalary.Salary;
                        quantity = attr.Value;
                    }
                }

                if (formulaAttribute.Value != null) value = (double)formulaAttribute.Value;

                PaySlipItem paySlipItem = null;

                if (formulaAttribute.FormulaAttributeTypeId != null
                    && (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                    || formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)))
                {
                    expression.Bind(formulaAttribute.Attribute, value * quantity);
                    if (quantity != 0)
                    {
                        paySlipItem = new PaySlipItem()
                        {
                            PaySlipItemId = Guid.NewGuid().ToString(),
                            PaySlipItemName = formulaAttribute.AttributeName,
                            Attribute = formulaAttribute.Attribute,
                            ValueEncrypt = (value != 0 ? value : attr.Value).ToString(),
                            QuantityEncrypt = quantity.ToString(),
                            FormulaAttributeId = formulaAttribute.FormulaAttributeId,
                            PaySlipId = paySlipRequest.PaySlipId
                        };
                    }
                }
                else
                {
                    paySlipItem = new PaySlipItem()
                    {
                        PaySlipItemId = Guid.NewGuid().ToString(),
                        PaySlipItemName = formulaAttribute.AttributeName,
                        Attribute = formulaAttribute.Attribute,
                        ValueEncrypt = (value != 0 ? value : attr.Value).ToString(),
                        QuantityEncrypt = quantity.ToString(),
                        FormulaAttributeId = formulaAttribute.FormulaAttributeId,
                        PaySlipId = paySlipRequest.PaySlipId
                    };
                    expression.Bind(formulaAttribute.Attribute, paySlipItem.Value);
                }

                //values.Add(paySlipItem.PaySlipItemName, paySlipItem.Value);

                if (paySlipItem != null) _unitOfWork.PaySlipItem.Create(paySlipItem);
            });

            // float result = Eval.Execute<float>(formula.CalculationFormula, values);
            expression.SetFomular(formula.CalculationFormula);
            float result = (float)expression.Eval<Decimal>();

            paySlip.CalculationFormula = formula.CalculationFormula;
            paySlip.TotalEncrypt = result.ToString();
            paySlip.FormulaId = formula.FormulaId;

            _unitOfWork.PaySlip.Update(paySlip);

            int created = _unitOfWork.Complete();

            return created;
        }

        public List<PayPeriod> GetPayPeriods(string lecturerId)
        {
            var lecturer = _unitOfWork.Lecturer.Find(lecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var paySlips = _unitOfWork.PaySlip.FindByCondition(e => e.LecturerId.Equals(lecturerId)).ToList();

            HashSet<string> payPeriodIds = new();
            paySlips.ForEach(e =>
            {
                payPeriodIds.Add(e.PayPeriodId);
            });

            List<PayPeriod> listPayPeriod = new();
            foreach (var payPeriodId in payPeriodIds)
            {
                var payPeriod = _unitOfWork.PayPeriod.FindIncludeByCondition(e => e.PayPeriodId.Equals(payPeriodId), e => e.PayPolicy, e => e.Semester).FirstOrDefault();
                if (payPeriod != null) listPayPeriod.Add(payPeriod);
            }

            listPayPeriod = listPayPeriod.OrderByDescending(e => e.Semester.EndDate).ToList();

            return listPayPeriod;
        }

        public List<dynamic> GetPaySlipsInPayPeriods(string lecturerId)
        {
            var lecturer = _unitOfWork.Lecturer.Find(lecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var listPaySlip = _unitOfWork.PaySlip.FindByCondition(e => e.LecturerId.Equals(lecturerId)).ToList();

            HashSet<string> payPeriodIds = new();
            listPaySlip.ForEach(e =>
            {
                payPeriodIds.Add(e.PayPeriodId);
            });

            List<dynamic> payPeriods = new();
            foreach (var payPeriodId in payPeriodIds)
            {
                dynamic payPeriod = new ExpandoObject();
                var payPeriodData = _unitOfWork.PayPeriod.FindIncludeByCondition(e => e.PayPeriodId.Equals(payPeriodId), e => e.PayPolicy, e => e.Semester).FirstOrDefault();
                if (payPeriodData != null)
                {
                    payPeriod.payPeriod = payPeriodData;

                    List<dynamic> paySlips = new();
                    var paySlipsData = _unitOfWork.PaySlip.FindIncludeByCondition(e => e.PayPeriodId.Equals(payPeriodId), e => e.Formula).ToList();
                    paySlipsData.ForEach(paySlip =>
                    {
                        paySlips.Add(paySlip);
                    });

                    payPeriod.paySlips = paySlips;
                }

                payPeriods.Add(payPeriod);
            }

            return payPeriods;
        }

        public List<dynamic> GetPayPeriods1Year(PaySlip1YearRequest paySlipRequest)
        {
            var lecturer = _unitOfWork.Lecturer.Find(paySlipRequest.LecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var listPaySlip = _unitOfWork.PaySlip.FindByCondition(e => e.LecturerId.Equals(paySlipRequest.LecturerId)).ToList();

            HashSet<string> payPeriodIds = new();
            listPaySlip.ForEach(e =>
            {
                payPeriodIds.Add(e.PayPeriodId);
            });

            List<dynamic> payPeriods = new();
            foreach (var payPeriodId in payPeriodIds)
            {
                dynamic payPeriod = new ExpandoObject();

                var payPeriodData = _unitOfWork.PayPeriod.FindIncludeByCondition(e => e.PayPeriodId.Equals(payPeriodId), e => e.PayPolicy, e => e.Semester).FirstOrDefault();

                if (payPeriodData != null && (payPeriodData.Semester.StartDate.Year == paySlipRequest.Year || payPeriodData.Semester.EndDate.Year == paySlipRequest.Year))
                {
                    payPeriod.payPeriod = payPeriodData;

                    List<dynamic> paySlips = new();
                    var paySlipsData = _unitOfWork.PaySlip.FindIncludeByCondition(e => e.PayPeriodId.Equals(payPeriodId), e => e.Formula).ToList();
                    paySlipsData.ForEach(paySlip =>
                    {
                        paySlips.Add(paySlip);
                    });

                    payPeriod.paySlips = paySlips;
                }

                payPeriods.Add(payPeriod);
            }

            return payPeriods;
        }

        public List<PaySlip> GetPaySlipsByLecturer(string lecturerId)
        {
            var lecturer = _unitOfWork.Lecturer.Find(lecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var paySlips = _unitOfWork.PaySlip.FindIncludeByCondition(e => e.LecturerId.Equals(lecturerId), e => e.Formula, e => e.PayPeriod.Semester).ToList();

            paySlips = paySlips.OrderByDescending(e => e.EndDate).ToList();

            return paySlips;
        }

        public List<PaySlip> GetPaySlipsMonthsByLecturer(PaySlipByMonthRequest paySlipRequest)
        {
            var lecturer = _unitOfWork.Lecturer.Find(paySlipRequest.LecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            if (paySlipRequest.StartDate > paySlipRequest.EndDate) throw new Exception("StartDate must be less than EndDate");

            var startDate = new DateTime(paySlipRequest.StartDate.Year, paySlipRequest.StartDate.Month, 1);

            int days = DateTime.DaysInMonth(paySlipRequest.EndDate.Year, paySlipRequest.EndDate.Month);
            var endDate = new DateTime(paySlipRequest.EndDate.Year, paySlipRequest.EndDate.Month, days);

            var paySlips = _unitOfWork.PaySlip.FindIncludeByCondition(
                e => e.LecturerId.Equals(paySlipRequest.LecturerId)
                    && e.EndDate >= startDate && e.EndDate <= endDate,
                e => e.Formula, e => e.Formula.PayPolicy,
                e => e.PayPeriod, e => e.PayPeriod.Semester, e => e.PayPeriod.PayPolicy)
                    .OrderBy(e => e.EndDate).ToList();

            return paySlips;
        }

        public List<PaySlip> GetPaySlipsInPayPeriod(string payPeriodId, string lecturerId)
        {
            var payPeriod = _unitOfWork.PayPeriod.Find(payPeriodId);
            if (payPeriod == null) throw new Exception("Not found PayPeriod");

            var lecturer = _unitOfWork.Lecturer.Find(lecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var paySlips = _unitOfWork.PaySlip.FindIncludeByCondition(e => e.LecturerId.Equals(lecturerId) && e.PayPeriodId.Equals(payPeriodId), e => e.Formula).ToList();

            paySlips = paySlips.OrderByDescending(e => e.EndDate).ToList();

            return paySlips;
        }

        public dynamic GetPaySlip(string paySlipId)
        {
            dynamic data = new ExpandoObject();

            var paySlip = _unitOfWork.PaySlip.FindIncludeByCondition(e => e.PaySlipId.Equals(paySlipId),
                e => e.Formula,
                e => e.Formula.PayPolicy,
                e => e.Lecturer.GeneralUserInfo,
                e => e.Lecturer.GeneralUserInfo.Role,
                e => e.Lecturer.LecturerType,
                e => e.PayPeriod,
                e => e.PayPeriod.Semester).FirstOrDefault();

            paySlip.Lecturer.BasicSalary = _unitOfWork.BasicSalary.Find(paySlip.Lecturer.BasicSalaryId);
            paySlip.Lecturer.Fesalary = _unitOfWork.FESalary.Find(paySlip.Lecturer.FesalaryId);

            data.paySlip = paySlip;

            var paySlipItems = _unitOfWork.PaySlipItem.FindIncludeByCondition(e => e.PaySlipId.Equals(paySlipId), e => e.FormulaAttribute, e => e.FormulaAttribute.FormulaAttributeType, e => e.FormulaAttribute.GroupAttribute).ToList();
            data.paySlipItems = paySlipItems;

            return data;
        }

        public dynamic GetPaySlipByGroup(string paySlipId)
        {
            dynamic data = new ExpandoObject();

            var paySlip = _unitOfWork.PaySlip.FindIncludeByCondition(e => e.PaySlipId.Equals(paySlipId), e => e.Formula).FirstOrDefault();
            data.paySlip = paySlip;

            List<string> Groups = _unitOfWork.PaySlipItem.FindIncludeByCondition(e => e.PaySlipId.Equals(paySlipId), e => e.FormulaAttribute.GroupAttribute)
                                    .Select(e => e.FormulaAttribute.GroupAttribute.GroupName).ToList();

            HashSet<string> groupName = new();
            Groups.ForEach(group => groupName.Add(group));

            List<dynamic> groupDatas = new();

            groupName.ToList().ForEach(group =>
            {
                dynamic groupData = new ExpandoObject();
                groupData.groupName = group;

                //Luu y
                var paySlipItems = _unitOfWork.PaySlipItem.FindIncludeByCondition(e => e.PaySlipId.Equals(paySlipId) && e.FormulaAttribute.GroupAttribute.GroupName.Equals(group),
                    e => e.FormulaAttribute, e => e.FormulaAttribute.GroupAttribute).ToList();
                groupData.paySlipItems = paySlipItems;

                groupDatas.Add(groupData);
            });

            data.groups = groupDatas;

            return Task.FromResult((object)data);
        }

        public List<PayPeriod> GetAllPayPeriod()
        {
            var payPeriods = _unitOfWork.PayPeriod.FindInclude(e => e.PayPolicy, e => e.Semester).ToList();
            return payPeriods;
        }

        public List<dynamic> GetPaySlips()
        {
            List<dynamic> listPaySlip = new();

            var paySlips = _unitOfWork.PaySlip.FindInclude(e => e.Formula, e => e.Lecturer, e => e.PayPeriod).ToList();
            paySlips.ForEach(paySlip =>
            {
                dynamic data = new ExpandoObject();

                data.paySlip = paySlip;

                var paySlipItems = _unitOfWork.PaySlipItem.FindIncludeByCondition(e => e.PaySlipId.Equals(paySlip.PaySlipId), e => e.FormulaAttribute).ToList();
                data.paySlipItems = paySlipItems;

                listPaySlip.Add(data);
            });

            return listPaySlip;
        }

        public object PostCheckSalary(PaySlipCheckRequest paySlipCheckRequest)
        {
            var lecturer = _unitOfWork.Lecturer.Find(paySlipCheckRequest.LecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var lecturerType = _unitOfWork.LecturerType.Find(lecturer.LecturerTypeId);
            if (lecturerType == null) throw new Exception("Not found LecturerType of Lecturer.");

            if (lecturerType.FormulaId == null) throw new Exception("Not found Formula of Lecturer.");

            List<string> attrInFormula = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(lecturerType.FormulaId)
                                            && ((e.FormulaAttribute.FormulaAttributeType == null && e.FormulaAttribute.Value == null)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)), e => e.FormulaAttribute.FormulaAttributeType)
                                            .Select(e => e.FormulaAttribute.Attribute).ToList();

            if (paySlipCheckRequest.Attributes.Count > attrInFormula.Count) throw new Exception("Some attribute are not in the formula.");

            paySlipCheckRequest.Attributes.ForEach(attribute =>
            {
                attrInFormula.Remove(attribute.Attribute);
            });

            if (attrInFormula.Count > 0)
            {
                throw new Exception("Some of the attribute are missing: " + string.Join(", ", attrInFormula));
            }

            //Luu y
            var formulaAttributes = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(lecturerType.FormulaId), e => e.FormulaAttribute, e => e.FormulaAttribute.FormulaAttributeType)
                                      .Select(e => e.FormulaAttribute).ToList();

            Expression expression = new();

            var values = new Dictionary<string, ItemValue>();

            formulaAttributes.ForEach(formulaAttribute =>
            {
                double value = 0;
                double quantity = 0;

                var attr = paySlipCheckRequest.Attributes.Where(e => e.Attribute.Equals(formulaAttribute.Attribute)).FirstOrDefault();

                if (formulaAttribute.FormulaAttributeTypeId != null)
                {
                    if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.BASIC))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlipCheckRequest.LecturerId)).FirstOrDefault();
                        var basicSalary = _unitOfWork.BasicSalary.Find(lec.BasicSalaryId);
                        //if (basicSalary.Salary == null) throw new Exception("Not found Salary of Lecturer.");
                        value = (double)basicSalary.Salary;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.TIMELIMIT))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlipCheckRequest.LecturerId)).FirstOrDefault();
                        var basicSalary = _unitOfWork.BasicSalary.Find(lec.BasicSalaryId);
                        //if (basicSalary.TimeLearningLimit == null) throw new Exception("Not found TimeLearningLimit of Lecturer.");
                        value = (double)basicSalary.TimeLearningLimit;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.E))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlipCheckRequest.LecturerId)).FirstOrDefault();
                        var fESalary = _unitOfWork.FESalary.Find(lec.FesalaryId);
                        //if (fESalary.Salary == null) throw new Exception("Not found FESalary of Lecturer.");
                        value = (double)fESalary.Salary;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.F))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlipCheckRequest.LecturerId)).FirstOrDefault();
                        var fESalary = _unitOfWork.FESalary.Find(lec.FesalaryId);
                        //if (fESalary.Salary == null) throw new Exception("Not found FESalary of Lecturer.");

                        if (fESalary.FesalaryCode[..1].Equals("E")) // Tinh theo luong F mac du luong dung la E
                        {
                            string eSalary = fESalary.FesalaryCode;
                            string fSalary = "F" + eSalary[1..];

                            var fESalaryF = _unitOfWork.FESalary.FindByCondition(e => e.FesalaryCode.Equals(fSalary)).FirstOrDefault();
                            if (fESalaryF == null) throw new Exception("Not found F Salary corresponding to E Salary of Lecturer.");
                            value = (double)fESalaryF.Salary;
                        }
                        else
                        {
                            value = (double)fESalary.Salary;
                        }
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity))
                    {
                        value = (double)formulaAttribute.Value;
                        quantity = attr.Value;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlipCheckRequest.LecturerId)).FirstOrDefault();
                        var fESalary = _unitOfWork.FESalary.Find(lec.FesalaryId);
                        //if (fESalary.Salary == null) throw new Exception("Not found FESalary of Lecturer.");

                        if (fESalary.FesalaryCode[..1].Equals("E")) // Tinh theo luong F mac du luong dung la E. Chú thích: FesalaryCode.Substring(0, 1)
                        {
                            string eSalary = fESalary.FesalaryCode;
                            string fSalary = "F" + eSalary[1..];

                            var fESalaryF = _unitOfWork.FESalary.FindByCondition(e => e.FesalaryCode.Equals(fSalary)).FirstOrDefault();
                            if (fESalaryF == null) throw new Exception("Not found F Salary corresponding to E Salary of Lecturer.");
                            value = (double)fESalaryF.Salary;
                        }
                        else
                        {
                            value = (double)fESalary.Salary;
                        }

                        //value = (double)fESalary.Salary;
                        quantity = attr.Value;
                    }
                }

                if (formulaAttribute.Value != null) value = (double)formulaAttribute.Value;

                if (formulaAttribute.FormulaAttributeTypeId != null
                    && (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                    || formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)))
                {
                    if (quantity != 0) values.Add(formulaAttribute.Attribute, new ItemValue() { Value = value * quantity, Quantity = quantity });
                    expression.Bind(formulaAttribute.Attribute, value * quantity);
                }
                else
                {
                    values.Add(formulaAttribute.Attribute, new ItemValue() { Value = value != 0 ? value : attr.Value, Quantity = quantity });
                    expression.Bind(formulaAttribute.Attribute, value != 0 ? value : attr.Value);
                }
            });

            var formula = _unitOfWork.Formula.Find(lecturerType.FormulaId);

            expression.SetFomular(formula.CalculationFormula);
            float result = (float)expression.Eval<Decimal>();

            dynamic data = new ExpandoObject();
            data.result = result;
            data.formula = formula.CalculationFormula;
            data.attribute = values;

            return data;
        }

        public object CheckSalaryFull(PaySlipCheckRequest paySlipCheckRequest)
        {
            var lecturer = _unitOfWork.Lecturer.Find(paySlipCheckRequest.LecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var lecturerType = _unitOfWork.LecturerType.Find(lecturer.LecturerTypeId);
            if (lecturerType == null) throw new Exception("Not found LecturerType of Lecturer.");

            if (lecturerType.FormulaId == null) throw new Exception("Not found Formula of Lecturer.");

            List<string> attrInFormula = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(lecturerType.FormulaId)
                                            && ((e.FormulaAttribute.FormulaAttributeType == null && e.FormulaAttribute.Value == null)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)), e => e.FormulaAttribute.FormulaAttributeType)
                                            .Select(e => e.FormulaAttribute.Attribute).ToList();

            if (paySlipCheckRequest.Attributes.Count > attrInFormula.Count) throw new Exception("Some attribute are not in the formula.");

            paySlipCheckRequest.Attributes.ForEach(attribute =>
            {
                attrInFormula.Remove(attribute.Attribute);
            });

            if (attrInFormula.Count > 0)
            {
                throw new Exception("Some of the attribute are missing: " + string.Join(", ", attrInFormula));
            }

            //Luu y
            var formulaAttributes = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(lecturerType.FormulaId), e => e.FormulaAttribute, e => e.FormulaAttribute.FormulaAttributeType)
                                      .Select(e => e.FormulaAttribute).ToList();

            Expression expression = new();

            var values = new Dictionary<string, ItemValue>();

            formulaAttributes.ForEach(formulaAttribute =>
            {
                double value = 0;
                double quantity = 0;

                var attr = paySlipCheckRequest.Attributes.Where(e => e.Attribute.Equals(formulaAttribute.Attribute)).FirstOrDefault();

                if (formulaAttribute.FormulaAttributeTypeId != null)
                {
                    if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.BASIC))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlipCheckRequest.LecturerId)).FirstOrDefault();
                        var basicSalary = _unitOfWork.BasicSalary.Find(lec.BasicSalaryId);
                        //if (basicSalary.Salary == null) throw new Exception("Not found Salary of Lecturer.");
                        value = (double)basicSalary.Salary;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.TIMELIMIT))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlipCheckRequest.LecturerId)).FirstOrDefault();
                        var basicSalary = _unitOfWork.BasicSalary.Find(lec.BasicSalaryId);
                        //if (basicSalary.TimeLearningLimit == null) throw new Exception("Not found TimeLearningLimit of Lecturer.");
                        value = (double)basicSalary.TimeLearningLimit;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.E))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlipCheckRequest.LecturerId)).FirstOrDefault();
                        var fESalary = _unitOfWork.FESalary.Find(lec.FesalaryId);
                        //if (fESalary.Salary == null) throw new Exception("Not found FESalary of Lecturer.");
                        value = (double)fESalary.Salary;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.F))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlipCheckRequest.LecturerId)).FirstOrDefault();
                        var fESalary = _unitOfWork.FESalary.Find(lec.FesalaryId);
                        //if (fESalary.Salary == null) throw new Exception("Not found FESalary of Lecturer.");

                        if (fESalary.FesalaryCode[..1].Equals("E")) // Tinh theo luong F mac du luong dung la E
                        {
                            string eSalary = fESalary.FesalaryCode;
                            string fSalary = "F" + eSalary[1..];

                            var fESalaryF = _unitOfWork.FESalary.FindByCondition(e => e.FesalaryCode.Equals(fSalary)).FirstOrDefault();
                            if (fESalaryF == null) throw new Exception("Not found F Salary corresponding to E Salary of Lecturer.");
                            value = (double)fESalaryF.Salary;
                        }
                        else
                        {
                            value = (double)fESalary.Salary;
                        }
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity))
                    {
                        value = (double)formulaAttribute.Value;
                        quantity = attr.Value;
                    }
                    else if (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi))
                    {
                        var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(paySlipCheckRequest.LecturerId)).FirstOrDefault();
                        var fESalary = _unitOfWork.FESalary.Find(lec.FesalaryId);
                        //if (fESalary.Salary == null) throw new Exception("Not found FESalary of Lecturer.");

                        if (fESalary.FesalaryCode[..1].Equals("E")) // Tinh theo luong F mac du luong dung la E. Chú thích: FesalaryCode.Substring(0, 1)
                        {
                            string eSalary = fESalary.FesalaryCode;
                            string fSalary = "F" + eSalary[1..];

                            var fESalaryF = _unitOfWork.FESalary.FindByCondition(e => e.FesalaryCode.Equals(fSalary)).FirstOrDefault();
                            if (fESalaryF == null) throw new Exception("Not found F Salary corresponding to E Salary of Lecturer.");
                            value = (double)fESalaryF.Salary;
                        }
                        else
                        {
                            value = (double)fESalary.Salary;
                        }

                        //value = (double)fESalary.Salary;
                        quantity = attr.Value;
                    }
                }

                if (formulaAttribute.Value != null) value = (double)formulaAttribute.Value;

                if (formulaAttribute.FormulaAttributeTypeId != null
                    && (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                    || formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)))
                {
                    if (quantity != 0) values.Add(formulaAttribute.Attribute, new ItemValue() { Value = value * quantity, Quantity = quantity });
                    expression.Bind(formulaAttribute.Attribute, value * quantity);
                }
                else
                {
                    values.Add(formulaAttribute.Attribute, new ItemValue() { Value = value != 0 ? value : attr.Value, Quantity = quantity });
                    expression.Bind(formulaAttribute.Attribute, value != 0 ? value : attr.Value);
                }
            });

            var formula = _unitOfWork.Formula.Find(lecturerType.FormulaId);

            expression.SetFomular(formula.CalculationFormula);
            float result = (float)expression.Eval<Decimal>();

            List<dynamic> listAttr = new();
            foreach (var item in values)
            {
                var attr = _unitOfWork.FormulaAttribute.FindIncludeByCondition(e => e.Attribute.Equals(item.Key), e => e.FormulaAttributeType, e => e.GroupAttribute).FirstOrDefault();

                dynamic dataValue = new ExpandoObject();
                dataValue.value = item.Value.Value;
                dataValue.quantity = item.Value.Quantity;
                dataValue.attribute = attr;

                listAttr.Add(dataValue);
            }

            dynamic data = new ExpandoObject();
            data.result = result;
            data.formula = formula.CalculationFormula;

            var feLecturer = _unitOfWork.FESalary.Find(lecturer.FesalaryId);
            if (feLecturer != null) data.fesalary = feLecturer.Salary;
            else data.fesalary = null;

            data.attributes = listAttr;

            return data;
        }

        public List<TeachingSummary> GetTeachingSummaries()
        {
            var teachingSummaries = _unitOfWork.TeachingSummary.FindInclude(e => e.PaySlip).ToList();

            teachingSummaries.ForEach(teachingSummary =>
            {
                var teachingSummaryDetails = _unitOfWork.TeachingSummaryDetail.FindByCondition(e => e.TeachingSummaryId.Equals(teachingSummary.TeachingSummaryId)).ToList();

                // Đếm các môn Capstone 
                var countCaps = teachingSummaryDetails.Where(e => e.Course.Equals(AttributePaySLip.CAPSTONE)).Count();

                // Đếm các môn Not yet không phải Capstone
                var countNotCapsNotYet = teachingSummaryDetails.Where(e => !e.Course.Equals(AttributePaySLip.CAPSTONE) && e.Attendance.Equals(AttributePaySLip.NOTYET)).Count();

                teachingSummary.AttendedTeaching = teachingSummary.PlanTeaching - countCaps - countNotCapsNotYet;
            });

            return teachingSummaries;
        }

        public object GetTeachingSummary(string teachingSummaryId)
        {
            dynamic data = new ExpandoObject();

            var teachingSummary = _unitOfWork.TeachingSummary.FindIncludeByCondition(e => e.TeachingSummaryId.Equals(teachingSummaryId), e => e.PaySlip).FirstOrDefault();
            if (teachingSummary == null) throw new Exception("Not found TeachingSummary");

            var teachingSummaryDetails = _unitOfWork.TeachingSummaryDetail.FindByCondition(e => e.TeachingSummaryId.Equals(teachingSummaryId)).ToList();

            // Đếm các môn Capstone 
            var countCaps = teachingSummaryDetails.Where(e => e.Course.Equals(AttributePaySLip.CAPSTONE)).Count();

            // Đếm các môn Not yet không phải Capstone
            var countNotCapsNotYet = teachingSummaryDetails.Where(e => !e.Course.Equals(AttributePaySLip.CAPSTONE) && e.Attendance.Equals(AttributePaySLip.NOTYET)).Count();

            teachingSummary.AttendedTeaching = teachingSummary.PlanTeaching - countCaps - countNotCapsNotYet;

            data.teachingSummary = teachingSummary;
            data.teachingSummaryDetails = teachingSummaryDetails;

            return data;
        }

        public object GetTeachingSummaryByPaySlip(string paySlipId)
        {
            dynamic data = new ExpandoObject();

            var paySlip = _unitOfWork.PaySlip.Find(paySlipId);
            if (paySlip == null) throw new Exception("Not found PaySlip");

            var teachingSummary = _unitOfWork.TeachingSummary.FindIncludeByCondition(e => e.PaySlipId.Equals(paySlipId), e => e.PaySlip).FirstOrDefault();
            if (teachingSummary == null) throw new Exception("Not found TeachingSummary");

            var teachingSummaryDetails = _unitOfWork.TeachingSummaryDetail.FindByCondition(e => e.TeachingSummaryId.Equals(teachingSummary.TeachingSummaryId)).ToList();

            // Đếm các môn Capstone 
            var countCaps = teachingSummaryDetails.Where(e => e.Course.Equals(AttributePaySLip.CAPSTONE)).Count();

            // Đếm các môn Not yet không phải Capstone
            var countNotCapsNotYet = teachingSummaryDetails.Where(e => !e.Course.Equals(AttributePaySLip.CAPSTONE) && e.Attendance.Equals(AttributePaySLip.NOTYET)).Count();

            teachingSummary.AttendedTeaching = teachingSummary.PlanTeaching - countCaps - countNotCapsNotYet;

            teachingSummaryDetails = teachingSummaryDetails.OrderByDescending(e => e.Date).ToList();

            data.teachingSummary = teachingSummary;
            data.teachingSummaryDetails = teachingSummaryDetails;

            return data;
        }

        public int CreateTeachingSummary(string teachingSummaryId, TeachingSummaryRequest teachingSummaryRequest)
        {
            var paySlip = _unitOfWork.PaySlip.Find(teachingSummaryRequest.PaySlipId);
            if (paySlip == null) throw new Exception("Not found PaySlip");

            var TSummary = _unitOfWork.TeachingSummary.FindByCondition(e => e.PaySlipId.Equals(teachingSummaryRequest.PaySlipId)).FirstOrDefault();
            if (TSummary != null)
            {
                _unitOfWork.TeachingSummaryDetail.RemoveRange(_unitOfWork.TeachingSummaryDetail.FindByCondition(e => e.TeachingSummaryId.Equals(TSummary.TeachingSummaryId)));

                _unitOfWork.TeachingSummary.Remove(TSummary);
            }

            TeachingSummary teachingSummary = new()
            {
                TeachingSummaryId = teachingSummaryId,
                AttendedTeaching = teachingSummaryRequest.AttendedTeaching,
                PlanTeaching = teachingSummaryRequest.PlanTeaching,
                Average = teachingSummaryRequest.Average,
                TotalDay = teachingSummaryRequest.TotalDay,
                TotalWeek = teachingSummaryRequest.TotalWeek,
                PaySlipId = teachingSummaryRequest.PaySlipId
            };

            _unitOfWork.TeachingSummary.Create(teachingSummary);

            teachingSummaryRequest.TeachingSummaryDetails.ForEach(detail =>
            {
                TeachingSummaryDetail teachingSummaryDetail = new()
                {
                    TeachingSummaryDetailId = Guid.NewGuid().ToString(),
                    Date = detail.Date,
                    Slot = detail.Slot,
                    Room = detail.Room,
                    Course = detail.Course,
                    SessionNo = detail.SessionNo,
                    Student = detail.Student,
                    Attendance = detail.Attendance,
                    TeachingSummaryId = teachingSummaryId
                };

                _unitOfWork.TeachingSummaryDetail.Create(teachingSummaryDetail);
            });

            int created = _unitOfWork.Complete();

            return created;
        }

        public dynamic GetHoursProctoringSign(string paySlipId)
        {
            dynamic data = new ExpandoObject();

            var paySlip = _unitOfWork.PaySlip.Find(paySlipId);
            if (paySlip == null) throw new Exception("Not found PaySlip");

            var timeSlots = _unitOfWork.ProctoringSign.FindByCondition(e => e.LecturerId.Equals(paySlip.LecturerId)
                                && e.TimeSlot.Date >= paySlip.StartDate && e.TimeSlot.Date <= paySlip.EndDate)
                                .Select(e => e.TimeSlot).OrderByDescending(e => e.Date).ToList();

            double hours = 0;

            if (timeSlots != null)
            {
                //Total hours ProctoringSign
                hours = timeSlots.Sum(e => (e.EndTime - e.StartTime).TotalHours);
            }

            data.hours = hours;
            data.timeSlots = timeSlots;

            return data;
        }

        public List<PaySlip> GetPaySlipsInYear(string lecturerId, int year)
        {
            var lecturer = _unitOfWork.Lecturer.Find(lecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var paySlips = _unitOfWork.PaySlip.FindByCondition(e => e.LecturerId.Equals(lecturerId)
                                && e.EndDate.Year == year).ToList();

            //Pay Slip November => November
            paySlips.ForEach(paySlip => paySlip.PaySlipName = paySlip.PaySlipName.Replace("Pay Slip ", ""));

            paySlips = paySlips.OrderBy(e => e.EndDate).ToList();

            return paySlips;
        }

        public dynamic GetFormulaTax()
        {
            var formula = _unitOfWork.Formula.FindByCondition(e => e.FormulaName.Equals(Tax.TaxFormula)).FirstOrDefault();

            dynamic data = new ExpandoObject();
            data.formula = formula;

            var formulaAttributes = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(formula.FormulaId)
                                            && ((e.FormulaAttribute.FormulaAttributeType == null && e.FormulaAttribute.Value == null)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)), e => e.FormulaAttribute.FormulaAttributeType, e => e.FormulaAttribute.GroupAttribute)
                                            .Select(e => e.FormulaAttribute).ToList();

            data.formulaAttributes = formulaAttributes;

            return data;
        }

        public object CheckSalaryTax(PaySlipCheckTax paySlipCheckRequest)
        {
            var formula = _unitOfWork.Formula.FindByCondition(e => e.FormulaName.Equals(Tax.TaxFormula)).FirstOrDefault();

            List<string> attrInFormula = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(formula.FormulaId)
                                            && ((e.FormulaAttribute.FormulaAttributeType == null && e.FormulaAttribute.Value == null)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                                            || e.FormulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)), e => e.FormulaAttribute.FormulaAttributeType)
                                            .Select(e => e.FormulaAttribute.Attribute).ToList();

            if (paySlipCheckRequest.Attributes.Count > attrInFormula.Count) throw new Exception("Some attribute are not in the formula.");

            paySlipCheckRequest.Attributes.ForEach(attribute =>
            {
                attrInFormula.Remove(attribute.Attribute);
            });

            if (attrInFormula.Count > 0)
            {
                throw new Exception("Some of the attribute are missing: " + string.Join(", ", attrInFormula));
            }

            //Luu y
            var formulaAttributes = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(formula.FormulaId), e => e.FormulaAttribute, e => e.FormulaAttribute.FormulaAttributeType)
                                      .Select(e => e.FormulaAttribute).ToList();

            Expression expression = new();

            var values = new Dictionary<string, object>();

            formulaAttributes.ForEach(formulaAttribute =>
            {
                double value = 0;
                double quantity = 0;

                var attr = paySlipCheckRequest.Attributes.Where(e => e.Attribute.Equals(formulaAttribute.Attribute)).FirstOrDefault();

                if (formulaAttribute.Value != null) value = (double)formulaAttribute.Value;

                if (formulaAttribute.FormulaAttributeTypeId != null
                    && (formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Quantity)
                    || formulaAttribute.FormulaAttributeType.Type.Equals(AttributeSalary.T_Fi)))
                {
                    if (quantity != 0) values.Add(formulaAttribute.Attribute, value * quantity);
                    expression.Bind(formulaAttribute.Attribute, value * quantity);
                }
                else
                {
                    values.Add(formulaAttribute.Attribute, value != 0 ? value : attr.Value);
                    expression.Bind(formulaAttribute.Attribute, value != 0 ? value : attr.Value);
                }
            });

            expression.SetFomular(formula.CalculationFormula);
            float result = (float)expression.Eval<Decimal>();

            List<dynamic> listAttr = new();
            foreach (var item in values)
            {
                var attr = _unitOfWork.FormulaAttribute.FindIncludeByCondition(e => e.Attribute.Equals(item.Key), e => e.FormulaAttributeType, e => e.GroupAttribute).FirstOrDefault();

                dynamic dataValue = new ExpandoObject();
                dataValue.value = item.Value;
                dataValue.attribute = attr;

                listAttr.Add(dataValue);
            }

            dynamic data = new ExpandoObject();
            data.result = result;
            data.formula = formula.CalculationFormula;
            data.attributes = listAttr;

            return data;
        }
    }
}
