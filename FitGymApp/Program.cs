using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Gymmetry.Domain.Models;
using Gymmetry.Application.Services;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Repository.Services;
using Gymmetry.Repository.Services.Interfaces;
using Gymmetry.Repository.Persistence.Seed;
 
var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

// Configuración de cadena de conexión
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection")
    ?? configuration["ConnectionStrings:DefaultConnection"]
    ?? configuration["ConnectionStrings:Gymmetry"];

// Registrar DbContext
builder.Services.AddDbContext<GymmetryContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<AutoMapperProfile>();
});

// Inyección de dependencias de repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ILogErrorRepository, LogErrorRepository>();
builder.Services.AddScoped<ILogLoginRepository, LogLoginRepository>();
builder.Services.AddScoped<ILogChangeRepository, LogChangeRepository>();
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryExerciseRepository, CategoryExerciseRepository>();
builder.Services.AddScoped<IConfigAutoRepository, ConfigAutoRepository>();
builder.Services.AddScoped<IDailyExerciseHistoryRepository, DailyExerciseHistoryRepository>();
builder.Services.AddScoped<IDailyExerciseRepository, DailyExerciseRepository>();
builder.Services.AddScoped<IDailyHistoryRepository, DailyHistoryRepository>();
builder.Services.AddScoped<IDailyRepository, DailyRepository>();
builder.Services.AddScoped<IDietRepository, DietRepository>();
builder.Services.AddScoped<IEmployeeRegisterDailyRepository, EmployeeRegisterDailyRepository>();
builder.Services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
builder.Services.AddScoped<IEmployeeUserRepository, EmployeeUserRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IFitUserRepository, FitUserRepository>();
builder.Services.AddScoped<IGymPlanSelectedModuleRepository, GymPlanSelectedModuleRepository>();
builder.Services.AddScoped<IGymPlanSelectedRepository, GymPlanSelectedRepository>();
builder.Services.AddScoped<IGymPlanSelectedTypeRepository, GymPlanSelectedTypeRepository>();
builder.Services.AddScoped<IGymRepository, GymRepository>();
builder.Services.AddScoped<IGymTypeRepository, GymTypeRepository>();
builder.Services.AddScoped<IJourneyEmployeeRepository, JourneyEmployeeRepository>();
builder.Services.AddScoped<ILogUninstallRepository, LogUninstallRepository>();
builder.Services.AddScoped<IMachineCategoryRepository, MachineCategoryRepository>();
builder.Services.AddScoped<IMachineRepository, MachineRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<INotificationOptionRepository, NotificationOptionRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IUserOtpRepository, UserOtpRepository>();
builder.Services.AddScoped<IPhysicalAssessmentRepository, PhysicalAssessmentRepository>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPlanTypeRepository, PlanTypeRepository>();
builder.Services.AddScoped<IRoutineAssignedRepository, RoutineAssignedRepository>();
builder.Services.AddScoped<IRoutineDayRepository, RoutineDayRepository>();
builder.Services.AddScoped<IRoutineExerciseRepository, RoutineExerciseRepository>();
builder.Services.AddScoped<IRoutineTemplateRepository, RoutineTemplateRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<ISubModuleRepository, SubModuleRepository>();
builder.Services.AddScoped<IUninstallOptionRepository, UninstallOptionRepository>();
builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
builder.Services.AddScoped<IVerificationTypeRepository, VerificationTypeRepository>();
builder.Services.AddScoped<IUserOtpRepository, UserOtpRepository>();

// Inyección de dependencias de servicios de aplicación
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IConfigAutoService, ConfigAutoService>();
builder.Services.AddScoped<ILogErrorService, LogErrorService>();
builder.Services.AddScoped<ILogLoginService, LogLoginService>();
builder.Services.AddScoped<ILogChangeService, LogChangeService>();
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICategoryExerciseService, CategoryExerciseService>();
builder.Services.AddScoped<IDailyExerciseHistoryService, DailyExerciseHistoryService>();
builder.Services.AddScoped<IDailyExerciseService, DailyExerciseService>();
builder.Services.AddScoped<IDailyHistoryService, DailyHistoryService>();
builder.Services.AddScoped<IDailyService, DailyService>();
builder.Services.AddScoped<IDietService, DietService>();
builder.Services.AddScoped<IEmployeeRegisterDailyService, EmployeeRegisterDailyService>();
builder.Services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();
builder.Services.AddScoped<IEmployeeUserService, EmployeeUserService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IFitUserService, FitUserService>();
builder.Services.AddScoped<IGymPlanSelectedModuleService, GymPlanSelectedModuleService>();
builder.Services.AddScoped<IGymPlanSelectedService, GymPlanSelectedService>();
builder.Services.AddScoped<IGymPlanSelectedTypeService, GymPlanSelectedTypeService>();
builder.Services.AddScoped<IGymService, GymService>();
builder.Services.AddScoped<IGymTypeService, GymTypeService>();
builder.Services.AddScoped<IJourneyEmployeeService, JourneyEmployeeService>();
builder.Services.AddScoped<ILogUninstallService, LogUninstallService>();
builder.Services.AddScoped<IMachineCategoryService, MachineCategoryService>();
builder.Services.AddScoped<IMachineService, MachineService>();
builder.Services.AddScoped<IModuleService, ModuleService>();
builder.Services.AddScoped<INotificationOptionService, NotificationOptionService>();
builder.Services.AddScoped<IUserOtpService, UserOtpService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IPhysicalAssessmentService, PhysicalAssessmentService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IPlanTypeService, PlanTypeService>();
builder.Services.AddScoped<IRoutineAssignedService, RoutineAssignedService>();
builder.Services.AddScoped<IRoutineDayService, RoutineDayService>();
builder.Services.AddScoped<IRoutineExerciseService, RoutineExerciseService>();
builder.Services.AddScoped<IRoutineTemplateService, RoutineTemplateService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ISubModuleService, SubModuleService>();
builder.Services.AddScoped<IUninstallOptionService, UninstallOptionService>();
builder.Services.AddScoped<IUserTypeService, UserTypeService>();
builder.Services.AddScoped<IVerificationTypeService, VerificationTypeService>();
builder.Services.AddHttpClient<Gymmetry.Application.Services.ConfigAutoService>();
builder.Services.AddSingleton<Microsoft.Extensions.Configuration.IConfiguration>(builder.Configuration);

// Aplicar migraciones y ejecutar seeds (opcional, solo en desarrollo o si es seguro)
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GymmetryContext>();
    db.Database.Migrate(); // Aplica migraciones pendientes
    DbInitializer.SeedAsync(db).GetAwaiter().GetResult(); // Llamar al inicializador de seeds de repository

    // Ejecutar funciones de ConfigFunction
    var configAutoService = scope.ServiceProvider.GetRequiredService<IConfigAutoService>();
    configAutoService.UpdateUsdPricesFromExchangeAsync().GetAwaiter().GetResult();
}

builder.Build().Run();
