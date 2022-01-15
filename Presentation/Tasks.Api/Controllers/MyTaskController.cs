using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tasks.Api.Models;
using Tasks.Application.MyTasks.Comands.CreateMyTask;
using Tasks.Application.MyTasks.Comands.DeleteMyTask;
using Tasks.Application.MyTasks.Comands.UpdateMyTask;
using Tasks.Application.MyTasks.Queries;
using Tasks.Application.MyTasks.Queries.GetMyTaskDetails;
using Tasks.Application.MyTasks.Queries.GetMyTasksList;

namespace Tasks.Api.Controllers
{
    public class MyTaskController : BaseController
    {
        private readonly IMapper _mapper;
        public MyTaskController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<MyTasksListVm>> GetAll()
        {
            var query = new GetMyTaskListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MyTaskDetailsVm>> Get(Guid id)
        {
            var query = new GetMyTaskDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return vm;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMyTaskDto createNoteDto)
        {
            var command = _mapper.Map<CreateMyTaskCommand>(createNoteDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }


        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateMyTaskDto updateMyTaskDto)
        {
            var command = _mapper.Map<UpdateMyTaskCommand>(updateMyTaskDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMyTaskCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
