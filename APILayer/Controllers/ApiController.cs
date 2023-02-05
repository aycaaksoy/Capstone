using BusinessLayer.CQRS.Handlers;
using BusinessLayer.CQRS.Queries;
using DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Unit>> Create(List<GetActiveStudentsListDto> getActiveStudents, Mediator mediator)
        {
            return await mediator.Send(new  ActiveStudentCountQueryResult { SomeObjects = getActiveStudents });
        }
    }
}
