using BusinessLayer.CQRS.Queries;
using BusinessLayer.CQRS.Results;
using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Handlers
{
    public class ActiveStudentCountQueryHandler : IRequestHandler<ActiveStudentCountQueryResult>
    {
        private readonly Context _Context;

        public ActiveStudentCountQueryHandler(Context Context)
        {
            _Context = Context;
        }

        public async Task<Unit> Handle(ActiveStudentCountQueryResult request, CancellationToken cancellationToken)
        {
            foreach (var obj in request.SomeObjects)
            {
                // logic
                int count = await _Context.studentsv2.CountAsync(s => s.IsActive);
               
                return Unit.Value ;
            }
            return Unit.Value;
        }
    }
}
    


