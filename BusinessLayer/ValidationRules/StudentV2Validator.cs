using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class StudentV2Validator : AbstractValidator<StudentV2>
    {
        public StudentV2Validator()
        {
            RuleFor(x => x.StudentName).NotEmpty().WithMessage("Must NOT be empty");
            RuleFor(x => x.ParentName).NotEmpty().WithMessage("Must NOT be empty");
           
        }
    }
}
