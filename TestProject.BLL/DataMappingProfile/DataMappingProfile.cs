using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestProject.BLL.DataModels;
using TestProject.Data.Entity;

namespace TestProject.BLL.DataMappingProfile
{
    public class DataMappingsProfile : Profile
    {

        public DataMappingsProfile()
        {
            CreateMap<Group, GroupDataModel>().ReverseMap();

            CreateMap<Student, StudentDataModel>().ReverseMap();

            CreateMap<Curator, CuratorDataModel>().ReverseMap();
        }
    }
}
