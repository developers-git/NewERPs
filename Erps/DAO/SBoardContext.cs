
using Erps.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TrackerEnabledDbContext.Identity;


namespace Erps.DAO
{
    public class SBoardContext : TrackerIdentityContext<ApplicationUser>
    {
        public SBoardContext()
            : base("SBoardConnection")
        { }


        public virtual DbSet<Activation> Activations { get; set; }
        public virtual DbSet<AdvanceEntry> AdvanceEntries { get; set; }
        public virtual DbSet<BusCardHolder_Staff> BusCardHolder_Staff { get; set; }
        public virtual DbSet<BusCardHolder_Student> BusCardHolder_Student { get; set; }
        public virtual DbSet<BusFeePayment_Staff> BusFeePayment_Staff { get; set; }
        public virtual DbSet<BusFeePayment_Student> BusFeePayment_Student { get; set; }
        public virtual DbSet<BusInfo> BusInfoes { get; set; }
        public virtual DbSet<Cards_Staff> Cards_Staff { get; set; }
        public virtual DbSet<Cards_Student> Cards_Student { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassType> ClassTypes { get; set; }
        public virtual DbSet<CourseFee> CourseFees { get; set; }
        public virtual DbSet<CourseFeePayment> CourseFeePayments { get; set; }
        public virtual DbSet<CourseFeePayment_Join> CourseFeePayment_Join { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<FeeBalance> FeeBalances { get; set; }
        public virtual DbSet<glyphicon> glyphicons { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Hosteler> Hostelers { get; set; }
        public virtual DbSet<HostelFeePayment> HostelFeePayments { get; set; }
        public virtual DbSet<HostelInfo> HostelInfoes { get; set; }
        public virtual DbSet<Installment_Bus> Installment_Bus { get; set; }
        public virtual DbSet<Installment_Hostel> Installment_Hostel { get; set; }
        public virtual DbSet<Interbank> Interbanks { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<qryFaculty> qryFaculties { get; set; }
        public virtual DbSet<qrySection> qrySections { get; set; }
        public virtual DbSet<qrySectionAdvisory> qrySectionAdvisories { get; set; }
        public virtual DbSet<qrySubjectOfferring> qrySubjectOfferrings { get; set; }
        public virtual DbSet<qrySubject> qrySubjects { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<SchoolInfo> SchoolInfoes { get; set; }
        public virtual DbSet<SchoolType> SchoolTypes { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Session_Master> Session_Master { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Staff_Department> Staff_Department { get; set; }
        public virtual DbSet<StaffAttendance> StaffAttendances { get; set; }
        public virtual DbSet<StaffPayment> StaffPayments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentDocSubmitted> StudentDocSubmitteds { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_books> tbl_books { get; set; }
        public virtual DbSet<tbl_borrowedBooks> tbl_borrowedBooks { get; set; }
        public virtual DbSet<tbl_marks> tbl_marks { get; set; }
        public virtual DbSet<tbl_positions> tbl_positions { get; set; }
        public virtual DbSet<tbl_subjects> tbl_subjects { get; set; }
        public virtual DbSet<tblDepartment> tblDepartments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Voucher_OtherDetails> Voucher_OtherDetails { get; set; }
        public virtual DbSet<WebServiceAPI> WebServiceAPIs { get; set; }
        public virtual DbSet<Discount_Staff> Discount_Staff { get; set; }
        public virtual DbSet<NoDues_Staff> NoDues_Staff { get; set; }
        public virtual DbSet<NoDues_Student> NoDues_Student { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            Database.SetInitializer<SBoardContext>(null);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m =>
                {
                    m.ToTable("UserRoles");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });
            //modelBuilder.Entity<TradingPlatform>()
            //      .HasRequired(e => e.TradingBoards)
            //      .WithMany(d => d.TradingPlatforms);
            base.OnModelCreating(modelBuilder);
        }
       

    }



}