using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System.Collections.Generic;

namespace SalaryManagement.Services.FormulaService
{
    public interface IFormulaService
    {
        List<GroupAttribute> GetGroupAttributes();
        List<FormulaAttribute> GetFormulaAttrFunction();
        List<FormulaAttribute> GetFormulaAttrNotFunction();
        List<dynamic> GetFormulaAttrsOfGroupAttrs();
        List<FormulaAttribute> GetFormulaAttrInGroupAttr(string groupAttributeId);
        GroupAttribute GetGroupAttribute(string groupAttributeId);
        int CreateGroupAttribute(string groupAttributeId, GroupAttributeRequest groupAttributeRequest);
        int UpdateGroupAttribute(string id, GroupAttributeRequest groupAttributeRequest);
        int DisableGroupAttribute(string groupAttributeId, bool status);
        List<PayPolicy> GetPayPolicies();
        PayPolicy GetPayPolicy(string payPolicyId);
        int CreatePayPolicy(string payPolicyId, PayPolicyRequest payPolicyRequest);
        int UpdatePayPolicy(string id, PayPolicyRequest payPolicyRequest);
        List<FormulaAttribute> GetFormulaAttributes();
        List<FormulaAttribute> GetFormulaAttributesByAttribute(string attribute);
        FormulaAttribute GetFormulaAttribute(string formulaAttributeId);
        int CreateFormulaAttribute(string formulaAttributeId, FormulaAttributeRequest formulaAttributeRequest);
        int UpdateFormulaAttribute(string id, FormulaAttributeRequest formulaAttributeRequest);
        int DisableFormulaAttribute(string id, bool status);
        int AddFormulaAttributeToGroup(FormulaAttrGroupRequest formulaAttrGroup);
        dynamic GetFormulaAttributeList(Pagination pagination, bool? isDisable);
        List<dynamic> GetFormulas();
        dynamic GetFormula(string formulaId);
        int CreateFormula(string formulaId, FormulaRequest formulaRequest);
        int CreateFormulaNotAttribute(string formulaId, FormulaNotAttrRequest formulaRequest);
        string CheckFormula(FormulaCheckRequest formulaCheckRequest);
        string CheckFormulaNotAttribute(FormulaCheckNotAttrRequest formulaCheckRequest);
        int AddFormulaToLecType(FormulaLecTypeRequest formulaLecType);
        int UpdateFormula(string formulaId, FormulaRequest formulaRequest);
        int UpdateFormulaNotAttribute(string formulaId, FormulaNotAttrRequest formulaRequest);
        int DisableFormula(string id, bool status);
        List<FormulaAttributeType> GetFormulaAttributeTypes();
    }
}
