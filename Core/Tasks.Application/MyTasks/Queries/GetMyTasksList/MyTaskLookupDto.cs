using System;
using AutoMapper;
using Tasks.Application.Common.Mappings;
using Tasks.Domain.Entities;

namespace Tasks.Application.MyTasks.Queries.GetMyTasksList
{
    public class MyTaskLookupDto : IMapWith<MyTask>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MyTask, MyTaskLookupDto>()
                .ForMember(mtDTO => mtDTO.Id,
                    opt => opt.MapFrom(mT => mT.Id))
                .ForMember(noteDto => noteDto.Title,
                    opt => opt.MapFrom(note => note.Title));

        }
    }
}
