using System;
using AutoMapper;
using Tasks.Application.Common.Mappings;
using Tasks.Application.MyTasks.Comands.UpdateMyTask;
using Tasks.Domain.Entities;

namespace Tasks.Api.Models
{
    public class UpdateMyTaskDto : IMapWith<MyTask>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMyTaskDto, UpdateMyTaskCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details,
                    opt => opt.MapFrom(noteDto => noteDto.Details));

        }
    }
}
