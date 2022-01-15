using System;
using AutoMapper;
using Tasks.Application.Common.Mappings;
using Tasks.Domain.Entities;

namespace Tasks.Application.MyTasks.Queries.GetMyTaskDetails
{
    public class MyTaskDetailsVm : IMapWith<MyTask>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MyTask, MyTaskDetailsVm>()
                .ForMember(Vm => Vm.Title,
                    opt => opt.MapFrom(mT => mT.Title))
                .ForMember(noteVm => noteVm.Details,
                    opt => opt.MapFrom(note => note.Details))
                .ForMember(noteVm => noteVm.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.CreationDate,
                    opt => opt.MapFrom(note => note.CreationDate))
                .ForMember(noteVm => noteVm.EditDate,
                    opt => opt.MapFrom(note => note.EditDate));

        }
    }
}
