using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
// Solo para design-time
#if NET9_0_OR_GREATER
#endif

namespace Gymmetry.Domain.Models;

public partial class GymmetryContext : DbContext
{
    public GymmetryContext()
    {
    }

    public GymmetryContext(DbContextOptions<GymmetryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessMethodType> AccessMethodTypes { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<CategoryExercise> CategoryExercises { get; set; }

    public virtual DbSet<Daily> Dailies { get; set; }

    public virtual DbSet<DailyExercise> DailyExercises { get; set; }

    public virtual DbSet<DailyExerciseHistory> DailyExerciseHistories { get; set; }

    public virtual DbSet<DailyHistory> DailyHistories { get; set; }

    public virtual DbSet<Diet> Diets { get; set; }

    public virtual DbSet<EmployeeRegisterDaily> EmployeeRegisterDailies { get; set; }

    public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }

    public virtual DbSet<EmployeeUser> EmployeeUsers { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<FitUser> FitUsers { get; set; }

    public virtual DbSet<Gym> Gyms { get; set; }

    public virtual DbSet<GymPlanSelected> GymPlanSelecteds { get; set; }

    public virtual DbSet<GymPlanSelectedModule> GymPlanSelectedModules { get; set; }

    public virtual DbSet<GymPlanSelectedType> GymPlanSelectedTypes { get; set; }

    public virtual DbSet<GymType> GymTypes { get; set; }

    public virtual DbSet<JourneyEmployee> JourneyEmployees { get; set; }

    public virtual DbSet<LogChange> LogChanges { get; set; }

    public virtual DbSet<LogError> LogErrors { get; set; }

    public virtual DbSet<LogLogin> LogLogins { get; set; }

    public virtual DbSet<LogUninstall> LogUninstalls { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<MachineCategory> MachineCategories { get; set; }

    public virtual DbSet<MachineCategoryType> MachineCategoryTypes { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationOption> NotificationOptions { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PhysicalAssessment> PhysicalAssessments { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<PlanType> PlanTypes { get; set; }

    public virtual DbSet<RoutineAssigned> RoutineAssigneds { get; set; }

    public virtual DbSet<RoutineExercise> RoutineExercises { get; set; }

    public virtual DbSet<RoutineTemplate> RoutineTemplates { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<SubModule> SubModules { get; set; }

    public virtual DbSet<UninstallOption> UninstallOptions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<UserOTP> UserOTPs { get; set; }

    public virtual DbSet<VerificationType> VerificationTypes { get; set; }

    public virtual DbSet<RoutineDay> RoutineDays { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Feed> Feeds { get; set; }

    public virtual DbSet<GymImage> GymImages { get; set; }

    public virtual DbSet<BranchService> BranchServices { get; set; }

    public virtual DbSet<BranchServiceType> BranchServiceTypes { get; set; }

    public virtual DbSet<CurrentOccupancy> CurrentOccupancies { get; set; }

    public virtual DbSet<BranchMedia> BranchMedias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessMethodType>(entity =>
        {
            entity.ToTable("AccessMethodType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.ToTable("Bill");

            entity.HasIndex(e => e.GymId, "IX_FK_BillGym");

            entity.HasIndex(e => e.UserId, "IX_FK_BillUser");

            entity.HasIndex(e => e.UserSellerId, "IX_FK_BillUser1");

            entity.HasIndex(e => e.UserTypeId, "IX_FK_BillUserType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Ammount).HasMaxLength(20);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Gym).WithMany(p => p.Bills)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillGym");

            entity.HasOne(d => d.User).WithMany(p => p.BillUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillUser");

            entity.HasOne(d => d.UserSeller).WithMany(p => p.BillUserSellers)
                .HasForeignKey(d => d.UserSellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillUser1");

            entity.HasOne(d => d.UserType).WithMany(p => p.Bills)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillUserType");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.ToTable("Branch");

            entity.HasIndex(e => e.AccessMethodId, "IX_FK_BranchAccessMethod");

            entity.HasIndex(e => e.GymId, "IX_FK_GymBranch");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(255);

            entity.HasOne(d => d.AccessMethod).WithMany(p => p.Branches)
                .HasForeignKey(d => d.AccessMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BranchAccessMethod");

            entity.HasOne(d => d.Gym).WithMany(p => p.Branches)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GymBranch");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CategoryExercise>(entity =>
        {
            entity.ToTable("CategoryExercise");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Daily>(entity =>
        {
            entity.ToTable("Daily");

            entity.HasIndex(e => e.RoutineExerciseId, "IX_FK_RoutineExerciseDaily");

            entity.HasIndex(e => e.UserId, "IX_FK_UserDaily");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.RoutineExercise).WithMany(p => p.Dailies)
                .HasForeignKey(d => d.RoutineExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoutineExerciseDaily");

            entity.HasOne(d => d.User).WithMany(p => p.Dailies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDaily");
        });

        modelBuilder.Entity<DailyExercise>(entity =>
        {
            entity.ToTable("DailyExercise");

            entity.HasIndex(e => e.DailyId, "IX_FK_DailyDailyExercise");

            entity.HasIndex(e => e.ExerciseId, "IX_FK_ExerciseDailyExercise");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Repetitions).HasMaxLength(10);
            entity.Property(e => e.Set).HasMaxLength(10);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Daily).WithMany(p => p.DailyExercises)
                .HasForeignKey(d => d.DailyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DailyDailyExercise");

            entity.HasOne(d => d.Exercise).WithMany(p => p.DailyExercises)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExerciseDailyExercise");
        });

        modelBuilder.Entity<DailyExerciseHistory>(entity =>
        {
            entity.ToTable("DailyExerciseHistory");

            entity.HasIndex(e => e.DailyHistoryId, "IX_FK_DailyHistoryDailyExerciseHistory");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Repetitions).HasMaxLength(10);
            entity.Property(e => e.Set).HasMaxLength(10);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.DailyHistory).WithMany(p => p.DailyExerciseHistories)
                .HasForeignKey(d => d.DailyHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DailyHistoryDailyExerciseHistory");
        });

        modelBuilder.Entity<DailyHistory>(entity =>
        {
            entity.ToTable("DailyHistory");

            entity.HasIndex(e => e.BranchId, "IX_FK_BranchDailyHistory");

            entity.HasIndex(e => e.RoutineExerciseId, "IX_FK_RoutineExerciseDailyHistory");

            entity.HasIndex(e => e.UserId, "IX_FK_UserDailyHistory");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Branch).WithMany(p => p.DailyHistories)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BranchDailyHistory");

            entity.HasOne(d => d.RoutineExercise).WithMany(p => p.DailyHistories)
                .HasForeignKey(d => d.RoutineExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoutineExerciseDailyHistory");

            entity.HasOne(d => d.User).WithMany(p => p.DailyHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDailyHistory");
        });

        modelBuilder.Entity<Diet>(entity =>
        {
            entity.ToTable("Diet");

            entity.HasIndex(e => e.UserId, "IX_FK_DietUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BreakFast).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Lunch).HasMaxLength(255);
            entity.Property(e => e.MidAfternoon).HasMaxLength(255);
            entity.Property(e => e.MidMorning).HasMaxLength(255);
            entity.Property(e => e.MidNight).HasMaxLength(255);
            entity.Property(e => e.Night).HasMaxLength(255);
            entity.Property(e => e.Observations).HasMaxLength(500);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Diets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DietUser");
        });

        modelBuilder.Entity<EmployeeRegisterDaily>(entity =>
        {
            entity.ToTable("EmployeeRegisterDaily");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeType>(entity =>
        {
            entity.ToTable("EmployeeType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeUser>(entity =>
        {
            entity.ToTable("EmployeeUser");

            entity.HasIndex(e => e.EmployeeTypeId, "IX_FK_EmployeeTypeEmployeeUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.AccountType).HasMaxLength(50);
            entity.Property(e => e.Arl)
                .HasMaxLength(100)
                .HasColumnName("ARL");
            entity.Property(e => e.BankId).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeType_Id");
            entity.Property(e => e.EndContract).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.PensionFund).HasMaxLength(100);
            entity.Property(e => e.Salary).HasMaxLength(20);
            entity.Property(e => e.StartContract).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.EmployeeType).WithMany(p => p.EmployeeUsers)
                .HasForeignKey(d => d.EmployeeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeTypeEmployeeUser");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.ToTable("Exercise");

            entity.HasIndex(e => e.CategoryExerciseId, "IX_FK_ExerciseDailyExerciseHistory");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.TagsObjectives).HasColumnType("nvarchar(max)");
            entity.Property(e => e.RequiresEquipment);
            entity.Property(e => e.UrlImage).HasMaxLength(255).IsRequired(false); // Nuevo campo
            entity.Property(e => e.Description).HasMaxLength(500).IsRequired(false); // Nueva propiedad
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.CategoryExercise).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.CategoryExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExerciseCategoryExercise");

            entity.HasOne(d => d.Machine)
                .WithMany(m => m.Exercises)
                .HasForeignKey(d => d.MachineId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_ExerciseMachine");
        });

        modelBuilder.Entity<FitUser>(entity =>
        {
            entity.ToTable("FitUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.ExperienceLevel).HasMaxLength(50);
            entity.Property(e => e.Goal).HasMaxLength(100);
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Gym>(entity =>
        {
            entity.ToTable("Gym");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .HasColumnName("NIT");
            entity.Property(e => e.FacbookUrl).HasMaxLength(255);
            entity.Property(e => e.InstagramUrl).HasMaxLength(255);
            entity.Property(e => e.Slogan).HasMaxLength(255);
            entity.Property(e => e.PaisId);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            // Nueva relación: Owner_UserId como FK a User
            entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(g => g.Owner_UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_GymOwnerUser");
        });

        modelBuilder.Entity<GymPlanSelected>(entity =>
        {
            entity.ToTable("GymPlanSelected");

            entity.HasIndex(e => e.GymPlanSelectedTypeId, "IX_FK_GymPlanSelectedTypeGymPlanSelected");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.GymPlanSelectedTypeId).HasColumnName("GymPlanSelectedTypeId");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.GymPlanSelectedType).WithMany(p => p.GymPlanSelecteds)
                .HasForeignKey(d => d.GymPlanSelectedTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GymPlanSelectedTypeGymPlanSelected");
        });

        modelBuilder.Entity<GymPlanSelectedModule>(entity =>
        {
            entity.ToTable("GymPlanSelectedModule");

            entity.HasIndex(e => e.GymPlanSelectedId, "IX_FK_GymPlanSelectedGymPlanSelectedModule");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.GymPlanSelected).WithMany(p => p.GymPlanSelectedModules)
                .HasForeignKey(d => d.GymPlanSelectedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GymPlanSelectedGymPlanSelectedModule");
        });

        modelBuilder.Entity<GymPlanSelectedType>(entity =>
        {
            entity.ToTable("GymPlanSelectedType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.CountryId).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.UsdPrice).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<GymType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IsActive).IsRequired();
            entity.HasMany(e => e.Gyms)
                  .WithOne(g => g.GymType)
                  .HasForeignKey(g => g.GymTypeId);
        });

        modelBuilder.Entity<JourneyEmployee>(entity =>
        {
            entity.ToTable("JourneyEmployee");

            entity.HasIndex(e => e.EmployeeUserId, "IX_FK_EmployeeUserJourneyEmployee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.EmployeeUserId).HasColumnName("EmployeeUser_Id");
            entity.Property(e => e.EndHour).HasMaxLength(10);
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.StartHour).HasMaxLength(10);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.EmployeeUser).WithMany(p => p.JourneyEmployees)
                .HasForeignKey(d => d.EmployeeUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeUserJourneyEmployee");
        });

        modelBuilder.Entity<LogChange>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_FK_UserLogChanges");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.PastObject).HasColumnType("nvarchar(max)");
            entity.Property(e => e.Table).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.LogChanges)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLogChanges");
        });

        modelBuilder.Entity<LogError>(entity =>
        {
            entity.HasIndex(e => e.SubModuleId, "IX_FK_SubModuleLogErrors");

            entity.HasIndex(e => e.UserId, "IX_FK_UserLogErrors");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Error).HasMaxLength(1000);
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.SubModule).WithMany(p => p.LogErrors)
                .HasForeignKey(d => d.SubModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubModuleLogErrors");

            entity.HasOne(d => d.User).WithMany(p => p.LogErrors)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLogErrors");
        });

        modelBuilder.Entity<LogLogin>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsSuccess);
            entity.Property(e => e.RefreshToken).HasMaxLength(255);
            entity.Property(e => e.RefreshTokenExpiration);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.IsActive);
            entity.Property(e => e.UserId);
            entity.HasOne(e => e.User)
                .WithMany(u => u.LogLogins)
                .HasForeignKey(e => e.UserId);
        });

        modelBuilder.Entity<LogUninstall>(entity =>
        {
            entity.ToTable("LogUninstall");

            entity.HasIndex(e => e.UnnistallOptionsId, "IX_FK_UnnistallOptionsLogUnnistall");

            entity.HasIndex(e => e.UserId, "IX_FK_UserUnnistallLog");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comments).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.UnnistallOptions).WithMany(p => p.LogUninstalls)
                .HasForeignKey(d => d.UnnistallOptionsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UnnistallOptionsLogUnnistall");

            entity.HasOne(d => d.User).WithMany(p => p.LogUninstalls)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserUnnistallLog");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.ToTable("Machine");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Observations).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");

            entity.HasMany(e => e.MachineCategories)
                .WithOne(e => e.Machine)
                .HasForeignKey(e => e.MachineId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<MachineCategory>(entity =>
        {
            entity.ToTable("MachineCategory");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");

            entity.HasOne(e => e.MachineCategoryType)
                .WithMany(e => e.MachineCategories)
                .HasForeignKey(e => e.MachineCategoryTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<MachineCategoryType>(entity =>
        {
            entity.ToTable("MachineCategoryType");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.ToTable("Module");

            entity.HasIndex(e => e.GymPlanSelectedModuleModuleModuleId, "IX_FK_GymPlanSelectedModuleModule");

            entity.HasIndex(e => e.UserTypeId, "IX_FK_UserTypeModule");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.GymPlanSelectedModuleModuleModuleId).HasColumnName("GymPlanSelectedModuleModule_ModuleId");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("URL");

            entity.HasOne(d => d.GymPlanSelectedModuleModuleModule).WithMany(p => p.Modules)
                .HasForeignKey(d => d.GymPlanSelectedModuleModuleModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GymPlanSelectedModuleModule");

            entity.HasOne(d => d.UserType).WithMany(p => p.Modules)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTypeModule");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.HasIndex(e => e.UserId, "IX_FK_UserNotification");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Body).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Option1).HasMaxLength(100);
            entity.Property(e => e.Option2).HasMaxLength(100);
            entity.Property(e => e.ShowDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Urloption1)
                .HasMaxLength(255)
                .HasColumnName("URLOption1");
            entity.Property(e => e.Urloption2)
                .HasMaxLength(255)
                .HasColumnName("URLOption2");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserNotification");
        });

        modelBuilder.Entity<NotificationOption>(entity =>
        {
            entity.ToTable("NotificationOption");

            entity.HasIndex(e => e.NotificationOptionNotificationNotificationOptionId, "IX_FK_NotificationOptionNotification");

            entity.HasIndex(e => e.UserId, "IX_FK_UserNotificationOption");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.App).HasMaxLength(10);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Mail).HasMaxLength(10);
            entity.Property(e => e.NotificationOptionNotificationNotificationOptionId).HasColumnName("NotificationOptionNotification_NotificationOptionId");
            entity.Property(e => e.Push).HasMaxLength(10);
            entity.Property(e => e.Sms)
                .HasMaxLength(10)
                .HasColumnName("SMS");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.WhatsaApp).HasMaxLength(10);

            entity.HasOne(d => d.NotificationOptionNotificationNotificationOption).WithMany(p => p.NotificationOptions)
                .HasForeignKey(d => d.NotificationOptionNotificationNotificationOptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationOptionNotification");

            entity.HasOne(d => d.User).WithMany(p => p.NotificationOptions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserNotificationOption");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_FK_UserPermissions");

            entity.HasIndex(e => e.UserTypeId, "IX_FK_UserTypePermissions");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Create).HasMaxLength(10);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Delete).HasMaxLength(10);
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Read).HasMaxLength(10);
            entity.Property(e => e.See).HasMaxLength(10);
            entity.Property(e => e.Update).HasMaxLength(10);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPermissions");

            entity.HasOne(d => d.UserType).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTypePermissions");
        });

        modelBuilder.Entity<PhysicalAssessment>(entity =>
        {
            entity.ToTable("PhysicalAssessment");

            entity.HasIndex(e => e.UserId, "IX_FK_UserPhysicalAssessment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Abdomen).HasMaxLength(10);
            entity.Property(e => e.Bmi)
                .HasMaxLength(10)
                .HasColumnName("BMI");
            entity.Property(e => e.BodyFatPercentage).HasMaxLength(10);
            entity.Property(e => e.Chest).HasMaxLength(10);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Height).HasMaxLength(10);
            entity.Property(e => e.Hips).HasMaxLength(10);
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.LeftArm).HasMaxLength(10);
            entity.Property(e => e.LeftCalf).HasMaxLength(10);
            entity.Property(e => e.LeftForearm).HasMaxLength(10);
            entity.Property(e => e.LeftThigh).HasMaxLength(10);
            entity.Property(e => e.LowerBack).HasMaxLength(10);
            entity.Property(e => e.MuscleMass).HasMaxLength(10);
            entity.Property(e => e.Neck).HasMaxLength(10);
            entity.Property(e => e.RighArm).HasMaxLength(10);
            entity.Property(e => e.RightCalf).HasMaxLength(10);
            entity.Property(e => e.RightForearm).HasMaxLength(10);
            entity.Property(e => e.RightThigh).HasMaxLength(10);
            entity.Property(e => e.Shoulders).HasMaxLength(10);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpperBack).HasMaxLength(10);
            entity.Property(e => e.Waist).HasMaxLength(10);
            entity.Property(e => e.Weight).HasMaxLength(10);
            entity.Property(e => e.Wrist).HasMaxLength(10);

            entity.HasOne(d => d.User).WithMany(p => p.PhysicalAssessments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPhysicalAssessment");
        });

        modelBuilder.Entity<Plan>(entity =>
        {
            entity.ToTable("Plan");

            entity.HasIndex(e => e.GymId, "IX_FK_GymPlan");

            entity.HasIndex(e => e.PlanTypeId, "IX_FK_PlanTypePlan");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Gym).WithMany(p => p.Plans)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GymPlan");

            entity.HasOne(d => d.PlanType).WithMany(p => p.Plans)
                .HasForeignKey(d => d.PlanTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanTypePlan");
        });

        modelBuilder.Entity<PlanType>(entity =>
        {
            entity.ToTable("PlanType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<RoutineAssigned>(entity =>
        {
            entity.ToTable("RoutineAssigned");

            entity.HasIndex(e => e.UserId, "IX_FK_UserRoutineAssigned");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comments).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.RoutineAssigneds)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoutineAssigned");
        });

        modelBuilder.Entity<RoutineExercise>(entity =>
        {
            entity.ToTable("RoutineExercise");

            entity.HasIndex(e => e.ExerciseId, "IX_FK_ExerciseRoutineExercise");

            entity.HasIndex(e => e.RoutineTemplateId, "IX_FK_RoutineRoutineExercise");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Repetitions).HasMaxLength(10);
            entity.Property(e => e.Sets).HasMaxLength(10);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Exercise).WithMany(p => p.RoutineExercises)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExerciseRoutineExercise");

            entity.HasOne(d => d.RoutineTemplate).WithMany(p => p.RoutineExercises)
                .HasForeignKey(d => d.RoutineTemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoutineRoutineExercise");
        });

        modelBuilder.Entity<RoutineTemplate>(entity =>
        {
            entity.ToTable("RoutineTemplate");

            entity.HasIndex(e => e.GymId, "IX_FK_GymRoutine");

            entity.HasIndex(e => e.RoutineAssignedId, "IX_FK_RoutineAssignedRoutine");

            entity.HasIndex(e => e.RoutineUserRoutineId, "IX_FK_RoutineUser");
            // Nueva relación: Author_UserId como FK a User
            entity.HasIndex(e => e.Author_UserId, "IX_FK_AuthorUserRoutineTemplate");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comments).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RoutineUserRoutineId).HasColumnName("RoutineUser_RoutineId").IsRequired(false);
            entity.Property(e => e.GymId).IsRequired(false);
            entity.Property(e => e.RoutineAssignedId).IsRequired(false);
            entity.Property(e => e.Author_UserId).IsRequired(false);
            entity.Property(e => e.TagsObjectives).HasColumnType("nvarchar(max)");
            entity.Property(e => e.TagsMachines).HasColumnType("nvarchar(max)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Gym).WithMany(p => p.RoutineTemplates)
                .HasForeignKey(d => d.GymId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GymRoutine");

            entity.HasOne(d => d.RoutineAssigned).WithMany(p => p.RoutineTemplates)
                .HasForeignKey(d => d.RoutineAssignedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoutineAssignedRoutine");

            entity.HasOne(d => d.RoutineUserRoutine).WithMany(p => p.RoutineTemplates)
                .HasForeignKey(d => d.RoutineUserRoutineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoutineUser");

            // Relación Author_UserId -> User.Id
            entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(d => d.Author_UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_AuthorUserRoutineTemplate");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.ToTable("Schedule");

            entity.HasIndex(e => e.BranchId, "IX_FK_BranchSchedule");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Branch).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BranchSchedule");
        });

        modelBuilder.Entity<SubModule>(entity =>
        {
            entity.ToTable("SubModule");

            entity.HasIndex(e => e.BranchId, "IX_FK_BranchSubModule");

            entity.HasIndex(e => e.ModuleId, "IX_FK_ModuleSubModule");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Branch).WithMany(p => p.SubModules)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BranchSubModule");

            entity.HasOne(d => d.Module).WithMany(p => p.SubModules)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ModuleSubModule");
        });

        modelBuilder.Entity<UninstallOption>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.EmployeeRegisterDailyUserUserId, "IX_FK_EmployeeRegisterDailyUser");

            entity.HasIndex(e => e.ScheduleUserUserId, "IX_FK_ScheduleUser");
            entity.HasIndex(e => e.UserDietUserId, "IX_FK_UserDiet");
            entity.HasIndex(e => e.UserEmployeeUserUserId, "IX_FK_UserEmployeeUser");
            entity.HasIndex(e => e.UserFitUserUserId, "IX_FK_UserFitUser");
            entity.HasIndex(e => e.PlanId, "IX_FK_UserPlan");
            entity.HasIndex(e => e.UserTypeId, "IX_FK_UserUserType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            // entity.Property(e => e.DocumentType).HasMaxLength(50); // Eliminado
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.EmergencyName).HasMaxLength(100);
            entity.Property(e => e.EmergencyPhone).HasMaxLength(20);
            entity.Property(e => e.EmployeeRegisterDailyUserUserId).HasColumnName("EmployeeRegisterDailyUser_UserId");
            entity.Property(e => e.IdEps)
                .HasMaxLength(50)
                .HasColumnName("IdEPS");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PhysicalExceptionsNotes).HasMaxLength(500);
            entity.Property(e => e.ProfileImageUrl).HasMaxLength(255);
            entity.Property(e => e.Rh)
                .HasMaxLength(5)
                .HasColumnName("RH");
            entity.Property(e => e.ScheduleUserUserId).HasColumnName("ScheduleUser_UserId");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserDietUserId).HasColumnName("UserDiet_UserId");
            entity.Property(e => e.UserEmployeeUserUserId).HasColumnName("UserEmployeeUser_UserId");
            entity.Property(e => e.UserFitUserUserId).HasColumnName("UserFitUser_UserId");
            // entity.Property(e => e.GymUserId).HasColumnName("GymUser_Id"); // Eliminado
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.EmployeeRegisterDailyUserUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeRegisterDailyUserUserId)
                .HasConstraintName("FK_EmployeeRegisterDailyUser");

            entity.HasOne(d => d.Plan).WithMany(p => p.Users)
                .HasForeignKey(d => d.PlanId)
                .HasConstraintName("FK_UserPlan");

            entity.HasOne(d => d.ScheduleUserUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.ScheduleUserUserId)
                .HasConstraintName("FK_ScheduleUser");

            entity.HasOne(d => d.UserDietUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserDietUserId)
                .HasConstraintName("FK_UserDiet");

            entity.HasOne(d => d.UserEmployeeUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserEmployeeUserUserId)
                .HasConstraintName("FK_UserEmployeeUser");

            entity.HasOne(d => d.UserFitUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserFitUserUserId)
                .HasConstraintName("FK_UserFitUser");

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserUserType");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.ToTable("UserType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserOTP>(entity =>
        {
            entity.ToTable("UserOTP");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OTP).IsRequired();
            entity.Property(e => e.Method).HasMaxLength(100);
            entity.Property(e => e.IsVerified).IsRequired();
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.IsActive);
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UserOTP_User");
            entity.HasOne(e => e.VerificationType)
                .WithMany()
                .HasForeignKey(e => e.VerificationTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UserOTP_VerificationType");
        });

        modelBuilder.Entity<VerificationType>(entity =>
        {
            entity.ToTable("VerificationType");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.IsActive);


        });

        modelBuilder.Entity<RoutineDay>(entity =>
        {
            entity.ToTable("RoutineDay");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Repetitions).HasMaxLength(20).IsRequired();
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.HasOne(e => e.RoutineTemplate)
                .WithMany(r => r.RoutineDays)
                .HasForeignKey(e => e.RoutineTemplateId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Exercise)
                .WithMany(e => e.RoutineDays)
                .HasForeignKey(e => e.ExerciseId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Content).HasMaxLength(2000);
            entity.Property(e => e.MediaUrl).HasMaxLength(500);
            entity.Property(e => e.MediaType).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(e => e.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PostUser");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Content).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.HasOne(e => e.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CommentPost");
            entity.HasOne(e => e.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CommentUser");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.ToTable("Like");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.HasOne(e => e.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_LikePost");
            entity.HasOne(e => e.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_LikeUser");
        });

        modelBuilder.Entity<Feed>(entity =>
        {
            entity.ToTable("Feed");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.MediaUrl).HasMaxLength(500);
            entity.Property(e => e.MediaType).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_FeedUser");
        });

        modelBuilder.Entity<GymImage>(entity =>
        {
            entity.ToTable("GymImage");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Url).HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.Property(e => e.IsActive);
            entity.Property(e => e.GymId);
            entity.Property(e => e.BranchId);
        });

        modelBuilder.Entity<BranchService>(entity =>
        {
            entity.ToTable("BranchService");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.HasOne(e => e.Branch)
                .WithMany()
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.BranchServiceType)
                .WithMany(t => t.BranchServices)
                .HasForeignKey(e => e.BranchServiceTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<BranchServiceType>(entity =>
        {
            entity.ToTable("BranchServiceType");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
        });

        modelBuilder.Entity<CurrentOccupancy>(entity =>
        {
            entity.ToTable("CurrentOccupancy");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Occupancy);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.HasOne(e => e.Branch)
                .WithMany()
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<BranchMedia>(entity =>
        {
            entity.ToTable("BranchMedia");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Url).HasMaxLength(500);
            entity.Property(e => e.MediaType).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Ip).HasMaxLength(45);
            entity.HasOne(e => e.Branch)
                .WithMany()
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

public class GymmetryContextFactory : IDesignTimeDbContextFactory<GymmetryContext>
{
    public GymmetryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<GymmetryContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);

        return new GymmetryContext(optionsBuilder.Options);
    }
}