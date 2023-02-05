using DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Queries
{
    public class ActiveStudentCountQueryResult :IRequest
    {
        public List<GetActiveStudentsListDto> SomeObjects { get; set; }
        public ActiveStudentCountQueryResult()
        {
        }
    }
}
