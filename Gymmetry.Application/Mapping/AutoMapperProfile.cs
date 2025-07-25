using AutoMapper;
using Gymmetry.Domain.DTO.AccessMethodType.Request;
using Gymmetry.Domain.DTO.Bill.Request;
using Gymmetry.Domain.DTO.Branch.Request;
using Gymmetry.Domain.DTO.Brand.Request;
using Gymmetry.Domain.DTO.Exercise.Request;
using Gymmetry.Domain.DTO.FitUser.Request;
using Gymmetry.Domain.DTO.Gym.Request;
using Gymmetry.Domain.DTO.GymPlanSelected.Request;
using Gymmetry.Domain.DTO.Notification.Request;
using Gymmetry.Domain.DTO.RoutineExercise.Request;
using Gymmetry.Domain.Models;

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