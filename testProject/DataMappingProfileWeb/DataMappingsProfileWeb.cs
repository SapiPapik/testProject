using AutoMapper;
using TestProject.BLL.DataModels;
using TestProject.Web.Models;

namespace testProject.DataMappingProfileWeb
{
    public class DataMappingsProfileWeb : Profile
    {
        public DataMappingsProfileWeb()
        {
            CreateMap<GroupDataModel, GroupViewModel>().ReverseMap();

            CreateMap<StudentDataModel, StudentViewModel>().ReverseMap();

            CreateMap<CuratorDataModel, CuratorViewModel>().ReverseMap();
        }
    }
}