using AutoMapper;
using testProject.Models;
using TestProject.BLL.Contracts.Dtos;

namespace testProject.DataMappingProfileWeb {
    public class DataMappingsProfileWeb : Profile {
        public DataMappingsProfileWeb() {
            CreateMap<GroupDto, GroupViewModel>()
                .ForMember(g => g.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(g => g.Аbbreviation, opt => opt.MapFrom(src => src.Аbbreviation))
                .ForMember(g => g.CuratorId, opt => opt.MapFrom(src => src.CuratorId))
                .ForMember(g => g.Curator, opt => opt.MapFrom(src => src.Curator))
                .ForMember(g => g.Students, opt => opt.MapFrom(src => src.Students))
                .ReverseMap()
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<StudentDto, StudentViewModel>()
                .ForMember(s => s.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(s => s.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(s => s.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(s => s.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(s => s.Birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(s => s.IsStependint, opt => opt.MapFrom(src => src.IsStependint))
                .ForMember(s => s.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ReverseMap()
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<CuratorDto, CuratorViewModel>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(c => c.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(c => c.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(c => c.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ReverseMap()
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}