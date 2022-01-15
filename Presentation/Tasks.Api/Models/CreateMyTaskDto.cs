using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Tasks.Application.MyTasks.Comands.CreateMyTask;

namespace Tasks.Api.Models
{
    public class CreateMyTaskDto
    {
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMyTaskDto, CreateMyTaskCommand>()
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details,
                    opt => opt.MapFrom(noteDto => noteDto.Details));
        }

    }
}
