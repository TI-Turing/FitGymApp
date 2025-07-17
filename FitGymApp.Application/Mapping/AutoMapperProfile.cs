using AutoMapper;
using FitGymApp.Domain.DTO.AccessMethodType.Request;
using FitGymApp.Domain.DTO.Bill.Request;
using FitGymApp.Domain.DTO.Branch.Request;
using FitGymApp.Domain.DTO.Brand.Request;
using FitGymApp.Domain.DTO.Exercise.Request;
using FitGymApp.Domain.DTO.FitUser.Request;
using FitGymApp.Domain.DTO.Gym.Request;
using FitGymApp.Domain.DTO.GymPlanSelected.Request;
using FitGymApp.Domain.DTO.Notification.Request;
using FitGymApp.Domain.DTO.RoutineExercise.Request;
using FitGymApp.Domain.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddRoutineExerciseRequest, RoutineExercise>();
        CreateMap<UpdateRoutineExerciseRequest, RoutineExercise>();
        CreateMap<AddFitUserRequest, FitUser>()
            .ForMember(dest => dest.Goal, opt => opt.MapFrom(src => src.Goal))
            .ForMember(dest => dest.ExperienceLevel, opt => opt.MapFrom(src => src.ExperienceLevel));
        CreateMap<UpdateFitUserRequest, FitUser>()
            .ForMember(dest => dest.Goal, opt => opt.MapFrom(src => src.Goal))
            .ForMember(dest => dest.ExperienceLevel, opt => opt.MapFrom(src => src.ExperienceLevel));
        CreateMap<AddExerciseRequest, Exercise>();
        CreateMap<UpdateExerciseRequest, Exercise>();
        CreateMap<AddAccessMethodTypeRequest, AccessMethodType>();
        CreateMap<UpdateAccessMethodTypeRequest, AccessMethodType>();
        CreateMap<AddBillRequest, Bill>();
        CreateMap<UpdateBillRequest, Bill>();
        CreateMap<AddBranchRequest, Branch>();
        CreateMap<UpdateBranchRequest, Branch>();
        CreateMap<AddBrandRequest, Brand>();
        CreateMap<UpdateBrandRequest, Brand>();
        CreateMap<AddNotificationRequest, Notification>();
        CreateMap<UpdateNotificationRequest, Notification>();
        CreateMap<AddGymRequest, Gym>();
        CreateMap<UpdateGymRequest, Gym>();
        CreateMap<AddGymPlanSelectedRequest, GymPlanSelected>();

    }
}