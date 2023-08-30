using Microsoft.EntityFrameworkCore.Storage;
using SalaryManagement.Models;
using SalaryManagement.Repositories;

namespace SalaryManagement.Infrastructure
{
    public class UnitOfWord : IUnitOfWork
    {
        private readonly SalaryConfirmContext _context;

        private IAdminRepository _admin;
        private IBasicSalaryRepository _basicSalary;
        private IDepartmentRepository _department;
        private IFESalaryRepository _feSalary;
        private IFormulaRepository _formula;
        private IFormulaAttributeRepository _formulaAttribute;
        private IFormulaAttributeFormulaRepository _formulaAttributeFormula;
        private IFormulaAttributeTypeRepository _formulaAttributeType;
        private IGeneralUserInfoRepository _generalUserInfo;
        private IGroupAttributeRepository _groupAttribute;
        private ILecturerRepository _lecturer;
        private ILecturerDepartmentRepository _lecturerDepartment;
        private ILecturerPositionRepository _lecturerPosition;
        private ILecturerTypeRepository _lecturerType;
        private IPayPeriodRepository _payPeriod;
        private IPayPolicyRepository _payPolicy;
        private IPaySlipRepository _paySlip;
        private IPaySlipItemRepository _paySlipItem;
        private IRoleRepository _role;
        private ISalaryHistoryRepository _salaryHistory;
        private ISchoolRepository _school;
        private ISchoolTypeRepository _schoolType;
        private ISemesterRepository _semester;
        private ISemesterSchoolTypeRepository _semesterSchoolType;
        private IManagerRepository _manager;
        private ITeachingSummaryRepository _teachingSummary;
        private ITeachingSummaryDetailRepository _teachingSummaryDetail;
        private IProctoringSignRepository _proctoringSign;
        private ITimeSlotRepository _timeSlot;
        private IConfigurationRepository _configuration;
        private IFormulaAttributeDepartmentRepository _formulaAttributeDepartment;

        public IAdminRepository Admin
        {
            get
            {
                /*if (_admin == null)
                {
                    _admin = new AdminRepository(_context);
                }*/
                _admin ??= new AdminRepository(_context);
                return _admin;
            }
        }
        public IBasicSalaryRepository BasicSalary
        {
            get
            {
                _basicSalary ??= new BasicSalaryRepository(_context);
                return _basicSalary;
            }
        }
        public IDepartmentRepository Department
        {
            get
            {
                _department ??= new DepartmentRepository(_context);
                return _department;
            }
        }
        public IFESalaryRepository FESalary
        {
            get
            {
                _feSalary ??= new FESalaryRepository(_context);
                return _feSalary;
            }
        }
        public IFormulaRepository Formula
        {
            get
            {
                _formula ??= new FormulaRepository(_context);
                return _formula;
            }
        }
        public IFormulaAttributeRepository FormulaAttribute
        {
            get
            {
                _formulaAttribute ??= new FormulaAttributeRepository(_context);
                return _formulaAttribute;
            }
        }
        public IFormulaAttributeFormulaRepository FormulaAttributeFormula
        {
            get
            {
                _formulaAttributeFormula ??= new FormulaAttributeFormulaRepository(_context);
                return _formulaAttributeFormula;
            }
        }
        public IFormulaAttributeTypeRepository FormulaAttributeType
        {
            get
            {
                _formulaAttributeType ??= new FormulaAttributeTypeRepository(_context);
                return _formulaAttributeType;
            }
        }
        public IGeneralUserInfoRepository GeneralUserInfo
        {
            get
            {
                _generalUserInfo ??= new GeneralUserInfoRepository(_context);
                return _generalUserInfo;
            }
        }
        public IGroupAttributeRepository GroupAttribute
        {
            get
            {
                _groupAttribute ??= new GroupAttributeRepository(_context);
                return _groupAttribute;
            }
        }
        public ILecturerRepository Lecturer
        {
            get
            {
                _lecturer ??= new LecturerRepository(_context);
                return _lecturer;
            }
        }
        public ILecturerDepartmentRepository LecturerDepartment
        {
            get
            {
                _lecturerDepartment ??= new LecturerDepartmentRepository(_context);
                return _lecturerDepartment;
            }
        }
        public ILecturerPositionRepository LecturerPosition
        {
            get
            {
                _lecturerPosition ??= new LecturerPositionRepository(_context);
                return _lecturerPosition;
            }
        }
        public ILecturerTypeRepository LecturerType
        {
            get
            {
                _lecturerType ??= new LecturerTypeRepository(_context);
                return _lecturerType;
            }
        }
        public IPayPeriodRepository PayPeriod
        {
            get
            {
                _payPeriod ??= new PayPeriodRepository(_context);
                return _payPeriod;
            }
        }
        public IPayPolicyRepository PayPolicy
        {
            get
            {
                _payPolicy ??= new PayPolicyRepository(_context);
                return _payPolicy;
            }
        }
        public IPaySlipRepository PaySlip
        {
            get
            {
                _paySlip ??= new PaySlipRepository(_context);
                return _paySlip;
            }
        }
        public IPaySlipItemRepository PaySlipItem
        {
            get
            {
                _paySlipItem ??= new PaySlipItemRepository(_context);
                return _paySlipItem;
            }
        }
        public IRoleRepository Role
        {
            get
            {
                _role ??= new RoleRepository(_context);
                return _role;
            }
        }
        public ISalaryHistoryRepository SalaryHistory
        {
            get
            {
                _salaryHistory ??= new SalaryHistoryRepository(_context);
                return _salaryHistory;
            }
        }
        public ISchoolRepository School
        {
            get
            {
                _school ??= new SchoolRepository(_context);
                return _school;
            }
        }
        public ISchoolTypeRepository SchoolType
        {
            get
            {
                _schoolType ??= new SchoolTypeRepository(_context);
                return _schoolType;
            }
        }
        public ISemesterRepository Semester
        {
            get
            {
                _semester ??= new SemesterRepository(_context);
                return _semester;
            }
        }
        public ISemesterSchoolTypeRepository SemesterSchoolType
        {
            get
            {
                _semesterSchoolType ??= new SemesterSchoolTypeRepository(_context);
                return _semesterSchoolType;
            }
        }
        public IManagerRepository Manager
        {
            get
            {
                _manager ??= new ManagerRepository(_context);
                return _manager;
            }
        }

        public ITeachingSummaryRepository TeachingSummary
        {
            get
            {
                _teachingSummary ??= new TeachingSummaryRepository(_context);
                return _teachingSummary;
            }
        }

        public ITeachingSummaryDetailRepository TeachingSummaryDetail
        {
            get
            {
                _teachingSummaryDetail ??= new TeachingSummaryDetailRepository(_context);
                return _teachingSummaryDetail;
            }
        }

        public IProctoringSignRepository ProctoringSign
        {
            get
            {
                _proctoringSign ??= new ProctoringSignRepository(_context);
                return _proctoringSign;
            }
        }

        public ITimeSlotRepository TimeSlot
        {
            get
            {
                _timeSlot ??= new TimeSlotRepository(_context);
                return _timeSlot;
            }
        }

        public IConfigurationRepository Configuration
        {
            get
            {
                _configuration ??= new ConfigurationRepository(_context);
                return _configuration;
            }
        }

        public IFormulaAttributeDepartmentRepository FormulaAttributeDepartment
        {
            get
            {
                _formulaAttributeDepartment ??= new FormulaAttributeDepartmentRepository(_context);
                return _formulaAttributeDepartment;
            }
        }

        public UnitOfWord(SalaryConfirmContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            int result = _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return result;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public SalaryConfirmContext GetContext()
        {
            return _context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
