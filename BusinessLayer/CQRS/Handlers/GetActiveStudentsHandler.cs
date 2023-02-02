using BusinessLayer.CQRS.Results;
using BusinessLayer.Handlers.Queries.StudentQueries;
using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Handlers
{
    public class GetActiveStudentsHandlers
    {
        private readonly Context _context;

        public GetActiveStudentsHandlers(Context context)
        {
            _context = context;
        }

        public List<GetActiveStudentsQueryResult> Handle(GetActiveStudentsQuery query)
        {
            var values = _context.studentsv2.Select(x=> new GetActiveStudentsQueryResult
            {
                StudentId = x.StudentId,
                StudentName = x.StudentName,
                IsActive= x.IsActive.Equals(true),
                StudentRating= x.StudentRating,
                Description= x.Description,
                ParentName= x.ParentName,
                ParentAddress= x.ParentAddress,
                ParentIDNumber= x.ParentIDNumber,
                ParentPhoneNumber= x.ParentPhoneNumber,
                ParentEmail= x.ParentEmail
            }).AsNoTracking().ToList();

            return values;
        }
    }
}
