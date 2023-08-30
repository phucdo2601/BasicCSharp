using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;
using Microsoft.Extensions.Configuration;
using SalaryManagement.Common;
using System.Text;

#nullable disable

namespace SalaryManagement.Models
{
    public partial class SalaryConfirmContext : DbContext
    {
        public SalaryConfirmContext()
        {
        }

        public SalaryConfirmContext(DbContextOptions<SalaryConfirmContext> options)
            : base(options)
        {
        }

        //Encryption
        private static readonly byte[] _encryptionKey = Encoding.ASCII.GetBytes(GetKeyEncrypt()); //Key Encryption
        private readonly IEncryptionProvider _provider = new AesProvider(_encryptionKey);

        public static string GetKeyEncrypt()
        {
            var MyConfig = new ConfigurationBuilder().AddJsonFile(Settings.APP_SETTINGS_JSON).Build();
            var keyEncrypt = MyConfig.GetValue<string>(Settings.KEY_ENCRYPT);

            return keyEncrypt;
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BasicSalary> BasicSalaries { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Fesalary> Fesalaries { get; set; }
        public virtual DbSet<Formula> Formulas { get; set; }
        public virtual DbSet<FormulaAttribute> FormulaAttributes { get; set; }
        public virtual DbSet<FormulaAttributeDepartment> FormulaAttributeDepartments { get; set; }
        public virtual DbSet<FormulaAttributeFormula> FormulaAttributeFormulas { get; set; }
        public virtual DbSet<FormulaAttributeType> FormulaAttributeTypes { get; set; }
        public virtual DbSet<GeneralUserInfo> GeneralUserInfos { get; set; }
        public virtual DbSet<GroupAttribute> GroupAttributes { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<LecturerDepartment> LecturerDepartments { get; set; }
        public virtual DbSet<LecturerPosition> LecturerPositions { get; set; }
        public virtual DbSet<LecturerType> LecturerTypes { get; set; }
        public virtual DbSet<PayPeriod> PayPeriods { get; set; }
        public virtual DbSet<PayPolicy> PayPolicies { get; set; }
        public virtual DbSet<PaySlip> PaySlips { get; set; }
        public virtual DbSet<PaySlipItem> PaySlipItems { get; set; }
        public virtual DbSet<ProctoringSign> ProctoringSigns { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SalaryHistory> SalaryHistories { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<SchoolType> SchoolTypes { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<SemesterSchoolType> SemesterSchoolTypes { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<TeachingSummary> TeachingSummaries { get; set; }
        public virtual DbSet<TeachingSummaryDetail> TeachingSummaryDetails { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEncryption(_provider);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasMaxLength(50);

                entity.Property(e => e.GeneralUserInfoId).HasMaxLength(50);

                entity.HasOne(d => d.GeneralUserInfo)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.GeneralUserInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admin_GeneralUserInfo");
            });

            modelBuilder.Entity<BasicSalary>(entity =>
            {
                entity.ToTable("BasicSalary");

                entity.Property(e => e.BasicSalaryId).HasMaxLength(50);

                entity.Property(e => e.BasicSalaryLevel)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.ToTable("Configuration");

                entity.Property(e => e.ConfigurationId).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasMaxLength(50);

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SchoolId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_School");
            });

            modelBuilder.Entity<Fesalary>(entity =>
            {
                entity.ToTable("FESalary");

                entity.Property(e => e.FesalaryId)
                    .HasMaxLength(50)
                    .HasColumnName("FESalaryId");

                entity.Property(e => e.FesalaryCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FESalaryCode");
            });

            modelBuilder.Entity<Formula>(entity =>
            {
                entity.ToTable("Formula");

                entity.Property(e => e.FormulaId).HasMaxLength(50);

                entity.Property(e => e.CalculationFormula)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FormulaName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PayPolicyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.PayPolicy)
                    .WithMany(p => p.Formulas)
                    .HasForeignKey(d => d.PayPolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Formula_PayPolicy");
            });

            modelBuilder.Entity<FormulaAttribute>(entity =>
            {
                entity.ToTable("FormulaAttribute");

                entity.Property(e => e.FormulaAttributeId).HasMaxLength(50);

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FormulaAttributeTypeId).HasMaxLength(50);

                entity.Property(e => e.GroupAttributeId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FormulaAttributeType)
                    .WithMany(p => p.FormulaAttributes)
                    .HasForeignKey(d => d.FormulaAttributeTypeId)
                    .HasConstraintName("FK_FormulaAttribute_FormulaAttributeType");

                entity.HasOne(d => d.GroupAttribute)
                    .WithMany(p => p.FormulaAttributes)
                    .HasForeignKey(d => d.GroupAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormulaAttribute_GroupAttribute");
            });

            modelBuilder.Entity<FormulaAttributeDepartment>(entity =>
            {
                entity.ToTable("FormulaAttributeDepartment");

                entity.Property(e => e.FormulaAttributeDepartmentId).HasMaxLength(50);

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormulaAttributeId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.FormulaAttributeDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormulaAttributeDepartment_Department");

                entity.HasOne(d => d.FormulaAttribute)
                    .WithMany(p => p.FormulaAttributeDepartments)
                    .HasForeignKey(d => d.FormulaAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormulaAttributeDepartment_FormulaAttribute");
            });

            modelBuilder.Entity<FormulaAttributeFormula>(entity =>
            {
                entity.ToTable("FormulaAttributeFormula");

                entity.Property(e => e.FormulaAttributeFormulaId).HasMaxLength(50);

                entity.Property(e => e.FormulaAttributeId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormulaId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FormulaAttribute)
                    .WithMany(p => p.FormulaAttributeFormulas)
                    .HasForeignKey(d => d.FormulaAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormulaAttributeFormula_FormulaAttribute");

                entity.HasOne(d => d.Formula)
                    .WithMany(p => p.FormulaAttributeFormulas)
                    .HasForeignKey(d => d.FormulaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormulaAttributeFormula_Formula");
            });

            modelBuilder.Entity<FormulaAttributeType>(entity =>
            {
                entity.ToTable("FormulaAttributeType");

                entity.Property(e => e.FormulaAttributeTypeId).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<GeneralUserInfo>(entity =>
            {
                entity.ToTable("GeneralUserInfo");

                entity.Property(e => e.GeneralUserInfoId).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Gmail)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.ImageUrl).HasColumnType("ntext");

                entity.Property(e => e.NationalId).HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.GeneralUserInfos)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GeneralUserInfo_Role");
            });

            modelBuilder.Entity<GroupAttribute>(entity =>
            {
                entity.ToTable("GroupAttribute");

                entity.Property(e => e.GroupAttributeId).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.ToTable("Lecturer");

                entity.Property(e => e.LecturerId).HasMaxLength(50);

                entity.Property(e => e.BasicSalaryId)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FesalaryId)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("FESalaryId");

                entity.Property(e => e.GeneralUserInfoId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LecturerCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LecturerTypeId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.GeneralUserInfo)
                    .WithMany(p => p.Lecturers)
                    .HasForeignKey(d => d.GeneralUserInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecturer_GeneralUserInfo");

                entity.HasOne(d => d.LecturerType)
                    .WithMany(p => p.Lecturers)
                    .HasForeignKey(d => d.LecturerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecturer_LecturerType");
            });

            modelBuilder.Entity<LecturerDepartment>(entity =>
            {
                entity.ToTable("LecturerDepartment");

                entity.Property(e => e.LecturerDepartmentId).HasMaxLength(50);

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LecturerId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LecturerPositionId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.LecturerDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LecturerDepartment_Department");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.LecturerDepartments)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LecturerDepartment_Lecturer");

                entity.HasOne(d => d.LecturerPosition)
                    .WithMany(p => p.LecturerDepartments)
                    .HasForeignKey(d => d.LecturerPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LecturerDepartment_LecturerPosition");
            });

            modelBuilder.Entity<LecturerPosition>(entity =>
            {
                entity.ToTable("LecturerPosition");

                entity.Property(e => e.LecturerPositionId).HasMaxLength(50);

                entity.Property(e => e.LecturerPositionName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<LecturerType>(entity =>
            {
                entity.ToTable("LecturerType");

                entity.Property(e => e.LecturerTypeId).HasMaxLength(50);

                entity.Property(e => e.FormulaId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LecturerTypeName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Formula)
                    .WithMany(p => p.LecturerTypes)
                    .HasForeignKey(d => d.FormulaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LecturerType_Formula");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.ManagerId).HasMaxLength(50);

                entity.Property(e => e.GeneralUserInfoId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.GeneralUserInfo)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.GeneralUserInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manager_GeneralUserInfo");
            });

            modelBuilder.Entity<PayPeriod>(entity =>
            {
                entity.ToTable("PayPeriod");

                entity.Property(e => e.PayPeriodId).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.PayPeriodName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PayPolicyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SemesterId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.PayPolicy)
                    .WithMany(p => p.PayPeriods)
                    .HasForeignKey(d => d.PayPolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayPeriod_PayPolicy");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.PayPeriods)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayPeriod_Semester");
            });

            modelBuilder.Entity<PayPolicy>(entity =>
            {
                entity.ToTable("PayPolicy");

                entity.Property(e => e.PayPolicyId).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PolicyName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PolicyNo)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PaySlip>(entity =>
            {
                entity.ToTable("PaySlip");

                entity.Property(e => e.PaySlipId).HasMaxLength(50);

                entity.Property(e => e.CalculationFormula)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FormulaId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LecturerId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PayPeriodId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PaySlipName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TotalEncrypt)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Formula)
                    .WithMany(p => p.PaySlips)
                    .HasForeignKey(d => d.FormulaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySlip_Formula");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.PaySlips)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySlip_Lecturer");

                entity.HasOne(d => d.PayPeriod)
                    .WithMany(p => p.PaySlips)
                    .HasForeignKey(d => d.PayPeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySlip_PayPeriod");
            });

            modelBuilder.Entity<PaySlipItem>(entity =>
            {
                entity.ToTable("PaySlipItem");

                entity.Property(e => e.PaySlipItemId).HasMaxLength(50);

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FormulaAttributeId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PaySlipId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PaySlipItemName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.QuantityEncrypt)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ValueEncrypt)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.FormulaAttribute)
                    .WithMany(p => p.PaySlipItems)
                    .HasForeignKey(d => d.FormulaAttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySlipItem_FormulaAttribute");

                entity.HasOne(d => d.PaySlip)
                    .WithMany(p => p.PaySlipItems)
                    .HasForeignKey(d => d.PaySlipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySlipItem_PaySlip");
            });

            modelBuilder.Entity<ProctoringSign>(entity =>
            {
                entity.ToTable("ProctoringSign");

                entity.Property(e => e.ProctoringSignId).HasMaxLength(50);

                entity.Property(e => e.LecturerId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeSlotId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.ProctoringSigns)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProctoringSign_Lecturer");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.ProctoringSigns)
                    .HasForeignKey(d => d.TimeSlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProctoringSign_TimeSlot");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasMaxLength(50);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<SalaryHistory>(entity =>
            {
                entity.ToTable("SalaryHistory");

                entity.Property(e => e.SalaryHistoryId).HasMaxLength(50);

                entity.Property(e => e.BasicSalaryId)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Fesalary).HasColumnName("FESalary");

                entity.Property(e => e.FesalaryId)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("FESalaryId");

                entity.Property(e => e.IsUsing).HasColumnName("isUsing");

                entity.Property(e => e.LecturerId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LecturerTypeId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.SalaryHistories)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalaryHistory_Lecturer");

                entity.HasOne(d => d.LecturerType)
                    .WithMany(p => p.SalaryHistories)
                    .HasForeignKey(d => d.LecturerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalaryHistory_LecturerType");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("School");

                entity.Property(e => e.SchoolId).HasMaxLength(50);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SchoolName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SchoolTypeId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.SchoolType)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.SchoolTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_School_SchoolType");
            });

            modelBuilder.Entity<SchoolType>(entity =>
            {
                entity.ToTable("SchoolType");

                entity.Property(e => e.SchoolTypeId).HasMaxLength(50);

                entity.Property(e => e.SchoolTypeName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.SemesterId).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.SemesterName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SemesterSchoolType>(entity =>
            {
                entity.ToTable("SemesterSchoolType");

                entity.Property(e => e.SemesterSchoolTypeId).HasMaxLength(50);

                entity.Property(e => e.SchoolTypeId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SemesterId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.SchoolType)
                    .WithMany(p => p.SemesterSchoolTypes)
                    .HasForeignKey(d => d.SchoolTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SemesterSchoolType_SchoolType");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.SemesterSchoolTypes)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SemesterSchoolType_Semester");
            });

            modelBuilder.Entity<TeachingSummary>(entity =>
            {
                entity.ToTable("TeachingSummary");

                entity.Property(e => e.TeachingSummaryId).HasMaxLength(50);

                entity.Property(e => e.PaySlipId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.PaySlip)
                    .WithMany(p => p.TeachingSummaries)
                    .HasForeignKey(d => d.PaySlipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeachingSummary_PaySlip");
            });

            modelBuilder.Entity<TeachingSummaryDetail>(entity =>
            {
                entity.ToTable("TeachingSummaryDetail");

                entity.Property(e => e.TeachingSummaryDetailId).HasMaxLength(50);

                entity.Property(e => e.Attendance)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Course)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Room)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Student)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TeachingSummaryId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.TeachingSummary)
                    .WithMany(p => p.TeachingSummaryDetails)
                    .HasForeignKey(d => d.TeachingSummaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeachingSummaryDetail_TeachingSummary");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.ToTable("TimeSlot");

                entity.Property(e => e.TimeSlotId).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
