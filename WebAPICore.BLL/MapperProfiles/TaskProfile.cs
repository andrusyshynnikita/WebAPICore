using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPICore.Common.DBModels;
using WebAPICore.Common.ViewModels;

namespace WebAPICore.BLL.MapperProfiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<DBTask, TaskViewModel>().ForMember(m => m.AudioFileContent, vm => vm.Ignore());

            CreateMap<TaskViewModel, DBTask>();
        }
    }
}
