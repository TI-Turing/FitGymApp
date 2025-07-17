using System;
using System.Collections.Generic;

namespace FitGymApp.Domain.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Guid? IdEps { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public Guid? IdGender { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? ProfileImageUrl { get; set; }

    public Guid? DocumentTypeId { get; set; }

    public string? DocumentType { get; set; }

    public string? Phone { get; set; }

    public Guid? CountryId { get; set; }

    public string? Address { get; set; }

    public Guid? CityId { get; set; }

    public Guid? RegionId { get; set; }

    public string? Rh { get; set; }

    public string? EmergencyName { get; set; }

    public string? EmergencyPhone { get; set; }

    public string? PhysicalExceptions { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Ip { get; set; }

    public bool? IsActive { get; set; }

    public Guid? UserTypeId { get; set; }

    public Guid? PlanId { get; set; }

    public Guid? UserFitUserUserId { get; set; }

    public Guid? UserDietUserId { get; set; }

    public Guid? GymUserId { get; set; }

    public Guid? EmployeeRegisterDailyUserUserId { get; set; }

    public Guid? ScheduleUserUserId { get; set; }

    public Guid? UserEmployeeUserUserId { get; set; }

    public Guid? GymId { get; set; }

    public virtual ICollection<Bill> BillUserSellers { get; set; } = new List<Bill>();

    public virtual ICollection<Bill> BillUsers { get; set; } = new List<Bill>();

    public virtual ICollection<Daily> Dailies { get; set; } = new List<Daily>();

    public virtual ICollection<DailyHistory> DailyHistories { get; set; } = new List<DailyHistory>();

    public virtual ICollection<Diet> Diets { get; set; } = new List<Diet>();

    public virtual EmployeeRegisterDaily? EmployeeRegisterDailyUserUser { get; set; }

    public virtual Gym? Gym { get; set; }

    public virtual ICollection<LogChange> LogChanges { get; set; } = new List<LogChange>();

    public virtual ICollection<LogError> LogErrors { get; set; } = new List<LogError>();

    public virtual ICollection<LogLogin> LogLogins { get; set; } = new List<LogLogin>();

    public virtual ICollection<LogUninstall> LogUninstalls { get; set; } = new List<LogUninstall>();

    public virtual ICollection<NotificationOption> NotificationOptions { get; set; } = new List<NotificationOption>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public virtual ICollection<PhysicalAssessment> PhysicalAssessments { get; set; } = new List<PhysicalAssessment>();

    public virtual Plan? Plan { get; set; }

    public virtual ICollection<RoutineAssigned> RoutineAssigneds { get; set; } = new List<RoutineAssigned>();

    public virtual ICollection<RoutineTemplate> RoutineTemplates { get; set; } = new List<RoutineTemplate>();

    public virtual Schedule? ScheduleUserUser { get; set; }

    public virtual Diet? UserDietUser { get; set; }

    public virtual EmployeeUser? UserEmployeeUserUser { get; set; }

    public virtual FitUser? UserFitUserUser { get; set; }

    public virtual Gym? GymUser { get; set; }

    public virtual UserType? UserType { get; set; }
}
