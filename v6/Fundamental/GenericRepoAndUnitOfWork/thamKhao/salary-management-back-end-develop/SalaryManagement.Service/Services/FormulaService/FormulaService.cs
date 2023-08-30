using org.matheval;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using SalaryManagement.Responses;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace SalaryManagement.Services.FormulaService
{
    public class FormulaService : IFormulaService
    {
        const string SOME_KEY = "errors";
        private readonly IUnitOfWork _unitOfWork;

        public FormulaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<GroupAttribute> GetGroupAttributes()
        {
            var groupAttributes = _unitOfWork.GroupAttribute.FindAll().OrderBy(e => e.GroupName).ToList();
            return groupAttributes;
        }

        public List<FormulaAttribute> GetFormulaAttrFunction()
        {
            var formulaAttributes = _unitOfWork.FormulaAttribute.FindIncludeByCondition(e => e.GroupAttribute.GroupName.Equals(AttributeSalary.Function), e => e.GroupAttribute, e => e.FormulaAttributeType).ToList();
            return formulaAttributes;
        }

        public List<FormulaAttribute> GetFormulaAttrNotFunction()
        {
            var formulaAttributes = _unitOfWork.FormulaAttribute.FindIncludeByCondition(e => !e.GroupAttribute.GroupName.Equals(AttributeSalary.Function), e => e.GroupAttribute, e => e.FormulaAttributeType).ToList();
            return formulaAttributes;
        }

        public List<FormulaAttribute> GetFormulaAttrInGroupAttr(string groupAttributeId)
        {
            var groupAttribute = _unitOfWork.GroupAttribute.Find(groupAttributeId);
            if (groupAttribute == null) throw new Exception("Not found GroupAttribute");

            var formulaAttributes = _unitOfWork.FormulaAttribute.FindIncludeByCondition(e => e.GroupAttributeId.Equals(groupAttributeId), e => e.GroupAttribute, e => e.FormulaAttributeType).ToList();

            return formulaAttributes;
        }

        public List<dynamic> GetFormulaAttrsOfGroupAttrs()
        {
            List<dynamic> datas = new();

            var groupAttributes = _unitOfWork.GroupAttribute.FindAll().ToList();

            groupAttributes.ForEach(groupAttribute =>
            {
                dynamic data = new ExpandoObject();
                data.groupAttribute = groupAttribute;

                var formulaAttribute = _unitOfWork.FormulaAttribute.FindIncludeByCondition(e => e.GroupAttributeId.Equals(groupAttribute.GroupAttributeId), e => e.FormulaAttributeType).ToList();
                data.formulaAttributes = formulaAttribute;

                datas.Add(data);
            });

            return datas;
        }

        public GroupAttribute GetGroupAttribute(string groupAttributeId)
        {
            var groupAttribute = _unitOfWork.GroupAttribute.Find(groupAttributeId);
            return groupAttribute;
        }

        public int CreateGroupAttribute(string groupAttributeId, GroupAttributeRequest groupAttributeRequest)
        {
            var groupName = _unitOfWork.GroupAttribute.FindByCondition(e => e.GroupName.ToLower().Equals(groupAttributeRequest.GroupName.ToLower())).Select(e => e.GroupName).FirstOrDefault();
            if (groupName != null) throw new Exception($"GroupName '{groupName}' already exists");

            GroupAttribute groupAttribute = new()
            {
                GroupAttributeId = groupAttributeId,
                GroupName = groupAttributeRequest.GroupName,
                Description = groupAttributeRequest.Description,
                IsDisable = groupAttributeRequest.IsDisable
            };

            _unitOfWork.GroupAttribute.Create(groupAttribute);

            int created = _unitOfWork.Complete();

            return created;
        }

        public int UpdateGroupAttribute(string id, GroupAttributeRequest groupAttributeRequest)
        {
            int update = -1;

            var groupAttribute = _unitOfWork.GroupAttribute.Find(id);

            if (groupAttribute != null)
            {
                var groupName = _unitOfWork.GroupAttribute.FindByCondition(e => !e.GroupAttributeId.Equals(groupAttribute.GroupAttributeId) && e.GroupName.ToLower().Equals(groupAttributeRequest.GroupName.ToLower())).Select(e => e.GroupName).FirstOrDefault();
                if (groupName != null) throw new Exception($"GroupName '{groupName}' already exists");

                if (groupAttribute.GroupName.Equals(AttributeSalary.Function))
                {
                    throw new Exception("Cannot update GroupAttribute 'Function'");
                }

                groupAttribute.GroupName = groupAttributeRequest.GroupName;
                groupAttribute.Description = groupAttributeRequest.Description;
                groupAttribute.IsDisable = groupAttributeRequest.IsDisable;

                _unitOfWork.GroupAttribute.Update(groupAttribute);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int DisableGroupAttribute(string groupAttributeId, bool status)
        {
            int update = -1;

            var groupAttribute = _unitOfWork.GroupAttribute.Find(groupAttributeId);

            if (groupAttribute != null)
            {
                if (groupAttribute.GroupName.Equals(AttributeSalary.Function))
                {
                    throw new Exception("Cannot change status GroupAttribute 'Function'");
                }

                if (groupAttribute.IsDisable == false && status == true)
                {
                    if (_unitOfWork.FormulaAttributeFormula.FindAll().Any(e => e.FormulaAttribute.GroupAttributeId.Equals(groupAttribute.GroupAttributeId)))
                        throw new Exception($"GroupAttribute '{groupAttribute.GroupName}' has the formula attribute already exists in the formula ");
                }

                groupAttribute.IsDisable = status;

                _unitOfWork.GroupAttribute.Update(groupAttribute);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public List<PayPolicy> GetPayPolicies()
        {
            var payPolicies = _unitOfWork.PayPolicy.FindAll().OrderByDescending(e => e.StartDate).ToList();
            return payPolicies;
        }

        public PayPolicy GetPayPolicy(string payPolicyId)
        {
            var payPolicy = _unitOfWork.PayPolicy.Find(payPolicyId);
            return payPolicy;
        }

        public int CreatePayPolicy(string payPolicyId, PayPolicyRequest payPolicyRequest)
        {
            var policyName = _unitOfWork.PayPolicy.FindByCondition(e => e.PolicyName.ToLower().Equals(payPolicyRequest.PolicyName.ToLower())).Select(e => e.PolicyName).FirstOrDefault();
            if (policyName != null) throw new Exception($"PolicyName '{policyName}' already exists");

            var policyNo = _unitOfWork.PayPolicy.FindByCondition(e => e.PolicyNo.ToLower().Equals(payPolicyRequest.PolicyNo.ToLower())).Select(e => e.PolicyNo).FirstOrDefault();
            if (policyNo != null) throw new Exception($"PolicyNo '{policyNo}' already exists");

            PayPolicy payPolicy = new()
            {
                PayPolicyId = payPolicyId,
                PolicyName = payPolicyRequest.PolicyName,
                PolicyNo = payPolicyRequest.PolicyNo,
                StartDate = payPolicyRequest.StartDate,
                EndDate = payPolicyRequest.EndDate,
                ModifiedDate = DateTime.Now
            };

            _unitOfWork.PayPolicy.Create(payPolicy);

            int created = _unitOfWork.Complete();

            return created;
        }

        public int UpdatePayPolicy(string id, PayPolicyRequest payPolicyRequest)
        {
            int update = -1;

            var payPolicy = _unitOfWork.PayPolicy.Find(id);

            if (payPolicy != null)
            {
                var policyName = _unitOfWork.PayPolicy.FindByCondition(e => !e.PayPolicyId.Equals(payPolicy.PayPolicyId) && e.PolicyName.ToLower().Equals(payPolicyRequest.PolicyName.ToLower())).Select(e => e.PolicyName).FirstOrDefault();
                if (policyName != null) throw new Exception($"PolicyName '{policyName}' already exists");

                var policyNo = _unitOfWork.PayPolicy.FindByCondition(e => !e.PayPolicyId.Equals(payPolicy.PayPolicyId) && e.PolicyNo.ToLower().Equals(payPolicyRequest.PolicyNo.ToLower())).Select(e => e.PolicyNo).FirstOrDefault();
                if (policyNo != null) throw new Exception($"PolicyNo '{policyNo}' already exists");

                payPolicy.PolicyName = payPolicyRequest.PolicyName;
                payPolicy.PolicyNo = payPolicyRequest.PolicyNo;
                payPolicy.StartDate = payPolicyRequest.StartDate;
                payPolicy.EndDate = payPolicyRequest.EndDate;
                payPolicy.ModifiedDate = DateTime.Now;

                _unitOfWork.PayPolicy.Update(payPolicy);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public List<FormulaAttribute> GetFormulaAttributes()
        {
            var formulaAttributes = _unitOfWork.FormulaAttribute.FindInclude(e => e.GroupAttribute, e => e.FormulaAttributeType).OrderBy(e => e.Attribute).ToList();

            formulaAttributes.ForEach(formulaAttribute =>
            {
                var departments = _unitOfWork.FormulaAttributeDepartment.FindByCondition(e => e.FormulaAttributeId.Equals(formulaAttribute.FormulaAttributeId)).Select(e => e.Department).ToList();
                formulaAttribute.Departments = departments;
            });

            return formulaAttributes;
        }

        public List<FormulaAttribute> GetFormulaAttributesByAttribute(string attribute)
        {
            var formulaAttributes = _unitOfWork.FormulaAttribute.FindInclude(e => e.GroupAttribute, e => e.FormulaAttributeType)
                .Where(delegate (FormulaAttribute e)
                {
                    string attr = StringTemplate.ConvertUTF8(e.Attribute).ToLower();
                    string attributeSearch = StringTemplate.ConvertUTF8(attribute.Trim()).ToLower();

                    if (attr.Contains(attributeSearch))
                        return true;
                    else
                        return false;
                }).AsQueryable().ToList();

            return formulaAttributes;
        }

        public FormulaAttribute GetFormulaAttribute(string formulaAttributeId)
        {
            var formulaAttribute = _unitOfWork.FormulaAttribute.FindIncludeByCondition(e => e.FormulaAttributeId.Equals(formulaAttributeId), e => e.GroupAttribute, e => e.FormulaAttributeType).FirstOrDefault();

            var departments = _unitOfWork.FormulaAttributeDepartment.FindByCondition(e => e.FormulaAttributeId.Equals(formulaAttribute.FormulaAttributeId)).Select(e => e.Department).ToList();
            formulaAttribute.Departments = departments;

            return formulaAttribute;
        }

        public int CreateFormulaAttribute(string formulaAttributeId, FormulaAttributeRequest formulaAttributeRequest)
        {
            var attribute = _unitOfWork.FormulaAttribute.FindByCondition(e => e.Attribute.ToLower().Equals(formulaAttributeRequest.Attribute.ToLower())).Select(e => e.Attribute).FirstOrDefault();
            if (attribute != null) throw new Exception($"Attribute '{attribute}' already exists");

            if (formulaAttributeRequest.FormulaAttributeTypeId != null)
            {
                var formulaAttributeType = _unitOfWork.FormulaAttributeType.Find(formulaAttributeRequest.FormulaAttributeTypeId);
                if (formulaAttributeType == null) throw new Exception("Not found FormulaAttributeType");
                else if (formulaAttributeType.Type.Equals(AttributeSalary.T_Quantity))
                {
                    if (formulaAttributeRequest.Value == null) throw new Exception("Values are not allowed to be empty when FormulaAttributeType is 'Task (Quantity)'");
                }
            }

            if (formulaAttributeRequest.GroupAttributeId != null)
            {
                var groupAttribute = _unitOfWork.GroupAttribute.Find(formulaAttributeRequest.GroupAttributeId);
                if (groupAttribute == null) throw new Exception("Not found GroupAttribute");
                else if (groupAttribute.GroupName.Equals(AttributeSalary.Function))
                {
                    throw new Exception("Cannot add FormulaAttribute for GroupAttribute 'Function'");
                }
            }

            FormulaAttribute formulaAttribute = new()
            {
                FormulaAttributeId = formulaAttributeId,
                Attribute = formulaAttributeRequest.Attribute,
                Value = formulaAttributeRequest.Value,
                AttributeName = formulaAttributeRequest.AttributeName,
                Description = formulaAttributeRequest.Description,
                IsDisable = formulaAttributeRequest.IsDisable,
                Limit = formulaAttributeRequest.Limit,
                FormulaAttributeTypeId = formulaAttributeRequest.FormulaAttributeTypeId,
                GroupAttributeId = formulaAttributeRequest.GroupAttributeId
            };

            _unitOfWork.FormulaAttribute.Create(formulaAttribute);

            if (formulaAttributeRequest.DepartmentIds != null && formulaAttributeRequest.DepartmentIds.Count > 0)
            {
                formulaAttributeRequest.DepartmentIds.ForEach(departmentId =>
                {
                    var department = _unitOfWork.Department.Find(departmentId);
                    if (department == null) throw new Exception("Not found department");

                    FormulaAttributeDepartment formulaAttributeDepartment = new()
                    {
                        FormulaAttributeDepartmentId = Guid.NewGuid().ToString(),
                        DepartmentId = departmentId,
                        FormulaAttributeId = formulaAttribute.FormulaAttributeId
                    };

                    _unitOfWork.FormulaAttributeDepartment.Create(formulaAttributeDepartment);
                });
            }

            int created = _unitOfWork.Complete();

            return created;
        }

        public int UpdateFormulaAttribute(string id, FormulaAttributeRequest formulaAttributeRequest)
        {
            if (formulaAttributeRequest.FormulaAttributeTypeId != null)
            {
                var formulaAttributeType = _unitOfWork.FormulaAttributeType.Find(formulaAttributeRequest.FormulaAttributeTypeId);
                if (formulaAttributeType == null) throw new Exception("Not found FormulaAttributeType");
                else if (formulaAttributeType.Type.Equals(AttributeSalary.T_Quantity))
                {
                    if (formulaAttributeRequest.Value == null) throw new Exception("Values are not allowed to be empty when FormulaAttributeType is 'Task (Quantity)'");
                }
            }

            if (formulaAttributeRequest.GroupAttributeId != null)
            {
                var groupAttribute = _unitOfWork.GroupAttribute.Find(formulaAttributeRequest.GroupAttributeId);
                if (groupAttribute == null) throw new Exception("Not found GroupAttribute");
                else if (groupAttribute.GroupName.Equals(AttributeSalary.Function))
                {
                    throw new Exception("Cannot update FormulaAttribute for GroupAttribute 'Function'");
                }
            }

            //var fAttribute = _context.FormulaAttributeFormulas.Where(e => e.FormulaAttributeId.Equals(id)).FirstOrDefault();
            //if (fAttribute != null) throw new Exception("This FormulaAttribute could not be updated, because it was already used at Formula.");

            int update = -1;

            var formulaAttribute = _unitOfWork.FormulaAttribute.Find(id);

            if (formulaAttribute != null)
            {
                var attribute = _unitOfWork.FormulaAttribute.FindByCondition(e => !e.FormulaAttributeId.Equals(formulaAttribute.FormulaAttributeId) && e.Attribute.ToLower().Equals(formulaAttributeRequest.Attribute.ToLower())).Select(e => e.Attribute).FirstOrDefault();
                if (attribute != null) throw new Exception($"Attribute '{attribute}' already exists");

                var ListfAttributef = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaAttributeId.Equals(id), e => e.Formula).ToList();
                var ListFormula = ListfAttributef.Select(e => e.Formula).ToList();

                ListFormula.ForEach(formula =>
                {
                    formula.CalculationFormula = FormulaValidate.ReplaceAll(formula.CalculationFormula, formulaAttribute.Attribute, formulaAttributeRequest.Attribute);

                    _unitOfWork.Formula.Update(formula);
                });

                formulaAttribute.Attribute = formulaAttributeRequest.Attribute;
                formulaAttribute.Value = formulaAttributeRequest.Value;
                formulaAttribute.AttributeName = formulaAttributeRequest.AttributeName;
                formulaAttribute.Description = formulaAttributeRequest.Description;
                formulaAttribute.IsDisable = formulaAttributeRequest.IsDisable;
                formulaAttribute.Limit = formulaAttributeRequest.Limit;
                formulaAttribute.FormulaAttributeTypeId = formulaAttributeRequest.FormulaAttributeTypeId;
                formulaAttribute.GroupAttributeId = formulaAttributeRequest.GroupAttributeId;

                _unitOfWork.FormulaAttribute.Update(formulaAttribute);

                //Remove FormulaAttributeDepartment
                _unitOfWork.FormulaAttributeDepartment.RemoveRange(_unitOfWork.FormulaAttributeDepartment.FindByCondition(e => e.FormulaAttributeId.Equals(formulaAttribute.FormulaAttributeId)));
                if (formulaAttributeRequest.DepartmentIds != null && formulaAttributeRequest.DepartmentIds.Count > 0)
                {
                    formulaAttributeRequest.DepartmentIds.ForEach(departmentId =>
                    {
                        var department = _unitOfWork.Department.Find(departmentId);
                        if (department == null) throw new Exception("Not found department");

                        FormulaAttributeDepartment formulaAttributeDepartment = new()
                        {
                            FormulaAttributeDepartmentId = Guid.NewGuid().ToString(),
                            DepartmentId = departmentId,
                            FormulaAttributeId = formulaAttribute.FormulaAttributeId
                        };

                        _unitOfWork.FormulaAttributeDepartment.Create(formulaAttributeDepartment);
                    });
                }

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int DisableFormulaAttribute(string id, bool status)
        {
            int update = -1;

            var formulaAttribute = _unitOfWork.FormulaAttribute.FindIncludeByCondition(e => e.FormulaAttributeId.Equals(id), e => e.GroupAttribute).FirstOrDefault();

            if (formulaAttribute != null)
            {
                if (formulaAttribute.GroupAttribute != null)
                {
                    if (formulaAttribute.GroupAttribute.GroupName.Equals(AttributeSalary.Function))
                    {
                        throw new Exception("Cannot change status FormulaAttribute for GroupAttribute 'Function'");
                    }
                }

                if (formulaAttribute.IsDisable == false && status == true)
                {
                    if (_unitOfWork.FormulaAttributeFormula.FindAll().Any(e => e.FormulaAttributeId.Equals(formulaAttribute.FormulaAttributeId)))
                        throw new Exception($"FormulaAttribute '{formulaAttribute.Attribute}' already existing in formula");
                }

                formulaAttribute.IsDisable = status;

                _unitOfWork.FormulaAttribute.Update(formulaAttribute);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int AddFormulaAttributeToGroup(FormulaAttrGroupRequest formulaAttrGroup)
        {
            if (formulaAttrGroup.GroupAttributeId != null)
            {
                var groupAttribute = _unitOfWork.GroupAttribute.Find(formulaAttrGroup.GroupAttributeId);
                if (groupAttribute == null) throw new Exception("Not found GroupAttribute");
            }

            int update = -1;

            var formulaAttribute = _unitOfWork.FormulaAttribute.Find(formulaAttrGroup.FormulaAttributeId);

            if (formulaAttribute != null)
            {
                formulaAttribute.GroupAttributeId = formulaAttrGroup.GroupAttributeId;

                _unitOfWork.FormulaAttribute.Update(formulaAttribute);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public dynamic GetFormulaAttributeList(Pagination pagination, bool? isDisable)
        {
            dynamic data = new ExpandoObject();
            int tottalRecords = 0;
            List<FormulaAttribute> formulaAttributes = null;

            if (isDisable != null)
            {
                formulaAttributes = _unitOfWork.FormulaAttribute.FindIncludeByCondition(e => e.IsDisable == isDisable, e => e.GroupAttribute, e => e.FormulaAttributeType)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.FormulaAttribute.FindByCondition(e => e.IsDisable == isDisable).Count();
            }
            else
            {
                formulaAttributes = _unitOfWork.FormulaAttribute.FindInclude(e => e.GroupAttribute, e => e.FormulaAttributeType)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.FormulaAttribute.FindAll().Count();
            }

            var tottalPage = Math.Ceiling(tottalRecords / (float)pagination.PageSize);

            data.pageNumber = pagination.PageNumber;
            data.pageSize = pagination.PageSize;
            data.totalRecords = tottalRecords;
            data.totalPage = tottalPage;
            data.data = formulaAttributes;

            return data;
        }

        public List<dynamic> GetFormulas()
        {
            List<dynamic> datas = new();

            _unitOfWork.Formula.FindAll().OrderBy(e => e.FormulaName).ToList().ForEach(formula =>
            {
                dynamic data = new ExpandoObject();
                data.formula = formula;

                var fAttributeF = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(formula.FormulaId),
                                e => e.FormulaAttribute.FormulaAttributeType, e => e.FormulaAttribute.GroupAttribute).ToList();

                List<FormulaAttribute> formulaAttributes = new();
                fAttributeF.ForEach(e =>
                {
                    formulaAttributes.Add(e.FormulaAttribute);
                });

                data.formulaAttributes = formulaAttributes;

                datas.Add(data);
            });

            return datas;
        }

        public dynamic GetFormula(string formulaId)
        {
            var formula = _unitOfWork.Formula.Find(formulaId);

            dynamic data = new ExpandoObject();
            data.formula = formula;

            var fAttributeF = _unitOfWork.FormulaAttributeFormula.FindIncludeByCondition(e => e.FormulaId.Equals(formulaId),
                                e => e.FormulaAttribute.FormulaAttributeType, e => e.FormulaAttribute.GroupAttribute).ToList();

            List<FormulaAttribute> formulaAttributes = new();
            fAttributeF.ForEach(e =>
            {
                formulaAttributes.Add(e.FormulaAttribute);
            });

            data.formulaAttributes = formulaAttributes;

            return data;
        }

        public int CreateFormula(string formulaId, FormulaRequest formulaRequest)
        {
            List<ErrorItem> errorItems = new();

            Expression expression = new(formulaRequest.CalculationFormula);

            formulaRequest.FormulaAttributes.ForEach(e =>
            {
                var formulaAttribute = _unitOfWork.FormulaAttribute.FindIncludeByCondition(c => c.Attribute.Trim().ToLower().Equals(e.Trim().ToLower()), e => e.GroupAttribute).FirstOrDefault();
                if (formulaAttribute == null)
                {
                    ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " not exists." };
                    errorItems.Add(errorItem);
                }
                else
                {
                    expression.Bind(e, 1);

                    if (formulaAttribute.GroupAttribute != null)
                    {
                        if (formulaAttribute.GroupAttribute.GroupName.Equals(AttributeSalary.Function))
                        {
                            ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " cannot match the function keyword of the formula." };
                            errorItems.Add(errorItem);
                        }
                    }

                    if (FormulaValidate.CheckFormula(e, formulaRequest.CalculationFormula)) //Check xem có trường nào dư ko, nếu Dư trả về true
                    {
                        ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " not exists in CalculationFormula." };
                        errorItems.Add(errorItem);
                    }
                }
            });

            //validate expression
            List<String> errors = expression.GetError();
            if (errors.Count != 0)
            {
                errors.ForEach(error =>
                {
                    ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = error };
                    errorItems.Add(errorItem);
                });
            }
            else
            {
                try
                {
                    expression.Eval();
                }
                catch (Exception ex)
                {
                    ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = ex.Message };
                    errorItems.Add(errorItem);
                }
            }

            if (formulaRequest.PayPolicyId != null)
            {
                var payPolicy = _unitOfWork.PayPolicy.Find(formulaRequest.PayPolicyId);
                if (payPolicy == null)
                {
                    ErrorItem errorItem = new() { ErrorName = "PayPolicy", ErrorMessage = "Not found PayPolicy" };
                    errorItems.Add(errorItem);
                }
            }

            Exception e = new("Error Formula");

            if (errorItems.Count > 0)
            {
                e.Data.Add(SOME_KEY, errorItems);
                throw e;
            }

            Formula formula = new()
            {
                FormulaId = formulaId,
                CalculationFormula = formulaRequest.CalculationFormula,
                FormulaName = formulaRequest.FormulaName,
                Description = formulaRequest.Description,
                IsDisable = formulaRequest.IsDisable,
                PayPolicyId = formulaRequest.PayPolicyId
            };

            _unitOfWork.Formula.Create(formula);

            formulaRequest.FormulaAttributes.ForEach(attribute =>
            {
                var formulaAttribute = _unitOfWork.FormulaAttribute.FindByCondition(e => e.Attribute.Trim().ToLower().Equals(attribute.Trim().ToLower())).FirstOrDefault();
                var fAttributeFId = Guid.NewGuid().ToString();
                FormulaAttributeFormula fAttributeF = new()
                {
                    FormulaAttributeFormulaId = fAttributeFId,
                    FormulaId = formulaId,
                    FormulaAttributeId = formulaAttribute.FormulaAttributeId
                };
                _unitOfWork.FormulaAttributeFormula.Create(fAttributeF);
            });

            int created = _unitOfWork.Complete();

            return created;
        }

        public int CreateFormulaNotAttribute(string formulaId, FormulaNotAttrRequest formulaRequest)
        {
            var formulaName = _unitOfWork.Formula.FindByCondition(e => e.FormulaName.ToLower().Equals(formulaRequest.FormulaName.ToLower())).Select(e => e.FormulaName).FirstOrDefault();
            if (formulaName != null) throw new Exception($"FormulaName '{formulaName}' already exists");

            List<ErrorItem> errorItems = new();

            Expression expression = new(formulaRequest.CalculationFormula);

            Exception e = new("Error Formula");

            List<string> formulaAttributes;

            try
            {
                formulaAttributes = expression.getVariables();
            }
            catch (Exception ex)
            {
                int index = ex.Message.IndexOf("position") + 9;
                if (index >= 0)
                {
                    string errorMassage = ex.Message[index..]; //ex.Message.Substring(index, ex.Message.Length - index)
                    int indexError;
                    try
                    {
                        indexError = int.Parse(errorMassage);
                    }
                    catch (Exception)
                    {
                        throw ex;
                    }
                    e = new($"Error Formula: {ex.Message}");
                    e.Data.Add("indexError", indexError - 1);
                    throw e;
                }
                throw;
            }

            formulaAttributes.ForEach(e =>
            {
                var formulaAttribute = _unitOfWork.FormulaAttribute.FindIncludeByCondition(c => c.Attribute.Trim().ToLower().Equals(e.Trim().ToLower()), e => e.GroupAttribute).FirstOrDefault();
                if (formulaAttribute == null)
                {
                    ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " not exists." };
                    errorItems.Add(errorItem);
                }
                else
                {
                    expression.Bind(e, 1);

                    if (formulaAttribute.GroupAttribute != null)
                    {
                        if (formulaAttribute.GroupAttribute.GroupName.Equals(AttributeSalary.Function))
                        {
                            ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " cannot match the function keyword of the formula." };
                            errorItems.Add(errorItem);
                        }
                    }

                    if (FormulaValidate.CheckFormula(e, formulaRequest.CalculationFormula)) //Check xem có trường nào dư ko, nếu Dư trả về true
                    {
                        ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " not exists in CalculationFormula." };
                        errorItems.Add(errorItem);
                    }
                }
            });

            //throw error FormulaAttribute not exists first 
            if (errorItems.Count > 0)
            {
                e.Data.Add(SOME_KEY, errorItems);
                throw e;
            }

            //validate expression
            List<String> errors = expression.GetError();
            if (errors.Count != 0)
            {
                errors.ForEach(error =>
                {
                    ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = error };
                    errorItems.Add(errorItem);
                });
            }
            else
            {
                try
                {
                    expression.Eval();
                }
                catch (Exception ex)
                {
                    ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = ex.Message };
                    errorItems.Add(errorItem);
                }
            }

            if (formulaRequest.PayPolicyId != null)
            {
                var payPolicy = _unitOfWork.PayPolicy.Find(formulaRequest.PayPolicyId);
                if (payPolicy == null)
                {
                    ErrorItem errorItem = new() { ErrorName = "PayPolicy", ErrorMessage = "Not found PayPolicy" };
                    errorItems.Add(errorItem);
                }
            }

            if (errorItems.Count > 0)
            {
                e.Data.Add(SOME_KEY, errorItems);
                throw e;
            }

            Formula formula = new()
            {
                FormulaId = formulaId,
                CalculationFormula = formulaRequest.CalculationFormula,
                FormulaName = formulaRequest.FormulaName,
                Description = formulaRequest.Description,
                IsDisable = formulaRequest.IsDisable,
                PayPolicyId = formulaRequest.PayPolicyId
            };

            _unitOfWork.Formula.Create(formula);

            formulaAttributes.ForEach(attribute =>
            {
                var formulaAttribute = _unitOfWork.FormulaAttribute.FindByCondition(e => e.Attribute.Trim().ToLower().Equals(attribute.Trim().ToLower())).FirstOrDefault();
                var fAttributeFId = Guid.NewGuid().ToString();
                FormulaAttributeFormula fAttributeF = new()
                {
                    FormulaAttributeFormulaId = fAttributeFId,
                    FormulaId = formulaId,
                    FormulaAttributeId = formulaAttribute.FormulaAttributeId
                };
                _unitOfWork.FormulaAttributeFormula.Create(fAttributeF);
            });

            int created = _unitOfWork.Complete();

            return created;
        }

        public string CheckFormula(FormulaCheckRequest formulaCheckRequest)
        {
            List<ErrorItem> errorItems = new();

            Expression expression = new(formulaCheckRequest.CalculationFormula);

            formulaCheckRequest.FormulaAttributes.ForEach(e =>
            {
                var formulaAttribute = _unitOfWork.FormulaAttribute.FindByCondition(c => c.Attribute.Trim().ToLower().Equals(e.Trim().ToLower())).FirstOrDefault();
                if (formulaAttribute == null)
                {
                    ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " not exists." };
                    errorItems.Add(errorItem);
                }
                else
                {
                    expression.Bind(e, 1);
                    if (FormulaValidate.CheckFormula(e, formulaCheckRequest.CalculationFormula)) //Check xem có trường nào dư ko, nếu Dư trả về true
                    {
                        ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " not exists in CalculationFormula." };
                        errorItems.Add(errorItem);
                    }
                }
            });

            //validate expression
            List<String> errors = expression.GetError();
            if (errors.Count != 0)
            {
                errors.ForEach(error =>
                {
                    ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = error };
                    errorItems.Add(errorItem);
                });
            }
            else
            {
                try
                {
                    expression.Eval();
                }
                catch (Exception ex)
                {
                    ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = ex.Message };
                    errorItems.Add(errorItem);
                }
            }

            Exception e = new("Error Formula");

            if (errorItems.Count > 0)
            {
                e.Data.Add(SOME_KEY, errorItems);
                throw e;
            }
            else
            {
                return "Correct Formula";
            }
        }

        public string CheckFormulaNotAttribute(FormulaCheckNotAttrRequest formulaCheckRequest)
        {
            List<ErrorItem> errorItems = new();

            Expression expression = new(formulaCheckRequest.CalculationFormula);

            Exception e = new("Error Formula");

            List<string> formulaAttributes;

            try
            {
                formulaAttributes = expression.getVariables();
            }
            catch (Exception ex)
            {
                int index = ex.Message.IndexOf("position") + 9;
                if (index >= 0)
                {
                    string errorMassage = ex.Message[index..];
                    int indexError;
                    try
                    {
                        indexError = int.Parse(errorMassage);
                    }
                    catch (Exception)
                    {
                        throw ex;
                    }
                    e.Data.Add("indexError", indexError - 1);
                    throw e;
                }
                throw;
            }


            formulaAttributes.ForEach(e =>
                {
                    var formulaAttribute = _unitOfWork.FormulaAttribute.FindByCondition(c => c.Attribute.Trim().ToLower().Equals(e.Trim().ToLower())).FirstOrDefault();
                    if (formulaAttribute == null)
                    {
                        ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " not exists." };
                        errorItems.Add(errorItem);
                    }
                    else
                    {
                        expression.Bind(e, 1);
                        if (FormulaValidate.CheckFormula(e, formulaCheckRequest.CalculationFormula)) //Check xem có trường nào dư ko, nếu Dư trả về true
                        {
                            ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " not exists in CalculationFormula." };
                            errorItems.Add(errorItem);
                        }
                    }
                });

            //validate expression
            List<String> errors = expression.GetError();
            if (errors.Count != 0)
            {
                errors.ForEach(error =>
                {
                    ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = error };
                    errorItems.Add(errorItem);
                });
            }
            else
            {
                try
                {
                    expression.Eval();
                }
                catch (Exception ex)
                {
                    ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = ex.Message };
                    errorItems.Add(errorItem);
                }
            }

            if (errorItems.Count > 0)
            {
                e.Data.Add(SOME_KEY, errorItems);
                throw e;
            }
            else
            {
                return "Correct Formula";
            }
        }

        public int AddFormulaToLecType(FormulaLecTypeRequest formulaLecType)
        {
            int update = -1;

            var lecturerType = _unitOfWork.LecturerType.Find(formulaLecType.LecturerTypeId);

            var formula = _unitOfWork.Formula.Find(formulaLecType.FormulaId);
            if (formula == null) throw new Exception("Not found Formula.");

            if (lecturerType != null)
            {
                lecturerType.FormulaId = formulaLecType.FormulaId;

                _unitOfWork.LecturerType.Update(lecturerType);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int UpdateFormula(string formulaId, FormulaRequest formulaRequest)
        {
            int update = -1;

            List<ErrorItem> errorItems = new();
            Exception exception = new("Error Formula");

            var formula = _unitOfWork.Formula.Find(formulaId);
            if (formula == null)
            {
                ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = "Not found Formula" };
                errorItems.Add(errorItem);
                exception.Data.Add(SOME_KEY, errorItems);
                throw exception;
            }

            Expression expression = new(formulaRequest.CalculationFormula);

            formulaRequest.FormulaAttributes.ForEach(e =>
            {
                var formulaAttribute = _unitOfWork.FormulaAttribute.FindIncludeByCondition(c => c.Attribute.Trim().ToLower().Equals(e.Trim().ToLower()), e => e.GroupAttribute).FirstOrDefault();
                if (formulaAttribute == null)
                {
                    ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " not exists." };
                    errorItems.Add(errorItem);
                }
                else
                {
                    expression.Bind(e, 1);

                    if (formulaAttribute.GroupAttribute != null)
                    {
                        if (formulaAttribute.GroupAttribute.GroupName.Equals(AttributeSalary.Function)) //Check xem có FormulaAttribute nào trùng với các hàm trong thư viện hỗ trợ ko (ví dụ như Min, Max,...)
                        {
                            ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " cannot match the function keyword of the formula." };
                            errorItems.Add(errorItem);
                        }
                    }

                    if (FormulaValidate.CheckFormula(e, formulaRequest.CalculationFormula)) //Check xem có trường nào dư ko, nếu Dư trả về true
                    {
                        ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " not exists in CalculationFormula." };
                        errorItems.Add(errorItem);
                    }
                }
            });

            //validate expression
            List<String> errors = expression.GetError();
            if (errors.Count != 0)
            {
                errors.ForEach(error =>
                {
                    ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = error };
                    errorItems.Add(errorItem);
                });
            }
            else
            {
                try
                {
                    expression.Eval();
                }
                catch (Exception ex)
                {
                    ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = ex.Message };
                    errorItems.Add(errorItem);
                }
            }

            if (formulaRequest.PayPolicyId != null)
            {
                var payPolicy = _unitOfWork.PayPolicy.Find(formulaRequest.PayPolicyId);
                if (payPolicy == null)
                {
                    ErrorItem errorItem = new() { ErrorName = "PayPolicy", ErrorMessage = "Not found PayPolicy" };
                    errorItems.Add(errorItem);
                }
            }

            if (errorItems.Count > 0)
            {
                exception.Data.Add(SOME_KEY, errorItems);
                throw exception;
            }

            if (formula != null)
            {
                formula.FormulaId = formulaId;
                formula.CalculationFormula = formulaRequest.CalculationFormula;
                formula.FormulaName = formulaRequest.FormulaName;
                formula.Description = formulaRequest.Description;
                formula.IsDisable = formulaRequest.IsDisable;
                formula.PayPolicyId = formulaRequest.PayPolicyId;
            }
            _unitOfWork.Formula.Update(formula);

            _unitOfWork.FormulaAttributeFormula.RemoveRange(_unitOfWork.FormulaAttributeFormula.FindByCondition(e => e.FormulaId.Equals(formulaId)));

            formulaRequest.FormulaAttributes.ForEach(attribute =>
            {
                var formulaAttribute = _unitOfWork.FormulaAttribute.FindByCondition(e => e.Attribute.Trim().ToLower().Equals(attribute.Trim().ToLower())).FirstOrDefault();
                var fAttributeFId = Guid.NewGuid().ToString();
                FormulaAttributeFormula fAttributeF = new()
                {
                    FormulaAttributeFormulaId = fAttributeFId,
                    FormulaId = formulaId,
                    FormulaAttributeId = formulaAttribute.FormulaAttributeId
                };
                _unitOfWork.FormulaAttributeFormula.Create(fAttributeF);
            });

            update = _unitOfWork.Complete();

            return update;
        }

        public int UpdateFormulaNotAttribute(string formulaId, FormulaNotAttrRequest formulaRequest)
        {
            int update = -1;

            List<ErrorItem> errorItems = new();

            Exception e = new("Error Formula");

            var formula = _unitOfWork.Formula.Find(formulaId);
            if (formula == null)
            {
                ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = "Not found Formula" };
                errorItems.Add(errorItem);
                e.Data.Add(SOME_KEY, errorItems);
                throw e;
            }

            if (formula.FormulaName.Equals(Tax.TaxFormula))
            {
                if (!formulaRequest.FormulaName.Equals(Tax.TaxFormula)) throw new Exception("FormulaName of TaxFormula cannot be changed");
            }

            Expression expression = new(formulaRequest.CalculationFormula);

            List<string> formulaAttributes;

            try
            {
                formulaAttributes = expression.getVariables();
            }
            catch (Exception ex)
            {
                int index = ex.Message.IndexOf("position") + 9;
                if (index >= 0)
                {
                    string errorMassage = ex.Message[index..];
                    int indexError;
                    try
                    {
                        indexError = int.Parse(errorMassage);
                    }
                    catch (Exception)
                    {
                        throw ex;
                    }
                    e = new($"Error Formula: {ex.Message}");
                    e.Data.Add("indexError", indexError - 1);
                    throw e;
                }
                throw;
            }

            formulaAttributes.ForEach(e =>
            {
                var formulaAttribute = _unitOfWork.FormulaAttribute.FindIncludeByCondition(c => c.Attribute.Trim().ToLower().Equals(e.Trim().ToLower()), e => e.GroupAttribute).FirstOrDefault();
                if (formulaAttribute == null)
                {
                    ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " not exists." };
                    errorItems.Add(errorItem);
                }
                else
                {
                    expression.Bind(e, 1);

                    if (formulaAttribute.GroupAttribute != null)
                    {
                        if (formulaAttribute.GroupAttribute.GroupName.Equals(AttributeSalary.Function)) //Check xem có FormulaAttribute nào trùng với các hàm trong thư viện hỗ trợ ko (ví dụ như Min, Max,...)
                        {
                            ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " cannot match the function keyword of the formula." };
                            errorItems.Add(errorItem);
                        }
                    }

                    if (FormulaValidate.CheckFormula(e, formulaRequest.CalculationFormula)) //Check xem có trường nào dư ko, nếu Dư trả về true
                    {
                        ErrorItem errorItem = new() { ErrorName = e.Trim(), ErrorMessage = "FormulaAttribute " + e + " not exists in CalculationFormula." };
                        errorItems.Add(errorItem);
                    }
                }
            });

            //throw error FormulaAttribute not exists first 
            if (errorItems.Count > 0)
            {
                e.Data.Add(SOME_KEY, errorItems);
                throw e;
            }

            //validate expression
            List<String> errors = expression.GetError();
            if (errors.Count != 0)
            {
                errors.ForEach(error =>
                {
                    ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = error };
                    errorItems.Add(errorItem);
                });
            }
            else
            {
                try
                {
                    expression.Eval();
                }
                catch (Exception ex)
                {
                    ErrorItem errorItem = new() { ErrorName = "Formula", ErrorMessage = ex.Message };
                    errorItems.Add(errorItem);
                }
            }

            if (formulaRequest.PayPolicyId != null)
            {
                var payPolicy = _unitOfWork.PayPolicy.Find(formulaRequest.PayPolicyId);
                if (payPolicy == null)
                {
                    ErrorItem errorItem = new() { ErrorName = "PayPolicy", ErrorMessage = "Not found PayPolicy" };
                    errorItems.Add(errorItem);
                }
            }

            if (errorItems.Count > 0)
            {
                e.Data.Add(SOME_KEY, errorItems);
                throw e;
            }

            if (formula != null)
            {
                var formulaName = _unitOfWork.Formula.FindByCondition(e => !e.FormulaId.Equals(formula.FormulaId) && e.FormulaName.ToLower().Equals(formulaRequest.FormulaName.ToLower())).Select(e => e.FormulaName).FirstOrDefault();
                if (formulaName != null) throw new Exception($"FormulaName '{formulaName}' already exists");

                formula.FormulaId = formulaId;
                formula.CalculationFormula = formulaRequest.CalculationFormula;
                formula.FormulaName = formulaRequest.FormulaName;
                formula.Description = formulaRequest.Description;
                formula.IsDisable = formulaRequest.IsDisable;
                formula.PayPolicyId = formulaRequest.PayPolicyId;
            }
            _unitOfWork.Formula.Update(formula);

            _unitOfWork.FormulaAttributeFormula.RemoveRange(_unitOfWork.FormulaAttributeFormula.FindByCondition(e => e.FormulaId.Equals(formulaId)));

            formulaAttributes.ForEach(attribute =>
            {
                var formulaAttribute = _unitOfWork.FormulaAttribute.FindByCondition(e => e.Attribute.Trim().ToLower().Equals(attribute.Trim().ToLower())).FirstOrDefault();
                var fAttributeFId = Guid.NewGuid().ToString();
                FormulaAttributeFormula fAttributeF = new()
                {
                    FormulaAttributeFormulaId = fAttributeFId,
                    FormulaId = formulaId,
                    FormulaAttributeId = formulaAttribute.FormulaAttributeId
                };
                _unitOfWork.FormulaAttributeFormula.Create(fAttributeF);
            });

            update = _unitOfWork.Complete();

            return update;
        }

        public int DisableFormula(string id, bool status)
        {
            int update = -1;

            var formula = _unitOfWork.Formula.Find(id);

            if (formula != null)
            {
                if (formula.IsDisable == false && status == true)
                {
                    if (_unitOfWork.LecturerType.FindAll().Any(e => e.FormulaId.Equals(formula.FormulaId)))
                        throw new Exception($"Formula '{formula.FormulaName}' already existing in lecturer type");
                }

                formula.IsDisable = status;

                _unitOfWork.Formula.Update(formula);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public List<FormulaAttributeType> GetFormulaAttributeTypes()
        {
            var formulaAttributeTypes = _unitOfWork.FormulaAttributeType.FindAll().ToList();
            return formulaAttributeTypes;
        }
    }
}
