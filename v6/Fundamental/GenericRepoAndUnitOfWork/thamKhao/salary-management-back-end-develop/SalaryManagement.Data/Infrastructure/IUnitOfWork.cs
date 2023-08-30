using Microsoft.EntityFrameworkCore.Storage;
using SalaryManagement.Models;
using SalaryManagement.Repositories;
using System;

namespace SalaryManagement.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IBasicSalaryRepository BasicSalary { get; }
        IAdminRepository Admin { get; }
        IConfigurationRepository Configuration { get; }
        IDepartmentRepository Department { get; }
        IFESalaryRepository FESalary { get; }
        IFormulaRepository Formula { get; }
        IFormulaAttributeRepository FormulaAttribute { get; }
        IFormulaAttributeFormulaRepository FormulaAttributeFormula { get; }
        IFormulaAttributeTypeRepository FormulaAttributeType { get; }
        IGeneralUserInfoRepository GeneralUserInfo { get; }
        IGroupAttributeRepository GroupAttribute { get; }
        ILecturerRepository Lecturer { get; }
        ILecturerDepartmentRepository LecturerDepartment { get; }
        ILecturerPositionRepository LecturerPosition { get; }
        ILecturerTypeRepository LecturerType { get; }
        IPayPolicyRepository PayPolicy { get; }
        IPayPeriodRepository PayPeriod { get; }
        IPaySlipRepository PaySlip { get; }
        IPaySlipItemRepository PaySlipItem { get; }
        IRoleRepository Role { get; }
        ISalaryHistoryRepository SalaryHistory { get; }
        ISchoolRepository School { get; }
        ISchoolTypeRepository SchoolType { get; }
        ISemesterRepository Semester { get; }
        ISemesterSchoolTypeRepository SemesterSchoolType { get; }
        IManagerRepository Manager { get; }
        ITeachingSummaryRepository TeachingSummary { get; }
        ITeachingSummaryDetailRepository TeachingSummaryDetail { get; }
        IProctoringSignRepository ProctoringSign { get; }
        ITimeSlotRepository TimeSlot { get; }
        IFormulaAttributeDepartmentRepository FormulaAttributeDepartment { get; }

        IDbContextTransaction BeginTransaction();
        SalaryConfirmContext GetContext();
        int Complete();
    }
}
